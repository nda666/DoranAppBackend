using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Entities;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Entities.Extentsions;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesChannelsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SalesChannelsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesChannels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesChannel>>> GetSalesChannels()
        {
            if (_context.SalesChannels == null)
            {
                return NotFound();
            }
            var query = _context.SalesChannels.AsQueryable();

            if (!string.IsNullOrEmpty(Request.Query["name"]))
            {
                query = query.Where(r => EF.Functions.Like(r.Name, $"%{Request.Query["name"]}%"));
            }

            if (!string.IsNullOrEmpty(Request.Query["active"]))
            {
                query = query.Where(r => r.Active == bool.Parse(Request.Query["active"]));
            }

            if (!string.IsNullOrEmpty(Request.Query["deleted"]))
            {
                query = query.WhereDeleted();
            } else
            {
                query = query.WhereNotDeleted();
            }

            return query.ToList();
        }

        // GET: api/SalesChannels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesChannel>> GetSalesChannel(Guid id)
        {
            if (_context.SalesChannels == null)
            {
                return NotFound();
            }
            var salesChannel = await _context.SalesChannels.FindAsync(id);

            if (salesChannel == null)
            {
                return NotFound();
            }

            return salesChannel;
        }

        // PUT: api/SalesChannels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesChannel(Guid id, SalesChannel salesChannel)
        {
            if (id != salesChannel.Id)
            {
                return BadRequest();
            }
            var dbSalesChannel = _context.SalesChannels?.Where(e => e.Id == id).FirstOrDefault();
            if (dbSalesChannel == null)
            {
                return NotFound();
            }
            try
            {
                dbSalesChannel.Active = salesChannel.Active;
                dbSalesChannel.Name = salesChannel.Name;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/SalesChannels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesChannel>> PostSalesChannel(SalesChannel salesChannel)
        {
            if (_context.SalesChannels == null)
            {
                return Problem("Entity set 'MyDbContext.SalesChannels'  is null.");
            }
            _context.SalesChannels.Add(salesChannel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesChannel", new { id = salesChannel.Id }, salesChannel);
        }

        // DELETE: api/SalesChannels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesChannel(Guid id)
        {
            if (_context.SalesChannels == null)
            {
                return NotFound();
            }
            var salesChannel = await _context.SalesChannels.FindAsync(id);
            if (salesChannel == null)
            {
                return NotFound();
            }

            _context.SalesChannels.Remove(salesChannel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/SalesChannels/5
        [HttpDelete("{id}/restore")]
        public async Task<IActionResult> RestoreDeleteSalesChannel(Guid id)
        {
           
            if (_context.SalesChannels == null)
            {
                return NotFound();
            }
            var salesChannel = await _context.SalesChannels.FindAsync(id);
            if (salesChannel == null)
            {
                return NotFound();
            }
            await _context.RestoreSoftDeleteAsync<SalesChannel>(salesChannel);

            return NoContent();
        }
    }
}
