
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Models;
using AutoMapper;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Dtos.Order;
using DoranOfficeBackend.Dtos.Transaksi;

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
        public async Task<ActionResult<IEnumerable<Dtos.Order.HorderResultDto>>> GetOrder([FromQuery] FindOrderDto dto)
        {
            ConsoleDump.Extensions.Dump(dto);
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

            if (dto.Kodeh.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Kodeh == dto.Kodeh);
            }

            //if (dto.Kodegudang.HasValue && dto.Kodegudang >= 0)
            //{
            //    HorderQ = HorderQ.Where(x => x.Kodegudang == dto.Kodegudang);
            //}

            if (dto.Kodesales.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Kodesales == dto.Kodesales);
            }

            if (dto.Kodepelanggan.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Kodepelanggan == dto.Kodepelanggan);
            }

            if (dto.KodeKota.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Masterpelanggan.Kota == dto.KodeKota);
            }

            if (dto.KodeProvinsi.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Masterpelanggan.LokasiKota.Provinsi == dto.KodeProvinsi);
            }

            if (!String.IsNullOrEmpty(dto.NamaPelanggan))
            {
                HorderQ = HorderQ.Where(x => EF.Functions.Like(x.Masterpelanggan.Nama, $"%{dto.NamaPelanggan}%"));
            }

            if (!String.IsNullOrEmpty(dto.Kodenota))
            {
                HorderQ = HorderQ.Where(x => x.Kode == dto.Kodenota);
            }

            if (!String.IsNullOrEmpty(dto.Lunas))
            {
                HorderQ = HorderQ.Where(x => x.Lunas == dto.Lunas);
            }

            var HorderPagingQ = HorderQ;
            var totalRow = await HorderPagingQ.CountAsync();

            HorderQ = HorderQ.OrderByDescending(x => x.TglTrans);

            if (dto.Limit.HasValue)
            {
                HorderQ = HorderQ.Take(dto.Limit.Value);
            }
            int skip = (dto.Page - 1) * dto.PageSize;
            HorderQ = HorderQ.Skip(skip)
                    .Take(dto.PageSize);
            HorderQ = HorderQ.Include(e => e.Dtrans)
                .ThenInclude(e => e.Masterbarang)
                .AsSplitQuery()
                .Include(e => e.Masterpelanggan)
                .ThenInclude(e => e.LokasiKota)
                .AsSplitQuery()
                .Include(e => e.Sales)
                .Include(e => e.Mastergudang);

            var Horder = await HorderQ.ToListAsync();
            ICollection<HorderResult> HorderResults = _mapper.Map<ICollection<HorderResult>>(Horder);
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
            var lastKodeh = await _context.Horder.Select(e => e.KodeH)
                .MaxAsync();
            var kodeh = 1;
            if (lastKodeh != null)
            {
                kodeh = lastKodeh + 1;
            }
            var user = getUser();
            var entity = _mapper.Map<Horder>(dto);
            entity.KodeH = kodeh;
            entity.InsertName = (sbyte)user?.Kodeku;
            entity.InsertTime = DateTime.Now;
            _context.Horder.Add(entity);
            await _context.SaveChangesAsync();

            var dtrans = _mapper.Map<List<Dtrans>>(dto.Details);
            await InsertToDtrans(entity.KodeH, dtrans);

            return Ok(lastKodeh);

        }

        [HttpPut("{kode}")]
        public async Task<ActionResult> UpdateOrder(int kode, [FromBody] SaveOrderDto dto)
        {
            var Horder = await _context.Horder.Where(e => e.KodeH == kode).FirstOrDefaultAsync();
            if (Horder == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, Horder);
            var user = getUser();

            Horder.UpdateName = (sbyte)user?.Kodeku;
            Horder.UpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();
            var deleteDtrans = _context.Dtrans.Where(e => e.Kodeh == kode);
            if (deleteDtrans.Any())
            {
                _context.Dtrans.RemoveRange(deleteDtrans);
                await _context.SaveChangesAsync();
            }
            var dtrans = _mapper.Map<List<Dtrans>>(dto.Details);
            await InsertToDtrans(kode, dtrans);
            return Ok(Horder);
        }

        private async Task InsertToDtrans(int kodeh, List<Dtrans> dtrans)
        {
            for (short i = 0; i < dtrans.Count; i++)
            {
                dtrans[i].Koded = (short)(i + 1);
                dtrans[i].Kodeh = kodeh;
            }

            string insertQuery = "INSERT INTO dtrans (kodeh,koded,kodebarang,jumlah,harga,nmrsn) VALUES ";
            string values = string.Join(", ", dtrans.Select(item => $"({item.Kodeh},{item.Koded},{item.Kodebarang},{item.Jumlah},{item.Harga},'{item.Nmrsn}')"));
            insertQuery += values;
            await _context.Database.ExecuteSqlRawAsync(insertQuery);
        }
    }
}
