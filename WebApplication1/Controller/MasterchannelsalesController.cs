using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Models;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Dtos.Masterchannelsales;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    public class MasterchannelsalesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MasterchannelsalesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesChannels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Masterchannelsales>>> GetMasterchannelsales([FromQuery]FindMasterchannelsalesDto findMasterchannelsalesDto)
        {
            if (_context.Masterchannelsales == null)
            {
                return NotFound();
            }
            var query = _context.Masterchannelsales.AsQueryable();

            if (!string.IsNullOrEmpty(findMasterchannelsalesDto.Nama))
            {
                query = query.Where(r => EF.Functions.Like(r.Nama, $"%{findMasterchannelsalesDto.Nama}%"));
            }

            if (findMasterchannelsalesDto.Aktif.HasValue)
            {
                query = query.Where(r => r.Aktif == findMasterchannelsalesDto.Aktif);
            }

            if (!string.IsNullOrEmpty(findMasterchannelsalesDto.Deleted))
            {
                query = query.WhereDeleted();
            } else
            {
                query = query.WhereNotDeleted();
            }

            return await query.ToListAsync();
        }

        // GET: api/SalesChannels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Masterchannelsales>> GetMasterchannelsales(Guid id)
        {
            if (_context.Masterchannelsales == null)
            {
                return NotFound();
            }
            var salesChannel = await _context.Masterchannelsales.FindAsync(id);

            if (salesChannel == null)
            {
                return NotFound();
            }

            return salesChannel;
        }

        // PUT: api/SalesChannels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kode}")]
        public async Task<ActionResult<Masterchannelsales>> PutSalesChannel(sbyte kode, SaveMasterchannelsalesDto salesChannel)
        {
            var dbSalesChannel = _context.Masterchannelsales?.Where(e => e.Kode == kode).FirstOrDefault();
            if (dbSalesChannel == null)
            {
                return NotFound();
            }
            try
            {
                dbSalesChannel.Nama = salesChannel.Nama;
                dbSalesChannel.Aktif = salesChannel.Aktif;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw;
            }

            return dbSalesChannel;
        }

        // POST: api/SalesChannels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public  async Task<ActionResult<Masterchannelsales>> PostSalesChannel([FromBody] SaveMasterchannelsalesDto dto)
        {
           
           Masterchannelsales masterchannelsales = new Masterchannelsales();
            masterchannelsales.Nama = dto.Nama;
            masterchannelsales.Aktif = dto.Aktif;
            _context.Masterchannelsales.Add(masterchannelsales);
            var res = await _context.SaveChangesAsync();

            return res > 0 ? CreatedAtAction("GetMasterchannelsales", new { id = masterchannelsales.Kode }, masterchannelsales) : Conflict();
        }

        // DELETE: api/SalesChannels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesChannel(int id)
        {
            var salesChannel = await _context.Masterchannelsales.Where(e => e.Kode == id).FirstOrDefaultAsync();
            if (salesChannel == null)
            {
                return NotFound();
            }

            _context.Masterchannelsales.Remove(salesChannel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/SalesChannels/5
        [HttpDelete("{id}/restore")]
        public async Task<IActionResult> RestoreDeleteSalesChannel(sbyte id)
        {
            var salesChannel = await _context.Masterchannelsales.FindAsync(new
            {
                kode = id
            });
            if (salesChannel == null)
            {
                return NotFound();
            }
            await _context.RestoreSoftDeleteAsync<Masterchannelsales>(salesChannel);

            return NoContent();
        }
    }
}
