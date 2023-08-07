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
    public class MasteruserController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MasteruserController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Masteruser>>> GetUsers([FromQuery]FindMasteruserDto dto)
        {
            ConsoleDump.Extensions.Dump(dto);
            if (_context.Masterusers == null)
            {
                return NotFound();
            }
            var query = _context.Masterusers.AsNoTracking().AsQueryable();
            if (!String.IsNullOrEmpty(dto.Username))
            {
                query = query.Where(r => EF.Functions.Like(r.Usernameku, $"%{Request.Query["username"]}%"));
            }
           
            if (dto.Aktif.HasValue)
            {
                query = query.Where(r => r.Aktif == dto.Aktif);
            }

            if (dto.Deleted.HasValue)
            {
                query = dto.Deleted == true ? query.WhereDeleted() : query;
            }
            else
            {
                query = query.WhereNotDeleted();
            }

            return await query.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Masteruser>> GetUser(Guid id)
        {
            if (_context.Masterusers == null)
            {
                return NotFound();
            }
            var user = await _context.Masterusers.FindAsync(id);

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
            if (_context.Masterusers == null)
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
            _context.Masterusers.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Kodeku }, user);
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kodeKu}")]
        public async Task<IActionResult> PutUser(int kodeKu, UpdateMasteruserDto dto)
        {
            var user = _context.Masterusers?.Where(e => e.Kodeku == kodeKu).FirstOrDefault();

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
            if (_context.Masterusers == null)
            {
                return NotFound();
            }
            var user = await _context.Masterusers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Masterusers.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(sbyte id)
        {
            return (_context.Masterusers?.Any(e => e.Kodeku == id)).GetValueOrDefault();
        }
    }
}
