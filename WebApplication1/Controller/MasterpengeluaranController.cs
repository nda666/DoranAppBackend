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
using DoranOfficeBackend.Dtos.Masterpengeluaran;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Exceptions;
using DoranOfficeBackend.Attributes;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class MasterpengeluaranController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public MasterpengeluaranController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Masterpengeluaran
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Masterpengeluaran>>> GetMasterpengeluaranByKode([FromQuery] FindMasterpengeluaranDto dto)
        {
          if (_context.Masterpengeluaran == null)
          {
              return NotFound();
          }

            var query = _context.Masterpengeluaran
                    .AsNoTracking()
                    .AsQueryable();

            if (!String.IsNullOrWhiteSpace(dto.Nama))
            {
                 query = query.Where(x => x.Nama.Contains(dto.Nama));
            }

            if (dto.Cargo.HasValue)
            {
                query = query.Where(x => x.Cargo == dto.Cargo);
            }

            if (dto.Aktif.HasValue)
            {
                query = query.Where(x => x.Aktif == dto.Aktif);
            }
         

            return await query.ToListAsync();
        }

        [HttpGet("ekspedisi")]
        public async Task<ActionResult<IEnumerable<Masterpengeluaran>>> GetEkspedisi()
        {
            if (_context.Masterpengeluaran == null)
            {
                return NotFound();
            }

            var query = _context.Masterpengeluaran
                    .AsNoTracking()
                    .AsQueryable()
                    .Where(x => x.Cargo == true)
                    .Where(x => x.Aktif == true)
                    .OrderBy(x => x.Nama);

            return await query.ToListAsync();
        }

        // GET: api/Masterpengeluaran/5
        [HttpGet("{kode}")]
        public async Task<ActionResult<Masterpengeluaran>> GetMasterpengeluaran(int kode)
        {
          if (_context.Masterpengeluaran == null)
          {
              return NotFound();
          }
            var masterpengeluaran = await _context.Masterpengeluaran
                    .AsNoTracking()
                    .Where(x => x.Kode == kode)
                    .FirstOrDefaultAsync();

            if (masterpengeluaran == null)
            {
                return NotFound();
            }

            return masterpengeluaran;
        }

        

        // PUT: api/Masterpengeluaran/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kode}")]
        public async Task<ActionResult<Masterpengeluaran>> PutMasterpengeluaran(int kode, [FromBody] SaveMasterpengeluaranDto dto)
        {

            var masterpengeluaran = await _context.Masterpengeluaran.FindAsync(kode);
            if (masterpengeluaran == null)
            {
                return NotFound();
            }

            try
            {
                _mapper.Map(dto, masterpengeluaran);
                var result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(masterpengeluaran);
        }

        // POST: api/Masterpengeluaran
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Masterpengeluaran>> PostMasterpengeluaran([FromBody] SaveMasterpengeluaranDto dto)
        {
            if (_context.Masterpengeluaran == null)
            {
                return Problem("Entity set 'MyDbContext.Masterpengeluaran'  is null.");
            }

            var entity = _mapper.Map<Masterpengeluaran>(dto);
            _context.Masterpengeluaran.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasterpengeluaranByKode", new { Kode = entity.Kode }, entity);
        }

        // POST: api/Masterpengeluaran/{kode}/set-active
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{kode}/aktif")]
        public async Task<ActionResult<Masterpengeluaran>> PostSetAktifMasterGudang(int kode, [FromBody] SetAktifMasterpengeluaranDto dto)
        {
            if (_context.Masterpengeluaran == null)
            {
                return Problem("Entity set 'MyDbContext.Masterpengeluaran'  is null.");
            }

            var masterpengeluaran = await checkMasterpengeluaran(kode);

            masterpengeluaran.Aktif = dto.Aktif;
            ConsoleDump.Extensions.Dump(dto, "ACCCCC");
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMasterpengeluaranByKode", new { kode = masterpengeluaran.Kode }, masterpengeluaran);
        }

       
        private async Task<Masterpengeluaran> checkMasterpengeluaran(int kode)
        {
            var masterpengeluaran = await _context.Masterpengeluaran.FindAsync(kode);
            if (masterpengeluaran == null)
            {
                throw new NotFoundException("Master gudang not found.");
            }
            return masterpengeluaran;
        }
    }
}
