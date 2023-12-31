﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Dtos.Mastertimsales;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Models;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class MastertimsalesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public MastertimsalesController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private IQueryable<Mastertimsales> GetMastertimsalesBaseQuery(FindMastertimsalesDto dto)
        {
            var query = _context.Mastertimsales
                .Include(x => x.Masterchannelsales)
                .AsNoTracking()
                .AsQueryable();

            if (dto.WithSales == true)
            {
                query = query.Include(e => e.Sales
                .Where(s => s.Aktif == true)
                .OrderBy(s => s.Nama)
                );
            }

            if (!string.IsNullOrEmpty(dto.Nama))
            {
                query = query.Where(r => EF.Functions.Like(r.Nama, $"%{dto.Nama}%"));
            }

            if (dto.Aktif.HasValue)
            {
                query = query.Where(r => r.Aktif == dto.Aktif);
            }

            if (!string.IsNullOrEmpty(dto.Kodechannel))
            {
                query = query.Where(r => r.ToString() == dto.Kodechannel);
            }

            //if (!string.IsNullOrEmpty(dto.Deleted))
            //{
            //    query = query.WhereDeleted();
            //}
            //else
            //{
            //    query = query.WhereNotDeleted();
            //}

            return query;
        }

        // GET: api/SalesTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mastertimsales>>> GetMastertimsales([FromQuery] FindMastertimsalesDto dto)
        {
            if (_context.Mastertimsales == null)
            {
                return NotFound();
            }

            return await GetMastertimsalesBaseQuery(dto).ToListAsync();
        }

        // GET: api/SalesTeams/5
        [HttpGet("{kode}")]
        public async Task<ActionResult<Mastertimsales>> GetMastertimsales(sbyte kode)
        {
            if (_context.Mastertimsales == null)
            {
                return NotFound();
            }
            var salesTeam = await _context.Mastertimsales.FindAsync(kode);

            if (salesTeam == null)
            {
                return NotFound();
            }

            return salesTeam;
        }

        // PUT: api/SalesTeams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kode}")]
        public async Task<IActionResult> PutSalesTeam(sbyte kode, SaveMastertimsalesDto dto)
        {

            var dbSalesChannel = await _context.Mastertimsales?.Where(e => e.Kode == kode).FirstOrDefaultAsync();
            if (dbSalesChannel == null)
            {
                return NotFound();
            }
            try
            {
                _mapper.Map(dto, dbSalesChannel);
                var result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(dbSalesChannel);
        }

        // POST: api/SalesTeams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [SwaggerOperationFilter(typeof(SaveMastertimsalesDto))]
        public async Task<ActionResult<Mastertimsales>> PostSalesTeam([FromBody, SwaggerRequestBody("Save master tim sales payload", Required = true)] SaveMastertimsalesDto dto)
        {
            if (_context.Mastertimsales == null)
            {
                return Problem("Entity set 'MyDbContext.SalesTeams'  is null.");
            }
            var entity = _mapper.Map<Mastertimsales>(dto);
            _context.Mastertimsales.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMastertimsales", new { kode = entity.Kode }, entity);
        }

        // DELETE: api/SalesTeams/5
        [HttpDelete("{kode}")]
        public async Task<IActionResult> DeleteSalesTeam(sbyte kode)
        {
            if (_context.Mastertimsales == null)
            {
                return NotFound();
            }
            var salesTeam = await _context.Mastertimsales.FindAsync(kode);
            if (salesTeam == null)
            {
                return NotFound();
            }

            _context.Mastertimsales.Remove(salesTeam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //// DELETE: api/SalesChannels/5
        //[HttpDelete("{kode}/restore")]
        //public async Task<IActionResult> RestoreDeleteSalesChannel(sbyte kode)
        //{

        //    if (_context.Mastertimsales == null)
        //    {
        //        return NotFound();
        //    }
        //    var salesTeam = await _context.Mastertimsales.FindAsync(kode);
        //    if (salesTeam == null)
        //    {
        //        return NotFound();
        //    }
        //    await _context.RestoreSoftDeleteAsync<Mastertimsales>(salesTeam);

        //    return NoContent();
        //}
    }
}
