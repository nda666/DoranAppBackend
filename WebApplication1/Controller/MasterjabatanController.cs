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
using DoranOfficeBackend.Dtos.Masterjabatan;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Attributes;
using ConsoleDump;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class MasterjabatanController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public MasterjabatanController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Masterjabatan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Masterjabatan>>> GetMasterjabatan([FromQuery] FindMasterjabatanDto dto)
        {
          if (_context.Masterjabatan == null)
          {
              return NotFound();
          }

            var query = _context.Masterjabatan
                    .AsNoTracking()
                    .Include(x => x.Masterpegawais)
                    .AsQueryable();

            if (!String.IsNullOrWhiteSpace(dto.Nama))
            {
                 query = query.Where(x => x.Nama.Contains(dto.Nama));
            }

            //if (dto.Deleted == true)
            //{
            //    query = query.WhereDeleted();
            //}
            //else
            //{
            //    query = query.WhereNotDeleted();
            //}

            return await query.ToListAsync();
        }

        // GET: api/Masterjabatan/5
        [HttpGet("{kode}")]
        public async Task<ActionResult<Masterjabatan>> GetMasterjabatan(int kode)
        {
          if (_context.Masterjabatan == null)
          {
              return NotFound();
          }
            var masterjabatan = await _context.Masterjabatan
                    .Include(x => x.Masterpegawais)
                    .AsNoTracking()
                    .Where(x => x.Kode == kode)
                    .FirstOrDefaultAsync();

            if (masterjabatan == null)
            {
                return NotFound();
            }

            return masterjabatan;
        }

        // PUT: api/Masterjabatan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kode}")]
        public async Task<ActionResult<Masterjabatan>> PutMasterjabatan(int kode, [FromBody] SaveMasterjabatanDto dto)
        {

            var masterjabatan = await _context.Masterjabatan.FindAsync(kode);
            if (masterjabatan == null)
            {
                return NotFound();
            }

            try
            {
                _mapper.Map(dto, masterjabatan);
                var result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(masterjabatan);
        }

        // POST: api/Masterjabatan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Masterjabatan>> PostMasterjabatan([FromBody] SaveMasterjabatanDto dto)
        {
            if (_context.Sales == null)
            {
                return Problem("Entity set 'MyDbContext.Sales'  is null.");
            }

            var entity = _mapper.Map<Masterjabatan>(dto);
            _context.Masterjabatan.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasterjabatan", new { kode = entity.Kode }, entity);
        }

        // DELETE: api/Masterjabatan/5
        [HttpDelete("{kode}")]
        public async Task<IActionResult> DeleteMasterjabatan(int kode)
        {
            if (_context.Masterjabatan == null)
            {
                return NotFound();
            }
            var masterjabatan = await _context.Masterjabatan.FindAsync(kode);
            if (masterjabatan == null)
            {
                return NotFound();
            }

            _context.Masterjabatan.Remove(masterjabatan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpDelete("{kode}/restore")]
        //public async Task<ActionResult<Masterjabatan>> RestoreDeleteMasterjabatan(int kode)
        //{
        //    if (_context.Masterjabatan == null)
        //    {
        //        return NotFound();
        //    }
        //    var masterjabatan = await _context.Masterjabatan.FindAsync(kode);
        //    if (masterjabatan == null)
        //    {
        //        return NotFound();
        //    }

        //    await _context.RestoreSoftDeleteAsync<Masterjabatan>(masterjabatan);

        //    return Ok(masterjabatan);
        //}
    }
}
