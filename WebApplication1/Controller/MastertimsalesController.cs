
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Dtos.Mastertimsales;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Models;
using AutoMapper;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    public class MastertimsalesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DoranDbContext _context;

        public MastertimsalesController(IMapper mapper, DoranDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/SalesTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mastertimsales>>> GetMastertimsales([FromQuery] FindMastertimsalesDto dto)
        {
            if (_context.Mastertimsales == null)
            {
                return NotFound();
            }
            var query = _context.Mastertimsales
                .Include(x => x.Masterchannelsales)
                .AsNoTracking()
                .AsQueryable();

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

            if (!string.IsNullOrEmpty(dto.Deleted))
            {
                query = query.WhereDeleted();
            }
            else
            {
                query = query.WhereNotDeleted();
            }

            return await query.ToListAsync();
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
        public async Task<ActionResult<Mastertimsales>> PostSalesTeam([FromBody]SaveMastertimsalesDto dto)
        {
            if (_context.Mastertimsales == null)
            {
                return Problem("Entity set 'MyDbContext.SalesTeams'  is null.");
            }
            var entity = _mapper.Map<Mastertimsales>(dto);
            _context.Mastertimsales.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMastertimsales", new { id = entity.Id }, entity);
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

        // DELETE: api/SalesChannels/5
        [HttpDelete("{kode}/restore")]
        public async Task<IActionResult> RestoreDeleteSalesChannel(sbyte kode)
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
            await _context.RestoreSoftDeleteAsync<Mastertimsales>(salesTeam);

            return NoContent();
        }
    }
}
