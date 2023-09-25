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
        public async Task<ActionResult<IEnumerable<HtransitResultDto>>> GetTransit([FromQuery] FindTransitDto dto)
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


            int skip = (dto.Page - 1) * dto.PageSize;
            htransitQ = htransitQ.Skip(skip)
                    .Take(dto.PageSize);
            htransitQ = htransitQ.Include(e => e.Dtransit)
                .ThenInclude(e => e.Masterbarang)
                .ThenInclude(e => e.Mastertipebarang)
                .Include(e => e.MasteruserInsert)
                .Include(e => e.Penyiaporder)
                .Include(e => e.Mastergudang)
                .Include(e => e.MastergudangTujuan);

            var htransit = await htransitQ.ToListAsync();
            ICollection<HtransitResult> htransitResults = _mapper.Map<ICollection<HtransitResult>>(htransit);
            var totalPage = (int)Math.Ceiling((double)totalRow / dto.PageSize);
            var result = new HtransitResultDto
            {
                Data = htransitResults,
                Page = dto.Page,
                PageSize = dto.PageSize,
                TotalPage = totalPage,
                TotalRow = totalRow
            };

            //return Problem();
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
    }
}
