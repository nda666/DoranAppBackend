
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Models;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Dtos.LokasiKota;
using AutoMapper;

namespace DoranOfficeBackend.Controller.LokasiKotaController
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    public class LokasiKotaController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public LokasiKotaController(IMapper mapper , MyDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/LokasiKota
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LokasiKota>>> GetLokasiKota([FromQuery] FindLokasiKotaDto dto)
        {
          if (_context.LokasiKota == null)
          {
              return NotFound();
          }
           
            var query = _context.LokasiKota.AsNoTracking().AsQueryable();
            if (!String.IsNullOrEmpty(dto.Nama))
            {
                query = query.Where(r => EF.Functions.Like(r.Nama, $"%{dto.Nama}%"));
            }


            return await query.ToListAsync();
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
            var lokasiKota = _mapper.Map<LokasiKota>(dto);
            _context.LokasiKota.Add(lokasiKota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLokasiKota", new { kode = lokasiKota.Kode }, lokasiKota);
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
