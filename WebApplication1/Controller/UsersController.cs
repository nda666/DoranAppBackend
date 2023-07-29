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
    public class UsersController : ControllerBase
    {
        private readonly DoranDbContext _context;

        public UsersController(DoranDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Masteruser>>> GetUsers()
        {
            if (_context.Masterusers == null)
            {
                return NotFound();
            }
            var query = _context.Masterusers.AsNoTracking().AsQueryable();
            if (!String.IsNullOrEmpty(Request.Query["username"]))
            {
                query = query.Where(r => EF.Functions.Like(r.Usernameku, $"%{Request.Query["username"]}%"));
            }

            if (!String.IsNullOrEmpty(Request.Query["deleted"]))
            {
                query = query.WhereDeleted();
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
        public async Task<ActionResult<Masteruser>> PostUser([FromBody] SaveMasteruser
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
        public async Task<IActionResult> PutUser(string kodeKu, UpdateMasteruser updateMasteruser)
        {
            var user = _context.Masterusers?.Where(e => e.Kodeku.ToString() == kodeKu).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }
            user.Passwordku = updateMasteruser.Passwordku;
            user.Aktif = updateMasteruser.Aktif;
            user.Akses = updateMasteruser.Akses;
            Console.WriteLine("Akses " + updateMasteruser.Akses);
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
