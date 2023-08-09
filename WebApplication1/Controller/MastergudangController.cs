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
using DoranOfficeBackend.Dtos.Mastergudang;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Exceptions;
using DoranOfficeBackend.Attributes;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastergudangController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public MastergudangController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Mastergudang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mastergudang>>> GetMastergudangByKode([FromQuery] FindMastergudangDto dto)
        {
          if (_context.Mastergudang == null)
          {
              return NotFound();
          }

            var query = _context.Mastergudang
                    .AsNoTracking()
                    .AsQueryable();

            if (!String.IsNullOrWhiteSpace(dto.Nama))
            {
                 query = query.Where(x => x.Nama.Contains(dto.Nama));
            }

            if (dto.Urut.HasValue)
            {
                query = query.Where(x => x.Urut == dto.Urut);
            }

            if (dto.Boletransit.HasValue)
            {
                query = query.Where(x => x.Boletransit == dto.Boletransit);
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

        // GET: api/Mastergudang/5
        [HttpGet("{kode}")]
        public async Task<ActionResult<Mastergudang>> GetMastergudang(int kode)
        {
          if (_context.Mastergudang == null)
          {
              return NotFound();
          }
            var mastergudang = await _context.Mastergudang
                    .AsNoTracking()
                    .Where(x => x.Kode == kode)
                    .FirstOrDefaultAsync();

            if (mastergudang == null)
            {
                return NotFound();
            }

            return mastergudang;
        }

        // PUT: api/Mastergudang/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kode}")]
        public async Task<ActionResult<Mastergudang>> PutMastergudang(int kode, [FromBody] SaveMastergudangDto dto)
        {

            var mastergudang = await _context.Mastergudang.FindAsync(kode);
            if (mastergudang == null)
            {
                return NotFound();
            }

            try
            {
                _mapper.Map(dto, mastergudang);
                var result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(mastergudang);
        }

        // POST: api/Mastergudang
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mastergudang>> PostMastergudang([FromBody] SaveMastergudangDto dto)
        {
            if (_context.Mastergudang == null)
            {
                return Problem("Entity set 'MyDbContext.Mastergudang'  is null.");
            }

            var entity = _mapper.Map<Mastergudang>(dto);
            _context.Mastergudang.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMastergudangByKode", new { id = entity.Id }, entity);
        }

        // POST: api/Mastergudang/{kode}/set-active
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{kode}/aktif")]
        public async Task<ActionResult<Mastergudang>> PostSetAktifMasterGudang(int kode, [FromBody] SetAktifMastergudangDto dto)
        {
            if (_context.Mastergudang == null)
            {
                return Problem("Entity set 'MyDbContext.Mastergudang'  is null.");
            }

            var mastergudang = await checkMastergudang(kode);

            mastergudang.Aktif = dto.Aktif;
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMastergudangByKode", new { id = mastergudang.Id }, mastergudang);
        }

        // POST: api/Mastergudang/{kode}/transit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{kode}/transit")]
        public async Task<ActionResult<Mastergudang>> PostSetTransitMasterGudang(int kode, [FromBody] SetTranstirMastergudangDto dto)
        {
            if (_context.Mastergudang == null)
            {
                return Problem("Entity set 'MyDbContext.Mastergudang'  is null.");
            }

            var mastergudang = await checkMastergudang(kode);

            mastergudang.Boletransit = dto.Boletransit;
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMastergudangByKode", new { id = mastergudang.Id }, mastergudang);
        }

        // DELETE: api/Mastergudang/5
        [HttpDelete("{kode}")]
        public async Task<IActionResult> DeleteMastergudang(int kode)
        {
            if (_context.Mastergudang == null)
            {
                return NotFound();
            }
            var mastergudang = await checkMastergudang(kode);

            _context.Mastergudang.Remove(mastergudang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{kode}/restore")]
        public async Task<ActionResult<Mastergudang>> RestoreDeleteMastergudang(int kode)
        {
            if (_context.Mastergudang == null)
            {
                return NotFound();
            }
            var mastergudang = await checkMastergudang(kode);

            await _context.RestoreSoftDeleteAsync<Mastergudang>(mastergudang);

            return Ok(mastergudang);
        }

        private async Task<Mastergudang> checkMastergudang(int kode)
        {
            var mastergudang = await _context.Mastergudang.FindAsync(kode);
            if (mastergudang == null)
            {
                throw new NotFoundException("Master gudang not found.");
            }
            return mastergudang;
        }
    }
}
