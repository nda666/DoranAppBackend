using DocumentFormat.OpenXml.InkML;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Dto;
using DoranOfficeBackend.Dto.Role;
using DoranOfficeBackend.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly Entities.MyDbContext _context;
        private readonly IConfiguration _configuration;
        private IValidator<Role> _validator;

        public RolesController(Entities.MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (_context.Roles == null)
            {
                return Problem("Entity set 'Context.Roles' is null.");
            }

            var query = _context.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(Request.Query["name"]))
            {
                query = query.Where(r => EF.Functions.Like(r.Name, $"%{Request.Query["name"]}%"));
            }

            if (!string.IsNullOrEmpty(Request.Query["active"]))
            {
                Console.WriteLine("sadasdasdasdasd" + Request.Query["active"]);
                query = query.Where(r => r.Active == bool.Parse(Request.Query["active"]));
            }

            var roles = query.Select(x => new RolesDto {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList();

            return Ok(roles);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Role saveRole)
        {
            var role = new Role { Active = saveRole.Active, Name = saveRole.Name, CreatedAt = DateTime.Now };
            _context.Add(role);
            var result = await _context.SaveChangesAsync();
            return Ok(role);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SaveRole saveRole)
        {

            var newRole = new Role { Id = id, Active = saveRole.Active, Name = saveRole.Name};
            var role = _context.Roles.SingleOrDefault(d => d.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            role.Name = newRole.Name;
            role.Active = newRole.Active;
            role.UpdatedAt = DateTime.Now;
            var result =  _context.SaveChanges();
            return result > 0 ? Ok(role) : BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var role = _context.Roles.SingleOrDefault(d => d.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            _context.Roles.Remove(role);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? Ok(role) : BadRequest();
        }
     }
}
