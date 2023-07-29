using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Entities;
using DoranOfficeBackend.Dto.SalesDto;
using DoranOfficeBackend.Entities.Extentsions;
using DoranOfficeBackend.Attributes;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    public class SalesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SalesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sales>>> GetSales([FromQuery] SalesQueryDto salesQuery)
        {
          if (_context.Sales == null)
          {
              return NotFound();
          }

            var query = _context.Sales.AsNoTracking()
                    .Include(x => x.Manager)
                    .Include(x => x.SalesTeam)
                    .AsQueryable();
            if (!string.IsNullOrEmpty(salesQuery.Name))
            {
                query = query.Where(r => EF.Functions.Like(r.Name, $"%{salesQuery.Name}%"));
            }

            if (!string.IsNullOrEmpty(salesQuery.Active))
            {
                query = query.Where(r => r.Active == bool.Parse(salesQuery.Active));
            }

            if (!string.IsNullOrEmpty(salesQuery.SalesTeamlId))
            {
                query = query.Where(r => r.SalesTeamId.ToString() == salesQuery.SalesTeamlId);
            }

            if (!string.IsNullOrEmpty(salesQuery.GetOmzetEmail))
            {
                query = query.Where(r => r.GetOmzetEmail.ToString() == salesQuery.GetOmzetEmail);
            }

            if (!string.IsNullOrEmpty(salesQuery.ManagerId))
            {
                query = query.Where(r => r.GetOmzetEmail.ToString() == salesQuery.ManagerId);
            }
            Console.WriteLine(Request.QueryString);
            if (!string.IsNullOrEmpty(salesQuery.IsManager))
            {
                query = query.Where(r => r.IsManager == bool.Parse(salesQuery.IsManager));
                
            }

            if (!string.IsNullOrEmpty(salesQuery.Deleted))
            {
                query = query.WhereDeleted();
            }
            else
            {
                query = query.WhereNotDeleted();
            }
            return await _context.Sales.ToListAsync();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sales>> GetSales(Guid id)
        {
          if (_context.Sales == null)
          {
              return NotFound();
          }
            var sales = await _context.Sales.FindAsync(id);

            if (sales == null)
            {
                return NotFound();
            }

            return sales;
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSales(Guid id, Sales sales)
        {
            if (id != sales.Id)
            {
                return BadRequest();
            }

            _context.Entry(sales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sales>> PostSales(Sales sales)
        {
          if (_context.Sales == null)
          {
              return Problem("Entity set 'MyDbContext.Sales'  is null.");
          }
            _context.Sales.Add(sales);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSales", new { id = sales.Id }, sales);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSales(Guid id)
        {
            if (_context.Sales == null)
            {
                return NotFound();
            }
            var sales = await _context.Sales.FindAsync(id);
            if (sales == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sales);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesExists(Guid id)
        {
            return (_context.Sales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
