using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Entities;
using DoranOfficeBackend.Dto.User;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var query = _context.Users.AsNoTracking().AsQueryable();
            if (!String.IsNullOrEmpty(Request.Query["username"]))
            {
                query = query.Where(r => EF.Functions.Like(r.Username, $"%{Request.Query["username"]}%"));
            }

            return  query.Include(x => x.Role).ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'MyDbContext.Users'  is null.");
            }
            user.PasswordText = user.Password;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.CreatedAt = DateTime.Now;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User saveUser)
        {
            if (id != saveUser.Id)
            {
                return BadRequest();
            }
            var user = _context.Users?.Where(e => e.Id == id).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            user.PasswordText = saveUser.Password;
            user.Password = BCrypt.Net.BCrypt.HashPassword(saveUser.Password);
            user.UpdatedAt = DateTime.Now;
            user.Active = saveUser.Active;
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
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(Guid id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
