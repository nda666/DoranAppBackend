
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Models;
using AutoMapper;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Dtos.Order;
using DocumentFormat.OpenXml.InkML;
using Humanizer;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public OrderController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorderResultDto>>> GetOrder([FromQuery] FindOrderDto dto)
        {
            var HorderQ = _context.Horder
                .AsNoTracking()
                .AsQueryable();


            if (dto.MinDate.HasValue)
            {
                var minDate = new DateTime(dto.MinDate.Value.Year, dto.MinDate.Value.Month, dto.MinDate.Value.Day, 0, 0, 0);
                HorderQ = HorderQ.Where(x => x.Tglorder >= minDate);
            }

            if (dto.MaxDate.HasValue)
            {
                var maxDate = new DateTime(dto.MaxDate.Value.Year, dto.MaxDate.Value.Month, dto.MaxDate.Value.Day, 23, 59, 59);
                HorderQ = HorderQ.Where(x => x.Tglorder <= maxDate);
            }

            if (!String.IsNullOrWhiteSpace(dto.NamaCust))
            {
                HorderQ = HorderQ.Where(x => EF.Functions.Like(x.NamaCust, $"%{dto.NamaCust}%"));
            }

            if (!String.IsNullOrWhiteSpace(dto.NamaPelanggan))
            {
                HorderQ = HorderQ.Where(x => EF.Functions.Like(x.Masterpelanggan.Nama, $"%{dto.NamaCust}%"));
            }

            if (dto.Kodeh.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Kodeh == dto.Kodeh);
            }

            if (dto.Dicetak.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Dicetak == dto.Dicetak);
            }

            if (dto.LevelOrder == LevelOrderEnum.ADMIN)
            {
                
                HorderQ = HorderQ.Where(x => x.Historynya >= 2 && x.Historynya <= 2);
            }

            if (dto.LevelOrder == LevelOrderEnum.GUDANG)
            {
                HorderQ = HorderQ.Where(x => x.Historynya >= 2 && x.Historynya >= 3);
            }

            if (dto.BelumCekOl)
            {
                HorderQ = HorderQ.Where(x => x.Historynya >= 5);
            }

            if (dto.SalesOl.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Sales.Salesol == dto.SalesOl);
            }

            if (dto.Kodesales.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Kodesales == dto.Kodesales);
            }

            if (dto.Kodepelanggan.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Kodepelanggan == dto.Kodepelanggan);
            }


            var HorderPagingQ = HorderQ;
            var totalRow = await HorderPagingQ.CountAsync();

            HorderQ = HorderQ.OrderByDescending(x => x.Tglorder);

            int skip = (dto.Page - 1) * dto.PageSize;
            HorderQ = HorderQ.Skip(skip)
                    .Take(dto.PageSize);
            HorderQ = HorderQ
                .Include(e => e.Sales)
                .Include(e => e.Penyiaporder)
                .Include(e => e.MasteruserInsert)
                .Include(e => e.MasteruserUpdate)
                .Include(e => e.Ekspedisi)
                .Include(e => e.Dorder)
                .ThenInclude(e=>e.Masterbarang)
                .Include(e => e.Masterpelanggan)
                .ThenInclude(e => e.LokasiKota);

            var Horder = await HorderQ.ToListAsync();
            ICollection <HorderResult> HorderResults = _mapper.Map<ICollection<HorderResult>>(Horder);

            ConsoleDump.Extensions.Dump(HorderResults);
            var totalPage = (int)Math.Ceiling((double)totalRow / dto.PageSize);
            var result = new HorderResultDto
            {
                Data = HorderResults,
                Page = dto.Page,
                PageSize = dto.PageSize,
                TotalPage = totalPage,
                TotalRow = totalRow
            };
            return Ok(result);
        }


        private Masteruser? getUser()
        {
            var user = (Masteruser)HttpContext.Items["User"];
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult> SaveOrder([FromBody] SaveOrderDto dto)
        {
           
            var lastKodeh = await _context.Horder.Select(e => e.Kodeh)
                .MaxAsync();
            var kodeh = 1;
            if (lastKodeh != null)
            {
                kodeh = lastKodeh + 1;
            }
            var user = getUser();
            var entity = _mapper.Map<Horder>(dto);
            entity.Kodeh = kodeh;
            entity.Insertname = (sbyte)user?.Kodeku;
            entity.Inserttime = DateTime.Now;
            _context.Horder.Add(entity);
            using (var transaction = _context.Database.BeginTransaction())//Begin Transaction
            {
                try
                {
                    await _context.SaveChangesAsync();

                    var dorder = _mapper.Map<List<Dorder>>(dto.Details);
                    await InsertToDorder(entity.Kodeh, dorder);
                    transaction.Commit();
                    return Ok(lastKodeh);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("{kode}")]
        public async Task<ActionResult> UpdateOrder(int kode, [FromBody] SaveOrderDto dto)
        {
            var Horder = await _context.Horder.Where(e => e.Kodeh == kode).FirstOrDefaultAsync();
            if (Horder == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, Horder);
            var user = getUser();

            Horder.Updatename = (sbyte)user?.Kodeku;
            Horder.Updatetime = DateTime.Now;
            using (var transaction = _context.Database.BeginTransaction())//Begin Transaction
            {

                try
                {
                    await _context.SaveChangesAsync();
                    var deleteDorder = _context.Dorder.Where(e => e.Kodeh == kode);
                    if (deleteDorder.Any())
                    {
                        _context.Dorder.RemoveRange(deleteDorder);
                        await _context.SaveChangesAsync();
                    }
                    var dorder = _mapper.Map<List<Dorder>>(dto.Details);
                    await InsertToDorder(kode, dorder);
                    transaction.Commit();
                    return Ok(Horder);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("{kode}/set-penyiap", Name = "SetPenyiapOrder")]
        public async Task<ActionResult> SetPenyiapOrder(int kode, [FromBody] SetPenyiapOrderDto dto)
        {
            var Horder = await _context.Horder.Where(e => e.Kodeh == kode).FirstOrDefaultAsync();
            if (Horder == null)
            {
                return NotFound();
            }
           
            Horder.Kodepenyiap = dto.Kodepenyiap;
            await _context.SaveChangesAsync();
            return Ok(Horder);
        }
        private async Task InsertToDorder(int kodeh, List<Dorder> dtrans)
        {
            for (short i = 0; i < dtrans.Count; i++)
            {
                dtrans[i].Koded = (short)(i + 1);
                dtrans[i].Kodeh = kodeh;
            }

            string insertQuery = "INSERT INTO dorder (kodeh,koded,kodebarang,jumlah,harga,keterangan) VALUES ";
            string values = string.Join(", ", dtrans.Select(item => $"({item.Kodeh},{item.Koded},{item.Kodebarang},{item.Jumlah},{item.Harga},'{item.Keterangan}')"));
            insertQuery += values;
            await _context.Database.ExecuteSqlRawAsync(insertQuery);
        }
    }
}
