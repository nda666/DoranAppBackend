using AutoMapper;
using ConsoleDump;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Dtos.PermintaanSales;
using DoranOfficeBackend.Dtos.Transit;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Models;
using DoranOfficeBackend.PermintaanSales.Order;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoranOfficeBackend.Controller
{
    [Route("api/permintaan-sales")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class PermintaanSalesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;
        private IValidator<SavePermintaanSalesDto> _SavePermintaanSalesValidator;

        public PermintaanSalesController(
            IMapper mapper, 
            MyDbContext context, 
            IValidator<SavePermintaanSalesDto> SavePermintaanSalesValidator
            )
        {
            _mapper = mapper;
            _context = context;
            _SavePermintaanSalesValidator = SavePermintaanSalesValidator;
        }

        private IQueryable<Horder> BasePermintaanSalesQuery(FindPermintaanSalesDto dto)
        {
            var HorderQ = _context.Horder
               .AsNoTracking()
               .AsQueryable();
            HorderQ = HorderQ.Where(x => x.StokSales == true);

            if (dto.Kodesales.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Kodesales == dto.Kodesales);
            }

            if (dto.Kodegudang.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Kodegudang == dto.Kodegudang);
            }

            if (!String.IsNullOrEmpty(dto.Namagudang))
            {
                HorderQ = HorderQ.Where(x => EF.Functions.Like(x.MastergudangTujuan.Nama, $"%{dto.Namagudang}%"));
            }

            if (dto.Kodebarang.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Dorder.Any(e => e.Kodebarang == dto.Kodebarang));
            }

            return HorderQ;
        }

        private IQueryable<Horder> IncludeHorderRelation(IQueryable<Horder> HorderQ)
        {
            HorderQ = HorderQ
                .Include(e => e.MastergudangTujuan)
                .Include(e => e.Mastergudang)
                .Include(e => e.Sales)
                .Include(e => e.Penyiaporder)
                .Include(e => e.MasteruserInsert)
                .Include(e => e.MasteruserUpdate)
                .Include(e => e.Dorder)
                .ThenInclude(e => e.Masterbarang)
                .ThenInclude(e => e.Mastertipebarang);
            return HorderQ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermintaanSalesResultDto>>> GetPermintaanSales([FromQuery] FindPermintaanSalesDto dto)
        {
            var HorderQ = BasePermintaanSalesQuery(dto);
            var HorderPagingQ = HorderQ;
            var totalRow = await HorderPagingQ.CountAsync();

            HorderQ = HorderQ.OrderByDescending(x => x.Tglorder);

            int skip = (dto.Page - 1) * dto.PageSize;
            HorderQ = HorderQ.Skip(skip)
                    .Take(dto.PageSize);
            HorderQ = IncludeHorderRelation(HorderQ);

            var Horder = await HorderQ.ToListAsync();
            ICollection<PermintaanSalesResult> PermintaanSalesResults = _mapper.Map<ICollection<PermintaanSalesResult>>(Horder);
            PermintaanSalesResults.First().Dorder.First().Masterbarang.Mastertipebarang.Dump();

            var totalPage = (int)Math.Ceiling((double)totalRow / dto.PageSize);
            var result = new PermintaanSalesResultDto
            {
                Data = PermintaanSalesResults,
                Page = dto.Page,
                PageSize = dto.PageSize,
                TotalPage = totalPage,
                TotalRow = totalRow
            };
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> SavePermintaanSales([FromBody] SavePermintaanSalesDto dto)
        {
            var validationResult = await _SavePermintaanSalesValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();

                // Return a BadRequestObjectResult with the error messages
                return StatusCode(422, new { Errors = errorMessages });
            }
            var lastKodeh = await _context.Horder.MaxAsync(e => e.Kodeh);
            var kodeh = 1;
            if (lastKodeh != null)
            {
                kodeh = lastKodeh + 1;
            }
            var user = this.GetUser();
            var entity = _mapper.Map<Horder>(dto);
            entity.Kodeh = kodeh;
            entity.Insertname = (sbyte)user?.Kodeku;
            entity.Inserttime = DateTime.Now;
            entity.Kodeexp = 0;
            entity.Kirimmelalui = 0;
            entity.Jumlah = 0;
            entity.StokSales = true;
            _context.Horder.Add(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{kode}")]
        public async Task<ActionResult<PermintaanSalesResult>> UpdatePermintaanSales(int kode, [FromBody] SaveHeaderTransitDto dto)
        {

            var horder = await _context.Horder.Where(e => e.Kodeh == kode).FirstOrDefaultAsync();
            if (horder == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, horder);
            var user = this.GetUser();

            horder.Updatename = (sbyte)user?.Kodeku;
            horder.Updatetime = DateTime.Now;
            await _context.SaveChangesAsync();
            var horderQ = _context.Horder.Where(x => x.Kodeh == horder.Kodeh);
            horderQ = IncludeHorderRelation(horderQ);
            var result = await horderQ.FirstOrDefaultAsync();
            return Ok(_mapper.Map<PermintaanSalesResult>(result));
        }

        [HttpDelete("{kodeh}/delete-detail", Name = "DeleteDetailPermintaanSales")]
        public async Task<ActionResult<PermintaanSalesResult>> DeleteDetailPermintaanSales(int kodeh, [FromBody] DeletePermintaanSalesDetailDto dto)
        {
            ConsoleDump.Extensions.Dump(dto.Koded);
            if (_context.Horder == null)
            {
                return Problem("Entity set 'MyDbContext.Horder'  is null.");
            }
            var detailsToDelete = _context.Dorder
                .Where(x => x.Kodeh == kodeh)
                .Where(x => dto.Koded.Contains(x.Koded));
            _context.Dorder.RemoveRange(detailsToDelete);
            await _context.SaveChangesAsync();
            var horderQ = _context.Horder.Where(x => x.Kodeh == kodeh);
            horderQ = IncludeHorderRelation(horderQ);
            var horder = await horderQ.FirstOrDefaultAsync();
            return Ok(_mapper.Map<PermintaanSalesResult>(horder));
        }

        [HttpPost("{kodeh}", Name = "InsertDetailPermintaanSales")]
        public async Task<ActionResult<PermintaanSalesResult>> InsertDetailPermintaanSales(int kodeh, [FromBody] InsertDetailPermintaanSalesDto dto)
        {
            if (_context.Horder == null)
            {
                return Problem("Entity set 'MyDbContext.Horder'  is null.");
            }

            var lastDorder = await _context.Dorder
                .Where(x => x.Kodeh == kodeh)
                .OrderByDescending(x => x.Koded)
                .FirstOrDefaultAsync();
            short koded = 1;
            if (lastDorder != null)
            {
                koded = (short)(lastDorder.Koded + 1);
            }
            var entity = _mapper.Map<Dorder>(dto);
            entity.Kodeh = kodeh;
            entity.Koded = koded;
            entity.Keterangan = dto.Keterangan;
            _context.Dorder.Add(entity);
            await _context.SaveChangesAsync();
            var horderQ = _context.Horder.Where(x => x.Kodeh == koded);
            horderQ = IncludeHorderRelation(horderQ);
            var horder = await horderQ.FirstOrDefaultAsync();
            horder.Dorder.Dump();
            return Ok(_mapper.Map<PermintaanSalesResult>(horder));
        }

        [HttpPut("{kodeh}/{koded}", Name = "UpdateDetailPermintaanSales")]
        public async Task<ActionResult<PermintaanSalesResult>> UpdateDetailPermintaanSales(int kodeh, int koded, [FromBody] InsertDetailPermintaanSalesDto dto)
        {
            if (_context.Horder == null)
            {
                return Problem("Entity set 'MyDbContext.Horder'  is null.");
            }
            var entity = await _context.Dorder
                .Where(x => x.Kodeh == kodeh)
                .Where(x => x.Koded == koded)
                .FirstAsync();

            entity.Jumlah = dto.Jumlah;
            entity.Kodebarang = dto.Kodebarang;
            entity.Keterangan = dto.Keterangan;
            await _context.SaveChangesAsync();
            var horderQ = _context.Horder.Where(x => x.Kodeh == kodeh);
            horderQ = IncludeHorderRelation(horderQ);
            var horder = await horderQ.FirstOrDefaultAsync();
            return Ok(_mapper.Map<PermintaanSalesResult>(horder));
        }


    }
}
