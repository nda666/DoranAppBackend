using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Entities;
using Microsoft.AspNetCore.Authorization;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Entities.Extentsions;

namespace DoranOfficeBackend.Controller.HkategoriBarangsController
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    public class HkategoriBarangsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public HkategoriBarangsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/HkategoriBarangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entities.HkategoriBarang>>> GetHkategoriBarang([FromQuery] Dto.GetQuery getQuery)
        {
          if (_context.HkategoriBarang == null)
          {
              return NotFound();
          }
            var query = _context.HkategoriBarang.AsNoTracking().AsQueryable();
            if (!String.IsNullOrEmpty(getQuery.Name))
            {
                query = query.Where(r => EF.Functions.Like(r.nama, $"%{getQuery.Name}%"));
            }

            if (!string.IsNullOrEmpty(getQuery.Deleted))
            {
                query = query.WhereDeleted();
            }
            else
            {
                query = query.WhereNotDeleted();
            }
            query = query.OrderByDescending(x => x.CreatedAt);

            return await query.ToListAsync();
        }

        // GET: api/HkategoriBarangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entities.HkategoriBarang>> GetHkategoriBarang(Guid? id)
        {
          if (_context.HkategoriBarang == null)
          {
              return NotFound();
          }
            var hkategoriBarang = await _context.HkategoriBarang.FindAsync(id);

            if (hkategoriBarang == null)
            {
                return NotFound();
            }

            return hkategoriBarang;
        }

        // PUT: api/HkategoriBarangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHkategoriBarang(Guid? id, HkategoriBarang hkategoriBarang)
        {
            if (id != hkategoriBarang.id)
            {
                return BadRequest();
            }

            _context.Entry(hkategoriBarang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HkategoriBarangExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HkategoriBarangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HkategoriBarang>> PostHkategoriBarang([FromBody] HkategoriBarang hkategoriBarang)
        {
          if (_context.HkategoriBarang == null)
          {
              return Problem("Entity set 'MyDbContext.HkategoriBarang'  is null.");
          }
            hkategoriBarang.aktif = hkategoriBarang.aktif == null ? true : hkategoriBarang.aktif;
            _context.HkategoriBarang.Add(hkategoriBarang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHkategoriBarang", new { id = hkategoriBarang.id }, hkategoriBarang);
        }

        // DELETE: api/HkategoriBarangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHkategoriBarang(Guid? id)
        {
            if (_context.HkategoriBarang == null)
            {
                return NotFound();
            }
            var hkategoriBarang = await _context.HkategoriBarang.FindAsync(id);
            if (hkategoriBarang == null)
            {
                return NotFound();
            }

            _context.HkategoriBarang.Remove(hkategoriBarang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HkategoriBarangExists(Guid? id)
        {
            return (_context.HkategoriBarang?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
