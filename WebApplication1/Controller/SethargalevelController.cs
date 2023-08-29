
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Models;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Dtos.Sethargalevel;
using AutoMapper;

namespace DoranOfficeBackend.Controller.SethargalevelController
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    public class SethargalevelController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public SethargalevelController(IMapper mapper , MyDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Sethargalevel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sethargalevel>>> GetSethargalevel([FromQuery] FindSethargalevelDto dto)
        {
          if (_context.Sethargalevel == null)
          {
              return NotFound();
          }
           
            var query = _context.Sethargalevel.AsNoTracking().AsQueryable();
            if (!String.IsNullOrEmpty(dto.Nama))
            {
                query = query.Where(r => EF.Functions.Like(r.Nama, $"%{dto.Nama}%"));
            }

            if (dto.Online.HasValue)
            {
                query = query.Where(e => e.Online == dto.Online);
            }

            if (dto.Modal.HasValue)
            {
                query = query.Where(e => e.Modal == dto.Modal);
            }

            return await query.ToListAsync();
        }

        // GET: api/Sethargalevel/5
        [HttpGet("{kodeh}")]
        public async Task<ActionResult<Sethargalevel>> GetSethargalevel(int kodeh)
        {
          if (_context.Sethargalevel == null)
          {
              return NotFound();
          }
            var hkategoriBarang = await _context.Sethargalevel.FindAsync(kodeh);

            if (hkategoriBarang == null)
            {
                return NotFound();
            }

            return hkategoriBarang;
        }

        // PUT: api/Sethargalevel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kode}")]
        public async Task<ActionResult<Sethargalevel>> PutSethargalevel(int kode, SaveSethargalevelDto dto)
        {
            var sethargalevel = await _context.Sethargalevel.Where(e => e.Kode == kode).FirstOrDefaultAsync();
            if (sethargalevel == null)
            {
                return NotFound();
            }
            try
            {
                _mapper.Map(dto, sethargalevel);
                var result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(sethargalevel);
        }

        // POST: api/Sethargalevel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sethargalevel>> PostSethargalevel([FromBody] SaveSethargalevelDto dto)
        {
          if (_context.Sethargalevel == null)
          {
              return Problem("Entity set 'MyDbContext.Sethargalevel'  is null.");
          }
            var sethargalevel = _mapper.Map<Sethargalevel>(dto);
            _context.Sethargalevel.Add(sethargalevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSethargalevel", new { kode = sethargalevel.Kode }, sethargalevel);
        }

        //// DELETE: api/Sethargalevel/5
        //[HttpDelete("{kodeh}")]
        //public async Task<IActionResult> DeleteSethargalevel(int kodeh)
        //{
        //    if (_context.Sethargalevel == null)
        //    {
        //        return NotFound();
        //    }
        //    var hkategoriBarang = await _context.Sethargalevel.FindAsync(kodeh);
        //    if (hkategoriBarang == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Sethargalevel.Remove(hkategoriBarang);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //// DELETE: api/Sethargalevel/5/restore
        //[HttpDelete("{kodeh}/restore")]
        //public async Task<ActionResult<Sethargalevel>> RestoreSethargalevel(int kodeh)
        //{
        //    if (_context.Sethargalevel == null)
        //    {
        //        return NotFound();
        //    }
        //    var hkategoriBarang = await _context.Sethargalevel.FindAsync(kodeh);
        //    if (hkategoriBarang == null)
        //    {
        //        return NotFound();
        //    }

        //     await _context.RestoreSoftDeleteAsync<Sethargalevel>(hkategoriBarang);

        //    return NoContent();
        //}
    }
}
