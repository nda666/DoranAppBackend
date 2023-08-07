using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Models;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Attributes;
using AutoMapper;
using DoranOfficeBackend.Dtos.Sales;
using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]

    public class SalesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public SalesController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesDto>>> GetSales([FromQuery] FindSalesDto dto)
        {
          if (_context.Sales == null)
          {
              return NotFound();
          }

            var query = _context.Sales.AsNoTracking()
                    .Include(x => x.SalesManager)
                    .Include(x => x.Mastertimsales)
                    .AsQueryable();
            if (!string.IsNullOrEmpty(dto.Nama))
            {
                query = query.Where(r => EF.Functions.Like(r.Nama, $"%{dto.Nama}%"));
            }

            if (dto.Aktif.HasValue)
            {
                query = query.Where(r => r.Aktif == dto.Aktif);
            }

            if (dto.Kodetimsales.HasValue)
            {
                query = query.Where(r => r.Kodetimsales == dto.Kodetimsales);
            }

            Console.WriteLine("dto.Manager " + dto.Manager);
            if (dto.Manager.HasValue)
            {
                query = query.Where(r => r.Manager == dto.Manager);
                
            }

            if (dto.Deleted == true)
            {
                query = query.WhereDeleted();
            } else
            {
                query =  query.WhereNotDeleted();
            }

            var result = await query.ToListAsync();

            return _mapper.Map<SalesDto[]>(result);
        }

        // GET: api/Sales/5
        [HttpGet("{kode}")]
        public async Task<ActionResult<SalesDto>> GetSales(int kode)
        {
          if (_context.Sales == null)
          {
              return NotFound();
          }
            var sales = await _context.Sales
                    .AsNoTracking()
                    .Include(x => x.SalesManager)
                    .Include(x => x.Mastertimsales)
                    .Where(x => x.Kode == kode)
                    .FirstOrDefaultAsync();

            if (sales == null)
            {
                return NotFound();
            }

            return _mapper.Map<SalesDto>(sales);
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kode}")]
        public async Task<ActionResult<Sales>> PutSales(int kode, SaveSalesDto dto)
        {
            var sales = await _context.Sales.FindAsync(kode);
            if (sales == null)
            {
                return NotFound();
            }

            try
            {
                _mapper.Map(dto, sales);
                var result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(sales);
        }

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sales>> PostSales(SaveSalesDto dto)
        {
          if (_context.Sales == null)
          {
              return Problem("Entity set 'MyDbContext.Sales'  is null.");
          }
         
            var entity = _mapper.Map<Sales>(dto);
            entity.Emailspv ="";
            entity.NamaPendamping = "";
            entity.Tim = "";
            _context.Sales.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSales", new { id = entity.Id }, entity);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{kode}")]
        public async Task<ActionResult<Sales>> DeleteSales(int kode)
        {
            if (_context.Sales == null)
            {
                return NotFound();
            }
            var sales = await _context.Sales.FindAsync(kode);
            if (sales == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sales);
            await _context.SaveChangesAsync();

            return Ok(sales);
        }

        [HttpDelete("{kode}/restore")]
        public async Task<ActionResult<Sales>> RestoreDeleteSales(int kode)
        {
            if (_context.Mastertimsales == null)
            {
                return NotFound();
            }
            var sales = await _context.Sales.FindAsync(kode);
            if (sales == null)
            {
                return NotFound();
            }

            await _context.RestoreSoftDeleteAsync<Sales>(sales);

            return Ok(sales);
        }
    }
}
