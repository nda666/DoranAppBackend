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
using DoranOfficeBackend.Dtos.Harga;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class HargaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public HargaController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("bylevel")]
        public async Task<ActionResult<IEnumerable<HargaByLevelResult>>> GetHargaByLevel([FromQuery] FindHargaByLevelDto dto)
        {
            var barangs = await _context.Masterbarang
                    .Where(x => dto.Kodebarang.Contains(x.BrgKode))
                    .Include(e => e.Dkategoribarang)
                    .ToListAsync();
            var result = new List<HargaByLevelResult>();
            foreach (var barang in barangs)
            {
                if (barang.Dkategoribarang.Kodeh == 1)
                {
                    var hargaJete = await getHargaJete(barang.BrgKode, dto.Kodepelanggan);
                    if (hargaJete != null) result.Add(hargaJete);
                } else { 
                var hargaNonJete = _context.Sethargalevel
                    .Where(x => x.Kode == dto.Kodelevel)
                    .Join(
                        _context.Sethargajual,
                        e => e.Kode,
                        e => e.Kodelevel,
                        (sethargalevel, sethargajual) => new 
                        {
                            Kodebarang = sethargajual.Kodebarang,
                            Harga = sethargajual.Harga
                        }
                       )
                    .Where(x => x.Kodebarang == barang.BrgKode)
                    .Join(
                        _context.Masterbarang,
                       e => e.Kodebarang,
                       e => e.BrgKode,
                       (_join,masterbarang) => new HargaByLevelResult
                       {
                           Namabarang = masterbarang.BrgNama,
                           Kodebarang = _join.Kodebarang,
                           Harga = _join.Harga
                       }
                        ).FirstOrDefault();
                    if (hargaNonJete != null) result.Add(hargaNonJete);
                }
            }

            return result;
        }
        
        private async Task<HargaByLevelResult?> getHargaJete(int itemId, int kodePelanggan)
        {
            var pelanggan = await _context.Masterpelanggan
                    .Where(e => e.Kode == kodePelanggan)
                    .FirstOrDefaultAsync();

            if (pelanggan == null) {
                return null;
            }

            var harga = await _context.Sethargajual
                    .Where(e => e.Kodelevel == pelanggan.KodelevelhargaJete)
                    .Join(
                _context.Masterbarang,
                e => e.Kodebarang,
                e => e.BrgKode,
                (sethargajual, masterbarang) => new HargaByLevelResult
                {
                    Kodebarang = masterbarang.BrgKode,
                    Harga = sethargajual.Harga,
                    Namabarang = masterbarang.BrgNama
                }
                    )
                    .FirstOrDefaultAsync();

            return harga;

        }
    }
}
