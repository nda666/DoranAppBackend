
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Models;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Dtos.Penyiaporder;
using AutoMapper;

namespace DoranOfficeBackend.Controller.PenyiaporderController
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    public class PenyiaporderController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public PenyiaporderController(IMapper mapper , MyDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Penyiaporder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Penyiaporder>>> GetPenyiaporder([FromQuery] FindPenyiaporderDto dto)
        {
          if (_context.Penyiaporder == null)
          {
              return NotFound();
          }
           
            var query = _context.Penyiaporder.AsNoTracking().AsQueryable();
            if (!String.IsNullOrEmpty(dto.Nama))
            {
                query = query.Where(r => EF.Functions.Like(r.Nama, $"%{dto.Nama}%"));
            }

            if (dto.Aktif.HasValue)
            {
                query = query.Where(r => r.Aktif == dto.Aktif);
            }


            return await query.ToListAsync();
        }

        // GET: api/Penyiaporder/5
        [HttpGet("{kode}")]
        public async Task<ActionResult<Penyiaporder>> GetPenyiaporder(int kode)
        {
          if (_context.Penyiaporder == null)
          {
              return NotFound();
          }
            var hkategoriBarang = await _context.Penyiaporder.FindAsync(kode);

            if (hkategoriBarang == null)
            {
                return NotFound();
            }

            return hkategoriBarang;
        }

        // PUT: api/Penyiaporder/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kode}")]
        public async Task<ActionResult<Penyiaporder>> PutPenyiaporder(int kode, SavePenyiaporderDto dto)
        {
            var penyiaporder = await _context.Penyiaporder?.Where(e => e.Kode == kode).FirstOrDefaultAsync();
            if (penyiaporder == null)
            {
                return NotFound();
            }
            try
            {
                _mapper.Map(dto, penyiaporder);
                var result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(penyiaporder);
        }

        // POST: api/Penyiaporder
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Penyiaporder>> PostPenyiaporder([FromBody] SavePenyiaporderDto dto)
        {
          if (_context.Penyiaporder == null)
          {
              return Problem("Entity set 'MyDbContext.Penyiaporder'  is null.");
          }
            var penyiaporder = _mapper.Map<Penyiaporder>(dto);
            _context.Penyiaporder.Add(penyiaporder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPenyiaporder", new { kode = penyiaporder.Kode }, penyiaporder);
        }

        // DELETE: api/Penyiaporder/5
        [HttpDelete("{kode}")]
        public async Task<IActionResult> DeletePenyiaporder(int kode)
        {
            if (_context.Penyiaporder == null)
            {
                return NotFound();
            }
            var hkategoriBarang = await _context.Penyiaporder.FindAsync(kode);
            if (hkategoriBarang == null)
            {
                return NotFound();
            }

            _context.Penyiaporder.Remove(hkategoriBarang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //// DELETE: api/Penyiaporder/5/restore
        //[HttpDelete("{kode}/restore")]
        //public async Task<ActionResult<Penyiaporder>> RestorePenyiaporder(int kode)
        //{
        //    if (_context.Penyiaporder == null)
        //    {
        //        return NotFound();
        //    }
        //    var hkategoriBarang = await _context.Penyiaporder.FindAsync(kode);
        //    if (hkategoriBarang == null)
        //    {
        //        return NotFound();
        //    }

        //     await _context.RestoreSoftDeleteAsync<Penyiaporder>(hkategoriBarang);

        //    return NoContent();
        //}
    }
}
