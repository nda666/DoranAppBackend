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
using DoranOfficeBackend.Dtos.Mastersupplier;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Attributes;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class MastersupplierController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public MastersupplierController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Mastersupplier
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mastersupplier>>> GetMastersupplier([FromQuery] FindMastersupplierDto dto)
        {
          if (_context.Mastersupplier == null)
          {
              return NotFound();
          }

            var query = _context.Mastersupplier
                    .AsNoTracking()
                    .AsQueryable();

            if (!String.IsNullOrWhiteSpace(dto.SupplierNama))
            {
                query = query.Where(x => x.SupplierNama.Contains(dto.SupplierNama));
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// GET list supplier aktif hanya nama dan kode saja, bisa digunakan untuk option dropdown.
        /// </summary>
        /// <returns>List supplier aktif hanya nama dan kode saja</returns>
        [HttpGet("options")]
        public async Task<ActionResult<List<MastersupplierOptionsDto>>> GetMastersupplierOptions()
        {
            var query = _context.Mastersupplier
                 .Where(e => e.SupplierAktif == 1)
                 .OrderBy(e => e.SupplierNama)
                 .Select(e => new MastersupplierOptionsDto {
                    SupplierNama = e.SupplierNama,
                    SupplierKode = e.SupplierKode,
                 });
            return await query.ToListAsync();
        }

        // GET: api/Mastersupplier/5
        [HttpGet("{kode}")]
        public async Task<ActionResult<Mastersupplier>> GetMastersupplier(int kode)
        {
          if (_context.Mastersupplier == null)
          {
              return NotFound();
          }
            var mastersupplier = await _context.Mastersupplier
                    .AsNoTracking()
                    .Where(x => x.SupplierKode == kode)
                    .FirstOrDefaultAsync();

            if (mastersupplier == null)
            {
                return NotFound();
            }

            return mastersupplier;
        }

        // PUT: api/Mastersupplier/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kode}")]
        public async Task<ActionResult<Mastersupplier>> PutMastersupplier(int kode, [FromBody] SaveMastersupplierDto dto)
        {

            var mastersupplier = await _context.Mastersupplier.FindAsync(kode);
            if (mastersupplier == null)
            {
                return NotFound();
            }

            try
            {
                _mapper.Map(dto, mastersupplier);
                var result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(mastersupplier);
        }

        // POST: api/Mastersupplier
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mastersupplier>> PostMastersupplier([FromBody] SaveMastersupplierDto dto)
        {
            if (_context.Sales == null)
            {
                return Problem("Entity set 'MyDbContext.Sales'  is null.");
            }

            var entity = _mapper.Map<Mastersupplier>(dto);
            _context.Mastersupplier.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMastersupplier", new { kode = entity.SupplierKode }, entity);
        }

        // DELETE: api/Mastersupplier/5
        [HttpDelete("{kode}")]
        public async Task<IActionResult> DeleteMastersupplier(int kode)
        {
            if (_context.Mastersupplier == null)
            {
                return NotFound();
            }
            var mastersupplier = await _context.Mastersupplier.FindAsync(kode);
            if (mastersupplier == null)
            {
                return NotFound();
            }

            _context.Mastersupplier.Remove(mastersupplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
