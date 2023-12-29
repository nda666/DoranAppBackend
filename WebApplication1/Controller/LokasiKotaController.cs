
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Models;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Dtos.LokasiKota;
using AutoMapper;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using ConsoleDump;

namespace DoranOfficeBackend.Controller.LokasiKotaController
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    public class LokasiKotaController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public LokasiKotaController(IMapper mapper, MyDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/LokasiKota
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LokasiKotaDataDto>>> GetLokasiKota([FromQuery] FindLokasiKotaDto dto)
        {
            if (_context.LokasiKota == null)
            {
                return NotFound();
            }

            var query = _context.LokasiKota
                .Join(
                    _context.LokasiProvinsi,
                    e => e.Provinsi,
                    e => e.Kode,
                    (LokasiKota, LokasiProvinsi) => new
                    {
                        LokasiKota,
                        LokasiProvinsi
                    }
                )
                .GroupJoin(
                     _context.Coa4s,
                    e => e.LokasiKota.Kodecoa4,
                    e => e.Kode,
                    (k, c) => new
                    {
                        LokasiKota = k.LokasiKota,
                        LokasiProvinsi = k.LokasiProvinsi,
                        Coa4 = c
                    }
                ).SelectMany(e => e.Coa4.DefaultIfEmpty(), (x,coa4) => new
                {
                    LokasiKota = x.LokasiKota,
                    LokasiProvinsi = x.LokasiProvinsi,
                    Coa4 = coa4
                });
            
            if (!String.IsNullOrEmpty(dto.Nama))
            {
                query = query.Where(r => EF.Functions.Like(r.LokasiKota.Nama, $"%{dto.Nama}%"));
            }
            return await query.Select(e => new LokasiKotaDataDto
            {
              Kode = e.LokasiKota.Kode,
              Nama = e.LokasiKota.Nama,
              NamaCoa = e.Coa4.Nama,
              AdaKertasOrder = e.LokasiKota.AdaKertasOrder,
              Kodecoa4 = e.LokasiKota.Kodecoa4,
              Kodeareapengiriman = e.LokasiKota.Kodeareapengiriman,
              NamaProvinsi = e.LokasiProvinsi.Nama,
              Provinsi = e.LokasiKota.Provinsi
            }).ToListAsync();
        }

        // GET: api/LokasiKota/5
        [HttpGet("{kode}")]
        public async Task<ActionResult<LokasiKota>> GetLokasiKota(int kode)
        {
            if (_context.LokasiKota == null)
            {
                return NotFound();
            }
            var hkategoriBarang = await _context.LokasiKota.FindAsync(kode);

            if (hkategoriBarang == null)
            {
                return NotFound();
            }

            return hkategoriBarang;
        }

        // PUT: api/LokasiKota/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kode}")]
        public async Task<ActionResult<LokasiKota>> PutLokasiKota(int kode, SaveLokasiKotaDto dto)
        {
            var lokasiKota = await _context.LokasiKota?.Where(e => e.Kode == kode).FirstOrDefaultAsync();
            if (lokasiKota == null)
            {
                return NotFound();
            }
            try
            {
                _mapper.Map(dto, lokasiKota);
                var result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(lokasiKota);
        }

        // POST: api/LokasiKota
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LokasiKota>> PostLokasiKota([FromBody] SaveLokasiKotaDto dto)
        {
            if (_context.LokasiKota == null)
            {
                return Problem("Entity set 'MyDbContext.LokasiKota'  is null.");
            }

            var lastKota = await _context.LokasiKota
                .OrderByDescending(e => e.Kode)
                .FirstOrDefaultAsync();
            var lokasiKota = _mapper.Map<LokasiKota>(dto);
            var user = (Masteruser)HttpContext.Items["User"];
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    lokasiKota.Kode = (sbyte)((lastKota?.Kode ?? 0) + 1);
                    _context.LokasiKota.Add(lokasiKota);

                    lokasiKota.Dump();

                    var logFile = new Logfile();
                    logFile.Keterangan = $"Tambah Master Provinsi {lokasiKota.Nama}";
                    logFile.Tanggal = DateTime.Now;
                    logFile.Username = user?.Kodeku ?? 0;
                    _context.Logfile.Add(logFile);
                    transaction.Commit();

                    return CreatedAtAction("GetLokasiKota", new { kode = lokasiKota.Kode }, lokasiKota);
                }
                catch (Exception ex)
                {
                    // If an exception occurs, roll back the transaction
                    transaction.Rollback();
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost("{kode}/coa")]
        public async Task<ActionResult<LokasiKota>> SetCoaLokasiKota(int kode, [FromBody] SetCoaLokasiKota dto)
        {
            if (_context.LokasiKota == null)
            {
                return Problem("Entity set 'MyDbContext.LokasiKota'  is null.");
            }

            var lastKota = await _context.LokasiKota
                .Where(e => e.Kode == kode)
                .FirstOrDefaultAsync();
            if (lastKota == null)
            {
                return BadRequest();
            }
            lastKota.Kodecoa4 = dto.KodeCoa4;
            await _context.SaveChangesAsync();
            return lastKota;
        }

        // DELETE: api/LokasiKota/5
        [HttpDelete("{kode}")]
        public async Task<IActionResult> DeleteLokasiKota(int kode)
        {
            if (_context.LokasiKota == null)
            {
                return NotFound();
            }
            var hkategoriBarang = await _context.LokasiKota.FindAsync(kode);
            if (hkategoriBarang == null)
            {
                return NotFound();
            }

            _context.LokasiKota.Remove(hkategoriBarang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //// DELETE: api/LokasiKota/5/restore
        //[HttpDelete("{kode}/restore")]
        //public async Task<ActionResult<LokasiKota>> RestoreLokasiKota(int kode)
        //{
        //    if (_context.LokasiKota == null)
        //    {
        //        return NotFound();
        //    }
        //    var hkategoriBarang = await _context.LokasiKota.FindAsync(kode);
        //    if (hkategoriBarang == null)
        //    {
        //        return NotFound();
        //    }

        //     await _context.RestoreSoftDeleteAsync<LokasiKota>(hkategoriBarang);

        //    return NoContent();
        //}
    }
}
