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

            var htransQ = _context.Htrans.AsSplitQuery()
                .AsNoTracking()
                .AsQueryable();

            if (dto.Kodegudang.HasValue && dto.Kodegudang >= 0)
            {
                htransQ = htransQ.Where(x => x.Kodegudang == dto.Kodegudang);
            }

            if (!String.IsNullOrWhiteSpace(dto.NamaPelanggan))
            {
                htransQ = htransQ.Where(x => x.NamaCust.ToLower().Contains(dto.NamaPelanggan));
            }

            if (dto.MinDate.HasValue)
            {
                htransQ = htransQ.Where(x => x.TglTrans >= dto.MinDate.Value);
            }

            if (dto.MaxDate.HasValue)
            {
                htransQ = htransQ.Where(x => x.TglTrans <= dto.MaxDate.Value);
            }


            var htransPagingQ = htransQ;
            var totalRow = await htransPagingQ.CountAsync();

            htransQ = htransQ.OrderByDescending(x => x.TglTrans);
            htransQ = htransQ.Skip((dto.Page - 1) * dto.PageSize)
                    .Take(dto.PageSize);
            htransQ = htransQ.Include(e => e.Dtrans)
                .ThenInclude(e => e.Masterbarang)
                .AsSingleQuery()
                .Include(e => e.Masterpelanggan)
                .ThenInclude(e => e.LokasiKota);

            var htrans = await htransQ.ToListAsync();
            var totalPage = (int)Math.Ceiling((double)totalRow / dto.PageSize);
            var result = new HtransResultDto
            {
                Data = htrans,
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
           
            return Ok(lastKodeh);

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
            return Ok(htrans);
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
