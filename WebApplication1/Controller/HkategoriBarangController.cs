
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Models;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Dtos.HkategoriBarang;
using AutoMapper;

namespace DoranOfficeBackend.Controller.HkategoriBarangsController
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    public class HkategoriBarangController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public HkategoriBarangController(IMapper mapper , MyDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/HkategoriBarangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hkategoribarang>>> GetHkategoriBarang([FromQuery] FindHkategoribarangDto dto)
        {
          if (_context.Hkategoribarangs == null)
          {
              return NotFound();
          }
           
            var query = _context.Hkategoribarangs.AsNoTracking().AsQueryable();
            if (!String.IsNullOrEmpty(dto.Nama))
            {
                query = query.Where(r => EF.Functions.Like(r.Nama, $"%{dto.Nama}%"));
            }

            if (dto.Aktif.HasValue)
            {
                query = query.Where(r => r.Aktif == dto.Aktif);
            }

            if (dto.Deleted.HasValue)
            {
                query = dto.Deleted == true ? query.WhereDeleted() : query;
            }
            else
            {
                query = query.WhereNotDeleted();
            }
            query = query.OrderByDescending(x => x.CreatedAt);

            return await query.ToListAsync();
        }

        // GET: api/HkategoriBarangs/5
        [HttpGet("{kodeh}")]
        public async Task<ActionResult<Hkategoribarang>> GetHkategoriBarang(int kodeh)
        {
          if (_context.Hkategoribarangs == null)
          {
              return NotFound();
          }
            var hkategoriBarang = await _context.Hkategoribarangs.FindAsync(kodeh);

            if (hkategoriBarang == null)
            {
                return NotFound();
            }

            return hkategoriBarang;
        }

        // PUT: api/HkategoriBarangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kodeh}")]
        public async Task<ActionResult<Hkategoribarang>> PutHkategoriBarang(int kodeh, SaveHkategoribarangDto dto)
        {
            var hkategoribarang = await _context.Hkategoribarangs?.Where(e => e.Kodeh == kodeh).FirstOrDefaultAsync();
            if (hkategoribarang == null)
            {
                return NotFound();
            }
            try
            {
                _mapper.Map(dto, hkategoribarang);
                var result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(hkategoribarang);
        }

        // POST: api/HkategoriBarangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hkategoribarang>> PostHkategoriBarang([FromBody] SaveHkategoribarangDto dto)
        {
          if (_context.Hkategoribarangs == null)
          {
              return Problem("Entity set 'MyDbContext.HkategoriBarang'  is null.");
          }
            var hkategoribarang = _mapper.Map<Hkategoribarang>(dto);
            _context.Hkategoribarangs.Add(hkategoribarang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHkategoriBarang", new { kodeh = hkategoribarang.Kodeh }, hkategoribarang);
        }

        // DELETE: api/HkategoriBarangs/5
        [HttpDelete("{kodeh}")]
        public async Task<IActionResult> DeleteHkategoriBarang(int kodeh)
        {
            if (_context.Hkategoribarangs == null)
            {
                return NotFound();
            }
            var hkategoriBarang = await _context.Hkategoribarangs.FindAsync(kodeh);
            if (hkategoriBarang == null)
            {
                return NotFound();
            }

            _context.Hkategoribarangs.Remove(hkategoriBarang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/HkategoriBarangs/5/restore
        [HttpDelete("{kodeh}/restore")]
        public async Task<ActionResult<Hkategoribarang>> RestoreHkategoriBarang(int kodeh)
        {
            if (_context.Hkategoribarangs == null)
            {
                return NotFound();
            }
            var hkategoriBarang = await _context.Hkategoribarangs.FindAsync(kodeh);
            if (hkategoriBarang == null)
            {
                return NotFound();
            }

             await _context.RestoreSoftDeleteAsync<Hkategoribarang>(hkategoriBarang);

            return NoContent();
        }
    }
}
