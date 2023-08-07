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
using DoranOfficeBackend.Dtos.Masterdivisi;
using DoranOfficeBackend.Extentsions;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterdivisiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public MasterdivisiController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Masterdivisi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Masterdivisi>>> GetMasterdivisi([FromQuery] FindMasterdivisiDto dto)
        {
          if (_context.Masterdivisi == null)
          {
              return NotFound();
          }

            var query = _context.Masterdivisi.AsNoTracking()
                     .AsQueryable();

            if (!String.IsNullOrWhiteSpace(dto.Nama))
            {
                 query = query.Where(x => x.Nama.Contains(x.Nama));
            }

            if (dto.Deleted == true)
            {
                query = query.WhereDeleted();
            }
            else
            {
                query = query.WhereNotDeleted();
            }

            return await _context.Masterdivisi.ToListAsync();
        }

        // GET: api/Masterdivisi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Masterdivisi>> GetMasterdivisi(int id)
        {
          if (_context.Masterdivisi == null)
          {
              return NotFound();
          }
            var masterdivisi = await _context.Masterdivisi.FindAsync(id);

            if (masterdivisi == null)
            {
                return NotFound();
            }

            return masterdivisi;
        }

        // PUT: api/Masterdivisi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kode}")]
        public async Task<ActionResult<Masterdivisi>> PutMasterdivisi(int kode, [FromBody] SaveMasterdivisiDto dto)
        {

            var masterdivisi = await _context.Masterdivisi.FindAsync(kode);
            if (masterdivisi == null)
            {
                return NotFound();
            }

            try
            {
                _mapper.Map(dto, masterdivisi);
                var result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(masterdivisi);
        }

        // POST: api/Masterdivisi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Masterdivisi>> PostMasterdivisi([FromBody] SaveMasterdivisiDto dto)
        {
            if (_context.Sales == null)
            {
                return Problem("Entity set 'MyDbContext.Sales'  is null.");
            }

            var entity = _mapper.Map<Masterdivisi>(dto);
            _context.Masterdivisi.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasterdivisi", new { id = entity.Id }, entity);
        }

        // DELETE: api/Masterdivisi/5
        [HttpDelete("{kode}")]
        public async Task<IActionResult> DeleteMasterdivisi(int kode)
        {
            if (_context.Masterdivisi == null)
            {
                return NotFound();
            }
            var masterdivisi = await _context.Masterdivisi.FindAsync(kode);
            if (masterdivisi == null)
            {
                return NotFound();
            }

            _context.Masterdivisi.Remove(masterdivisi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{kode}/restore")]
        public async Task<ActionResult<Masterdivisi>> RestoreDeleteMasterdivisi(int kode)
        {
            if (_context.Masterdivisi == null)
            {
                return NotFound();
            }
            var masterdivisi = await _context.Masterdivisi.FindAsync(kode);
            if (masterdivisi == null)
            {
                return NotFound();
            }

            await _context.RestoreSoftDeleteAsync<Masterdivisi>(masterdivisi);

            return Ok(masterdivisi);
        }
    }
}
