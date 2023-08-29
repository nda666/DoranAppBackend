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
using DoranOfficeBackend.Dtos.Hkelompokbarang;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Exceptions;
using DoranOfficeBackend.Attributes;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class HkelompokbarangController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public HkelompokbarangController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Hkelompokbarang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hkelompokbarang>>> GetHkelompokbarangByKode([FromQuery] FindHkelompokbarangDto dto)
        {
            if (_context.Hkelompokbarang == null)
            {
                return NotFound();
            }

            var query = _context.Hkelompokbarang
                    .AsNoTracking()
                    .AsQueryable();

            if (!String.IsNullOrWhiteSpace(dto.Nama))
            {
                query = query.Where(x => x.Nama.Contains(dto.Nama));
            }

            if (dto.Aktif.HasValue)
            {
                query = query.Where(x => x.Aktif == dto.Aktif);
            }

            if (dto.Deleted == true)
            {
                query = query.WhereDeleted();
            }
            else
            {
                query = query.WhereNotDeleted();
            }

            return await query.ToListAsync();
        }

        // GET: api/Hkelompokbarang/5
        [HttpGet("{kode}")]
        public async Task<ActionResult<Hkelompokbarang>> GetHkelompokbarang(int kode)
        {
            if (_context.Hkelompokbarang == null)
            {
                return NotFound();
            }
            var hkelompokbarang = await _context.Hkelompokbarang
                    .AsNoTracking()
                    .Where(x => x.Kode == kode)
                    .FirstOrDefaultAsync();

            if (hkelompokbarang == null)
            {
                return NotFound();
            }

            return hkelompokbarang;
        }

        // PUT: api/Hkelompokbarang/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kode}")]
        public async Task<ActionResult<Hkelompokbarang>> PutHkelompokbarang(int kode, [FromBody] SaveHkelompokbarangDto dto)
        {

            var hkelompokbarang = await _context.Hkelompokbarang.FindAsync(kode);
            if (hkelompokbarang == null)
            {
                return NotFound();
            }

            try
            {
                _mapper.Map(dto, hkelompokbarang);
                var result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(hkelompokbarang);
        }

        // POST: api/Hkelompokbarang
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hkelompokbarang>> PostHkelompokbarang([FromBody] SaveHkelompokbarangDto dto)
        {
            if (_context.Hkelompokbarang == null)
            {
                return Problem("Entity set 'MyDbContext.Hkelompokbarang'  is null.");
            }

            var entity = _mapper.Map<Hkelompokbarang>(dto);
            _context.Hkelompokbarang.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHkelompokbarangByKode", new { id = entity.Id }, entity);
        }

        // DELETE: api/Hkelompokbarang/5
        [HttpDelete("{kode}")]
        public async Task<IActionResult> DeleteHkelompokbarang(int kode)
        {
            if (_context.Hkelompokbarang == null)
            {
                return NotFound();
            }
            var hkelompokbarang = await checkHkelompokbarang(kode);

            _context.Hkelompokbarang.Remove(hkelompokbarang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{kode}/restore")]
        public async Task<ActionResult<Hkelompokbarang>> RestoreDeleteHkelompokbarang(int kode)
        {
            if (_context.Hkelompokbarang == null)
            {
                return NotFound();
            }
            var hkelompokbarang = await checkHkelompokbarang(kode);

            await _context.RestoreSoftDeleteAsync<Hkelompokbarang>(hkelompokbarang);

            return Ok(hkelompokbarang);
        }

        private async Task<Hkelompokbarang> checkHkelompokbarang(int kode)
        {
            var hkelompokbarang = await _context.Hkelompokbarang.FindAsync(kode);
            if (hkelompokbarang == null)
            {
                throw new NotFoundException("Master gudang not found.");
            }
            return hkelompokbarang;
        }
    }
}
