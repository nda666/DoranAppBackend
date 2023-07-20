using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Entities;
using DoranOfficeBackend.Dto.SalesTeamDto;
using DoranOfficeBackend.Entities.Extentsions;
using DoranOfficeBackend.Attributes;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesTeamsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SalesTeamsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesTeam>>> GetSalesTeams([FromQuery] SalesTeamQueryDto salesTeamQueryDto)
        {
            if (_context.SalesTeams == null)
            {
                return NotFound();
            }
            var query = _context.SalesTeams.AsNoTracking().Include(x => x.SalesChannel).AsQueryable();
            if (!string.IsNullOrEmpty(salesTeamQueryDto.Name))
            {
                query = query.Where(r => EF.Functions.Like(r.Name, $"%{salesTeamQueryDto.Name}%"));
            }

            if (!string.IsNullOrEmpty(salesTeamQueryDto.Active))
            {
                query = query.Where(r => r.Active == bool.Parse(salesTeamQueryDto.Active));
            }

            if (!string.IsNullOrEmpty(salesTeamQueryDto.SalesChannelId))
            {
                query = query.Where(r => r.SalesChannelId.ToString() == salesTeamQueryDto.SalesChannelId);
            }

            if (!string.IsNullOrEmpty(salesTeamQueryDto.Deleted))
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
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesTeam>> GetSalesTeam(Guid id)
        {
            if (_context.SalesTeams == null)
            {
                return NotFound();
            }
            var salesTeam = await _context.SalesTeams.FindAsync(id);

            if (salesTeam == null)
            {
                return NotFound();
            }

            return salesTeam;
        }

        // PUT: api/SalesTeams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesTeam(Guid id, SalesTeam salesTeam)
        {
            if (id != salesTeam.Id)
            {
                return BadRequest();
            }

            var dbSalesChannel = _context.SalesTeams?.Where(e => e.Id == id).FirstOrDefault();
            if (dbSalesChannel == null)
            {
                return NotFound();
            }
            try
            {
                dbSalesChannel.Active = salesTeam.Active;
                dbSalesChannel.Name = salesTeam.Name;
                dbSalesChannel.SalesChannelId = salesTeam.SalesChannelId;
                dbSalesChannel.ShowLastYear = salesTeam.ShowLastYear;
                dbSalesChannel.OmzetTarget = salesTeam.OmzetTarget;
                dbSalesChannel.JeteTarget = salesTeam.JeteTarget;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/SalesTeams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesTeam>> PostSalesTeam(SalesTeam salesTeam)
        {
            if (_context.SalesTeams == null)
            {
                return Problem("Entity set 'MyDbContext.SalesTeams'  is null.");
            }
            _context.SalesTeams.Add(salesTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesTeam", new { id = salesTeam.Id }, salesTeam);
        }

        // DELETE: api/SalesTeams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesTeam(Guid id)
        {
            if (_context.SalesTeams == null)
            {
                return NotFound();
            }
            var salesTeam = await _context.SalesTeams.FindAsync(id);
            if (salesTeam == null)
            {
                return NotFound();
            }

            _context.SalesTeams.Remove(salesTeam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/SalesChannels/5
        [HttpDelete("{id}/restore")]
        public async Task<IActionResult> RestoreDeleteSalesChannel(Guid id)
        {

            if (_context.SalesTeams == null)
            {
                return NotFound();
            }
            var salesTeam = await _context.SalesTeams.FindAsync(id);
            if (salesTeam == null)
            {
                return NotFound();
            }
            await _context.RestoreSoftDeleteAsync<SalesTeam>(salesTeam);

            return NoContent();
        }
    }
}
