using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend;
using DoranOfficeBackend.Models;
using AutoMapper;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Exceptions;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Dtos.Masterpelanggan;
using DoranOfficeBackend.Dtos.Transit;
using Microsoft.AspNetCore.Mvc.Filters;
using FluentValidation;
using ConsoleDump;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class TransitController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;
        private IValidator<SaveHeaderTransitDto> _validatorHeader;

        public TransitController(IMapper mapper, MyDbContext context, IValidator<SaveHeaderTransitDto> validatorHeader)
        {
            _mapper = mapper;
            _context = context;
            _validatorHeader = validatorHeader;
        }

        [HttpGet]
        public async Task<ActionResult<HtransitResultDto>> GetTransit([FromQuery] FindTransitDto dto)
        {
            ConsoleDump.Extensions.Dump(dto);
            var htransitQ = _context.Htransit
                .AsNoTracking()
                .AsQueryable();


            if (dto.MinDate.HasValue)
            {
                var minDate = new DateTime(dto.MinDate.Value.Year, dto.MinDate.Value.Month, dto.MinDate.Value.Day, 0, 0, 0);
                htransitQ = htransitQ.Where(x => x.TglTrans >= minDate);
            }

            if (dto.MaxDate.HasValue)
            {
                var maxDate = new DateTime(dto.MaxDate.Value.Year, dto.MaxDate.Value.Month, dto.MaxDate.Value.Day, 23, 59, 59);
                htransitQ = htransitQ.Where(x => x.TglTrans <= maxDate);
            }

            if (dto.KodeT.HasValue)
            {
                htransitQ = htransitQ.Where(x => x.KodeT == dto.KodeT);
            }

            if (dto.Kodegudang.HasValue)
            {
                htransitQ = htransitQ.Where(x => x.Kodegudang == dto.Kodegudang);
            }

            if (!String.IsNullOrWhiteSpace(dto.NamaGudangTujuan))
            {
                htransitQ = htransitQ.Where(x => x.MastergudangTujuan.Nama.Contains(dto.NamaGudangTujuan));
            }

            if (dto.KodeGudangTujuan.HasValue)
            {
                htransitQ = htransitQ.Where(x => x.KodeGudangTujuan == dto.KodeGudangTujuan);
            }

            if (dto.Kodepenyiap.HasValue)
            {
                htransitQ = htransitQ.Where(x => x.Kodepenyiap == dto.Kodepenyiap);
            }

            if (!String.IsNullOrWhiteSpace(dto.Historinya))
            {
                htransitQ = htransitQ.Where(x => x.HistoryNya == dto.Historinya);
            }

            var htransitPagingQ = htransitQ;
            var totalRow = await htransitPagingQ.CountAsync();

            htransitQ = htransitQ.OrderByDescending(x => x.TglTrans);

            var page = dto.Page <= 0 ? 1 : dto.Page;
            int skip = (page - 1) * dto.PageSize;
            htransitQ = htransitQ.Skip(skip)
                    .Take(dto.PageSize);
            htransitQ = SetHtransitRelations(htransitQ);

            var htransit = await htransitQ.ToListAsync();
            ICollection<HtransitResult> htransitResults = _mapper.Map<ICollection<HtransitResult>>(htransit);
            var totalPage = (int)Math.Ceiling((double)totalRow / dto.PageSize);
            var result = new HtransitResultDto
            {
                Data = htransitResults,
                Page = page,
                PageSize = dto.PageSize,
                TotalPage = totalPage,
                TotalRow = totalRow
            };

            //return Problem();
            return Ok(result);
        }

        [HttpGet("{kodet}", Name = "GetTransitByKodet")]
        public async Task<ActionResult<HtransitResult>> GetTransitByKodet(int kodet)
        {
            var htransitQ = _context.Htransit
              .AsNoTracking()
              .AsQueryable();
            htransitQ = htransitQ.Where(x => x.KodeT == kodet);
            htransitQ = SetHtransitRelations(htransitQ);
            var htransit = await htransitQ.FirstAsync();
            if (htransit == null)
            {
                return NotFound();
            }

            var htransitResult = _mapper.Map<HtransitResult>(htransit);   
            return htransitResult;
        }

        [HttpPost]
        public async Task<ActionResult> SaveTransit([FromBody] SaveHeaderTransitDto dto)
        {
            var validationResult = await _validatorHeader.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                errorMessages.Dump();
                // Return a BadRequestObjectResult with the error messages
                return StatusCode(422, new { Errors = errorMessages });
            }
            using (var transaction = _context.Database.BeginTransaction())//Begin Transaction
            {
                try
                {
                    var lastKodeT = await _context.Htransit.Select(e => e.KodeT)
                .MaxAsync();
                    var kodeh = 1;
                    if (lastKodeT != null)
                    {
                        kodeh = lastKodeT + 1;
                    }
                    var user = getUser();
                    var entity = _mapper.Map<Htransit>(dto);
                    entity.KodeT = kodeh;
                    entity.InsertName = (sbyte)user?.Kodeku;
                    entity.InsertTime = DateTime.Now;
                    _context.Htransit.Add(entity);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return Ok(lastKodeT);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }

            }
        }

        [HttpPut("{kode}")]
        public async Task<ActionResult> UpdateTransit(int kode, [FromBody] SaveTransitDto dto)
        {
            var htransit = await _context.Htransit.Where(e => e.KodeT == kode).FirstOrDefaultAsync();
            if (htransit == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, htransit);
            var user = getUser();

            htransit.UpdateName = (sbyte)user?.Kodeku;
            htransit.UpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();
            var deleteDtransit = _context.Dtransit.Where(e => e.Kodet == kode);
            if (deleteDtransit.Any())
            {
                _context.Dtransit.RemoveRange(deleteDtransit);
                await _context.SaveChangesAsync();
            }
            var dtransit = _mapper.Map<List<Dtransit>>(dto.Details);
            await InsertToDtransit(kode, dtransit);
            return Ok(htransit);
        }

        [HttpDelete("{kodet}/delete-detail-", Name = "DeleteDetailTransit")]
        public async Task<ActionResult<HtransitResult>> DeleteDetailTransit(int kodet, [FromBody] DeleteDetailByKodedDto dto)
        {
            ConsoleDump.Extensions.Dump(dto.Koded);
            if (_context.Htransit == null)
            {
                return Problem("Entity set 'MyDbContext.Htransit'  is null.");
            }
            var detailsToDelete = _context.Dtransit
                .Where(x => x.Kodet == kodet)
                .Where(x => dto.Koded.Contains(x.Koded));
            _context.Dtransit.RemoveRange(detailsToDelete);
            await _context.SaveChangesAsync();
            var htransitQ =  _context.Htransit.Where(x => x.KodeT == kodet);
            htransitQ = SetHtransitRelations(htransitQ);
            var htransit = await htransitQ.FirstOrDefaultAsync();
            return Ok(_mapper.Map<HtransitResult>(htransit));
        }

        [HttpPost("{kodet}", Name = "InsertDetailTransit")]
        public async Task<ActionResult<HtransitResult>> InsertDetailTransit(int kodet, [FromBody] UpdateDetailByKodedDto dto)
        {
            if (_context.Htransit == null)
            {
                return Problem("Entity set 'MyDbContext.Htransit'  is null.");
            }

            ConsoleDump.Extensions.Dump(dto);
            var lastDtransit = await _context.Dtransit
                .Where(x => x.Kodet == kodet)
                .OrderByDescending(x => x.Koded)
                .FirstOrDefaultAsync();
            short koded = 1;
            if (lastDtransit != null)
            {
                koded = (short)(lastDtransit.Koded + 1);
            }
            var entity = _mapper.Map<Dtransit>(dto);
            entity.Kodet = kodet;
            entity.Koded = koded;
            _context.Dtransit.Add(entity);
            await _context.SaveChangesAsync();
            var htransitQ = _context.Htransit.Where(x => x.KodeT == kodet);
            htransitQ = SetHtransitRelations(htransitQ);
            var htransit = await htransitQ.FirstOrDefaultAsync();
            return Ok(_mapper.Map<HtransitResult>(htransit));
        }

        [HttpPut("{kodet}/{koded}", Name = "UpdateDetailTransit")]
        public async Task<ActionResult<HtransitResult>> UpdateDetailTransit(int kodet, int koded, [FromBody] UpdateDetailByKodedDto dto)
        {
            if (_context.Htransit == null)
            {
                return Problem("Entity set 'MyDbContext.Htransit'  is null.");
            }
            var entity = await _context.Dtransit
                .Where(x => x.Kodet == kodet)
                .Where(x => x.Koded == koded)
                .FirstAsync();

            entity.Jumlah = dto.Jumlah;
            entity.Kodebarang = dto.Kodebarang;
            entity.NmrSn = dto.NmrSn;
            await _context.SaveChangesAsync();
            var htransitQ = _context.Htransit.Where(x => x.KodeT == kodet);
            htransitQ = SetHtransitRelations(htransitQ);
            var htransit = await htransitQ.FirstOrDefaultAsync();
            return Ok(_mapper.Map<HtransitResult>(htransit));
        }

        private async Task InsertToDtransit(int kodeh, List<Dtransit> dtransit)
        {
            for (short i = 0; i < dtransit.Count; i++)
            {
                dtransit[i].Koded = (short)(i + 1);
                dtransit[i].Kodet = kodeh;
            }

            string insertQuery = "INSERT INTO dtransit (kodet,koded,kodebarang,jumlah,nmrsn) VALUES ";
            string values = string.Join(", ", dtransit.Select(item => $"({item.Kodet},{item.Koded},{item.Kodebarang},{item.Jumlah},'{item.NmrSn}')"));
            insertQuery += values;
            await _context.Database.ExecuteSqlRawAsync(insertQuery);
        }


        private IQueryable<Htransit> SetHtransitRelations(IQueryable<Htransit> htransitQ)
        {
            return htransitQ.Include(e => e.Dtransit)
                .ThenInclude(e => e.Masterbarang)
                .ThenInclude(e => e.Mastertipebarang)
                .Include(e => e.MasteruserInsert)
                .Include(e => e.Penyiaporder)
                .Include(e => e.Mastergudang)
                .Include(e => e.MastergudangTujuan);
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

    }
}
