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
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Exceptions;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Dtos.Masterbarang;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class MasterbarangController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public MasterbarangController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private IQueryable<Masterbarang> baseSelect(FindMasterbarangDto dto)
        {

            var query = _context.Masterbarang
                    .AsNoTracking()
                    .AsQueryable();

            if (!String.IsNullOrWhiteSpace(dto.BrgNama))
            {
                query = query.Where(x => x.BrgNama.Contains(dto.BrgNama));
            }

            if (dto.BrgAktif.HasValue)
            {
                query = query.Where(x => x.BrgAktif == dto.BrgAktif);
            }

            if (dto.Shownya == true)
            {
                query = query.Where(x => x.Mastertipebarang.Shownya == 1);
            }

            return query;
        }

        // GET: api/Masterbarang
        [HttpGet("options", Name = "GetMasterbarangOptions")]
        public async Task<ActionResult<IEnumerable<MasterbarangOptionWithSnDto>>> GetMasterbarangOptions([FromQuery] FindMasterbarangDto dto)
        {
            if (_context.Masterbarang == null)
            {
                return NotFound();
            }

            var query = baseSelect(dto)
                .Include(x => x.Dkategoribarang)
                .Include(x => x.Mastertipebarang)
                .OrderBy(e => e.BrgNama)
                .Select(e => new MasterbarangOptionWithSnDto
                {
                    BrgKode = e.BrgKode,
                    BrgNama = e.BrgNama,
                    Sn = e.Dkategoribarang != null ? e.Dkategoribarang.Sn : false,
                    JurnalBiaya = e.JurnalBiaya,
                    Shownya = e.Mastertipebarang.Shownya
                });
            return await query.ToListAsync();
        }

        [HttpGet("nama", Name = "GetMasterbarangNama")]
        public async Task<ActionResult> GetMasterbarangNama([FromQuery] FindMasterbarangDto dto)
        {
            if (_context.Masterbarang == null)
            {
                return NotFound();
            }

            var baseQuery =  baseSelect(dto);
            var data = await baseQuery.Select(x => new { x.BrgKode, x.BrgNama }).ToListAsync();

            return Ok(data);
        }

        //// GET: api/Masterbarang/5
        //[HttpGet("{kode}")]
        //public async Task<ActionResult<Masterbarang>> GetMasterbarang(int kode)
        //{
        //  if (_context.Masterbarang == null)
        //  {
        //      return NotFound();
        //  }
        //    var masterbarang = await _context.Masterbarang
        //            .AsNoTracking()
        //            .Where(x => x.Kode == kode)
        //            .FirstOrDefaultAsync();

        //    if (masterbarang == null)
        //    {
        //        return NotFound();
        //    }

        //    return masterbarang;
        //}

        //// PUT: api/Masterbarang/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{kode}")]
        //public async Task<ActionResult<Masterbarang>> PutMasterbarang(int kode, [FromBody] SaveMasterbarangDto dto)
        //{

        //    var masterbarang = await _context.Masterbarang.FindAsync(kode);
        //    if (masterbarang == null)
        //    {
        //        return NotFound();
        //    }

        //    try
        //    {
        //        _mapper.Map(dto, masterbarang);
        //        var result = await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }

        //    return Ok(masterbarang);
        //}

        //// POST: api/Masterbarang
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Masterbarang>> PostMasterbarang([FromBody] SaveMasterbarangDto dto)
        //{
        //    if (_context.Masterbarang == null)
        //    {
        //        return Problem("Entity set 'MyDbContext.Masterbarang'  is null.");
        //    }

        //    var entity = _mapper.Map<Masterbarang>(dto);
        //    _context.Masterbarang.Add(entity);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMasterbarangByKode", new { id = entity.Id }, entity);
        //}

        //// POST: api/Masterbarang/{kode}/set-active
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("{kode}/aktif")]
        //public async Task<ActionResult<Masterbarang>> PostSetAktifMasterGudang(int kode, [FromBody] SetAktifMasterbarangDto dto)
        //{
        //    if (_context.Masterbarang == null)
        //    {
        //        return Problem("Entity set 'MyDbContext.Masterbarang'  is null.");
        //    }

        //    var masterbarang = await checkMasterbarang(kode);

        //    masterbarang.Aktif = dto.Aktif;
        //    ConsoleDump.Extensions.Dump(dto, "ACCCCC");
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction("GetMasterbarangByKode", new { id = masterbarang.Id }, masterbarang);
        //}

        //// POST: api/Masterbarang/{kode}/transit
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("{kode}/transit")]
        //public async Task<ActionResult<Masterbarang>> PostSetTransitMasterGudang(int kode, [FromBody] SetTranstirMasterbarangDto dto)
        //{
        //    if (_context.Masterbarang == null)
        //    {
        //        return Problem("Entity set 'MyDbContext.Masterbarang'  is null.");
        //    }

        //    var masterbarang = await checkMasterbarang(kode);

        //    masterbarang.Boletransit = dto.Boletransit;
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction("GetMasterbarangByKode", new { id = masterbarang.Id }, masterbarang);
        //}

        //// DELETE: api/Masterbarang/5
        //[HttpDelete("{kode}")]
        //public async Task<IActionResult> DeleteMasterbarang(int kode)
        //{
        //    if (_context.Masterbarang == null)
        //    {
        //        return NotFound();
        //    }
        //    var masterbarang = await checkMasterbarang(kode);

        //    _context.Masterbarang.Remove(masterbarang);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{kode}/restore")]
        //public async Task<ActionResult<Masterbarang>> RestoreDeleteMasterbarang(int kode)
        //{
        //    if (_context.Masterbarang == null)
        //    {
        //        return NotFound();
        //    }
        //    var masterbarang = await checkMasterbarang(kode);

        //    await _context.RestoreSoftDeleteAsync<Masterbarang>(masterbarang);

        //    return Ok(masterbarang);
        //}

        private async Task<Masterbarang> checkMasterbarang(int kode)
        {
            var masterbarang = await _context.Masterbarang.FindAsync(kode);
            if (masterbarang == null)
            {
                throw new NotFoundException("Master gudang not found.");
            }
            return masterbarang;
        }
    }
}
