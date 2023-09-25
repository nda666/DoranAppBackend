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
using DoranOfficeBackend.Dtos.Transaksi;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class TransaksiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;
        public TransaksiController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HtransResultDto>>> GetTransaksi([FromQuery] FindTransaksiDto dto)
        {
            ConsoleDump.Extensions.Dump(dto);
            var htransQ = _context.Htrans
                .AsNoTracking()
                .AsQueryable();


            if (dto.MinDate.HasValue)
            {
                var minDate = new DateTime(dto.MinDate.Value.Year, dto.MinDate.Value.Month, dto.MinDate.Value.Day, 0, 0, 0);
                htransQ = htransQ.Where(x => x.TglTrans >= minDate);
            }

            if (dto.MaxDate.HasValue)
            {
                var maxDate = new DateTime(dto.MaxDate.Value.Year, dto.MaxDate.Value.Month, dto.MaxDate.Value.Day, 23, 59, 59);
                htransQ = htransQ.Where(x => x.TglTrans <= maxDate);
            }

            if (dto.Kodeh.HasValue)
            {
                htransQ = htransQ.Where(x => x.KodeH == dto.Kodeh);
            }

            if (dto.Kodegudang.HasValue && dto.Kodegudang >= 0)
            {
                htransQ = htransQ.Where(x => x.Kodegudang == dto.Kodegudang);
            }

            if (dto.KodeSales.HasValue)
            {
                htransQ = htransQ.Where(x => x.KodeSales == dto.KodeSales);
            }

            if (dto.KodePelanggan.HasValue)
            {
                htransQ = htransQ.Where(x => x.KodePelanggan == dto.KodePelanggan);
            }

            if (dto.KodeKota.HasValue)
            {
                htransQ = htransQ.Where(x => x.Masterpelanggan.Kota == dto.KodeKota);
            }

            if (dto.KodeProvinsi.HasValue)
            {
                htransQ = htransQ.Where(x => x.Masterpelanggan.LokasiKota.Provinsi == dto.KodeProvinsi);
            }

            if (!String.IsNullOrEmpty(dto.NamaPelanggan))
            {
                htransQ = htransQ.Where(x => EF.Functions.Like(x.Masterpelanggan.Nama, $"%{dto.NamaPelanggan}%"));
            }

            if (!String.IsNullOrEmpty(dto.Kodenota))
            {
                htransQ = htransQ.Where(x => x.Kodenota == dto.Kodenota);
            }

            if (!String.IsNullOrEmpty(dto.Lunas))
            {
                htransQ = htransQ.Where(x => x.Lunas == dto.Lunas);
            }

            var htransPagingQ = htransQ;
            var totalRow = await htransPagingQ.CountAsync();

            htransQ = htransQ.OrderByDescending(x => x.TglTrans);

            if (dto.Limit.HasValue)
            {
                htransQ = htransQ.Take(dto.Limit.Value);
            }
            int skip = (dto.Page - 1) * dto.PageSize;
            htransQ = htransQ.Skip(skip)
                    .Take(dto.PageSize);
            htransQ = htransQ.Include(e => e.Dtrans)
                .ThenInclude(e => e.Masterbarang)
                .AsSplitQuery()
                .Include(e => e.Masterpelanggan)
                .ThenInclude(e => e.LokasiKota)
                .AsSplitQuery()
                .Include(e => e.Sales)
                .Include(e => e.Mastergudang);

            var htrans = await htransQ.ToListAsync();
            ICollection<HtransResult> htransResults = _mapper.Map<ICollection<HtransResult>>(htrans);
            var totalPage = (int)Math.Ceiling((double)totalRow / dto.PageSize);
            var result = new HtransResultDto
            {
                Data = htransResults,
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
        public async Task<ActionResult> SaveTransaksi([FromBody] SaveTransaksiDto dto)
        {
            using (var transaction = _context.Database.BeginTransaction())//Begin Transaction
            {
                try
                {
                    var lastKodeh = await _context.Htrans.Select(e => e.KodeH)
                    .MaxAsync();
                    var kodeh = 1;
                    if (lastKodeh != null)
                    {
                        kodeh = lastKodeh + 1;
                    }
                    var user = getUser();
                    var entity = _mapper.Map<Htrans>(dto);
                    entity.KodeH = kodeh;
                    entity.InsertName = (sbyte)user?.Kodeku;
                    entity.InsertTime = DateTime.Now;
                    _context.Htrans.Add(entity);
                    await _context.SaveChangesAsync();

                    var dtrans = _mapper.Map<List<Dtrans>>(dto.Details);
                    await InsertToDtrans(entity.KodeH, dtrans);
                    transaction.Commit();
                    return Ok(lastKodeh);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }

            }
        }

        [HttpPut("{kode}")]
        public async Task<ActionResult> UpdateTransaksi(int kode, [FromBody] SaveTransaksiDto dto)
        {
            var htrans = await _context.Htrans.Where(e => e.KodeH == kode).FirstOrDefaultAsync();
            if (htrans == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, htrans);
            var user = getUser();
            using (var transaction = _context.Database.BeginTransaction())//Begin Transaction
            {
                try
                {

                    htrans.UpdateName = (sbyte)user?.Kodeku;
                    htrans.UpdateTime = DateTime.Now;
                    await _context.SaveChangesAsync();
                    var deleteDtrans = _context.Dtrans.Where(e => e.Kodeh == kode);
                    if (deleteDtrans.Any())
                    {
                        _context.Dtrans.RemoveRange(deleteDtrans);
                        await _context.SaveChangesAsync();
                    }
                    var dtrans = _mapper.Map<List<Dtrans>>(dto.Details);
                    await InsertToDtrans(kode, dtrans);

                    transaction.Commit();
                    return Ok(htrans);
                }
                catch (Exception ex) {
                    transaction.Rollback();
                    throw;
                }
            }
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
