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
using DoranOfficeBackend.Dtos.Masterpelanggan;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class MasterpelangganController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public MasterpelangganController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IQueryable<Masterpelanggan> baseSelect(FindMasterpelangganDto dto)
        {

            var query = _context.Masterpelanggan
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
            return query;
        }

        // GET: api/Masterpelanggan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Masterpelanggan>>> GetMasterpelanggan([FromQuery] FindMasterpelangganDto dto)
        {
            if (_context.Masterpelanggan == null)
            {
                return NotFound();
            }

            var query = baseSelect(dto);

            return await query.ToListAsync();
        }

        [HttpGet("nama")]
        public async Task<ActionResult> GetMasterpelangganNama([FromQuery] FindMasterpelangganDto dto)
        {
            if (_context.Masterpelanggan == null)
            {
                return NotFound();
            }

            var baseQuery =  baseSelect(dto);
            var data = await baseQuery
                .OrderBy(x => x.Nama)
                .Select(x => new { 
                Nama = $"{x.Nama} - {(x.LokasiKota != null ? x.LokasiKota.Nama :  "Unknown Kota")} ",
                x.Kode })
                .ToListAsync();
            return Ok(data);
        }

        //// GET: api/Masterpelanggan/5
        //[HttpGet("{kode}")]
        //public async Task<ActionResult<Masterpelanggan>> GetMasterpelanggan(int kode)
        //{
        //  if (_context.Masterpelanggan == null)
        //  {
        //      return NotFound();
        //  }
        //    var masterpelanggan = await _context.Masterpelanggan
        //            .AsNoTracking()
        //            .Where(x => x.Kode == kode)
        //            .FirstOrDefaultAsync();

        //    if (masterpelanggan == null)
        //    {
        //        return NotFound();
        //    }

        //    return masterpelanggan;
        //}

        //// PUT: api/Masterpelanggan/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{kode}")]
        //public async Task<ActionResult<Masterpelanggan>> PutMasterpelanggan(int kode, [FromBody] SaveMasterpelangganDto dto)
        //{

        //    var masterpelanggan = await _context.Masterpelanggan.FindAsync(kode);
        //    if (masterpelanggan == null)
        //    {
        //        return NotFound();
        //    }

        //    try
        //    {
        //        _mapper.Map(dto, masterpelanggan);
        //        var result = await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }

        //    return Ok(masterpelanggan);
        //}

        //// POST: api/Masterpelanggan
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Masterpelanggan>> PostMasterpelanggan([FromBody] SaveMasterpelangganDto dto)
        //{
        //    if (_context.Masterpelanggan == null)
        //    {
        //        return Problem("Entity set 'MyDbContext.Masterpelanggan'  is null.");
        //    }

        //    var entity = _mapper.Map<Masterpelanggan>(dto);
        //    _context.Masterpelanggan.Add(entity);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMasterpelangganByKode", new { id = entity.Id }, entity);
        //}

        //// POST: api/Masterpelanggan/{kode}/set-active
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("{kode}/aktif")]
        //public async Task<ActionResult<Masterpelanggan>> PostSetAktifMasterGudang(int kode, [FromBody] SetAktifMasterpelangganDto dto)
        //{
        //    if (_context.Masterpelanggan == null)
        //    {
        //        return Problem("Entity set 'MyDbContext.Masterpelanggan'  is null.");
        //    }

        //    var masterpelanggan = await checkMasterpelanggan(kode);

        //    masterpelanggan.Aktif = dto.Aktif;
        //    ConsoleDump.Extensions.Dump(dto, "ACCCCC");
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction("GetMasterpelangganByKode", new { id = masterpelanggan.Id }, masterpelanggan);
        //}

        //// POST: api/Masterpelanggan/{kode}/transit
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("{kode}/transit")]
        //public async Task<ActionResult<Masterpelanggan>> PostSetTransitMasterGudang(int kode, [FromBody] SetTranstirMasterpelangganDto dto)
        //{
        //    if (_context.Masterpelanggan == null)
        //    {
        //        return Problem("Entity set 'MyDbContext.Masterpelanggan'  is null.");
        //    }

        //    var masterpelanggan = await checkMasterpelanggan(kode);

        //    masterpelanggan.Boletransit = dto.Boletransit;
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction("GetMasterpelangganByKode", new { id = masterpelanggan.Id }, masterpelanggan);
        //}

        //// DELETE: api/Masterpelanggan/5
        //[HttpDelete("{kode}")]
        //public async Task<IActionResult> DeleteMasterpelanggan(int kode)
        //{
        //    if (_context.Masterpelanggan == null)
        //    {
        //        return NotFound();
        //    }
        //    var masterpelanggan = await checkMasterpelanggan(kode);

        //    _context.Masterpelanggan.Remove(masterpelanggan);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{kode}/restore")]
        //public async Task<ActionResult<Masterpelanggan>> RestoreDeleteMasterpelanggan(int kode)
        //{
        //    if (_context.Masterpelanggan == null)
        //    {
        //        return NotFound();
        //    }
        //    var masterpelanggan = await checkMasterpelanggan(kode);

        //    await _context.RestoreSoftDeleteAsync<Masterpelanggan>(masterpelanggan);

        //    return Ok(masterpelanggan);
        //}

        private async Task<Masterpelanggan> checkMasterpelanggan(int kode)
        {
            var masterpelanggan = await _context.Masterpelanggan.FindAsync(kode);
            if (masterpelanggan == null)
            {
                throw new NotFoundException("Master gudang not found.");
            }
            return masterpelanggan;
        }
    }
}
