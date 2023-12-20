using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Models;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Dtos.Masteruser;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class MasteruserController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MasteruserController(MyDbContext context)
        {
            _context = context;
        }

        private IQueryable<Masteruser> BaseQuery(FindMasteruserDto dto)
        {
            var query = _context.Masteruser.AsNoTracking().AsQueryable();
            if (!String.IsNullOrEmpty(dto.Username))
            {
                query = query.Where(r => EF.Functions.Like(r.Usernameku, $"%{Request.Query["username"]}%"));
            }

            if (dto.Aktif.HasValue)
            {
                query = query.Where(r => r.Aktif == dto.Aktif);
            }

            if (!String.IsNullOrEmpty(dto.Akses))
            {
                query = query.Where(r => r.Akses == dto.Akses);
            }

            return query;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Masteruser>>> GetUsers([FromQuery]FindMasteruserDto dto)
        {
            if (_context.Masteruser == null)
            {
                return NotFound();
            }
            var query = this.BaseQuery(dto);

            return await query.ToListAsync();
        }

        [HttpGet("options")]
        public async Task<ActionResult<IEnumerable<MasteruserOptionDto>>> GetUserOptions([FromQuery] FindMasteruserDto dto)
        {
            if (_context.Masteruser == null)
            {
                return NotFound();
            }
            var result = await this.BaseQuery(dto)
                .Select(e => new MasteruserOptionDto
                {
                    Kodeku = e.Kodeku,
                    Usernameku = e.Usernameku
                })
                .ToListAsync();

            return result;
        }

        // GET: api/Users/5
        [HttpGet("{kode}")]
        public async Task<ActionResult<Masteruser>> GetUser(int kode)
        {
            if (_context.Masteruser == null)
            {
                return NotFound();
            }
            var user = await _context.Masteruser.Where(e => e.Kodeku == kode).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Masteruser>> PostUser([FromBody] SaveMasteruserDto
 saveMasteruser)
        {
            if (_context.Masteruser == null)
            {
                return Problem("Entity set 'MyDbContext.Users'  is null.");
            }
            var user = new Masteruser();
            user.Passwordku = saveMasteruser.Passwordku;
            user.Usernameku = saveMasteruser.Usernameku;
            user.Kodesales = 1;
            user.Aktif = saveMasteruser.Aktif;
            user.Akses = saveMasteruser.Akses;
            //user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Masteruser.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Kodeku }, user);
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kodeKu}")]
        public async Task<IActionResult> PutUser(int kodeKu, UpdateMasteruserDto dto)
        {
            var user = _context.Masteruser?.Where(e => e.Kodeku == kodeKu).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }
            user.Usernameku = dto.Usernameku;
            user.Passwordku = dto.Passwordku;
            user.Aktif = dto.Aktif;
            user.Akses = dto.Akses;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (_context.Masteruser == null)
            {
                return NotFound();
            }
            var user = await _context.Masteruser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Masteruser.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(sbyte id)
        {
            return (_context.Masteruser?.Any(e => e.Kodeku == id)).GetValueOrDefault();
        }
    }
}
