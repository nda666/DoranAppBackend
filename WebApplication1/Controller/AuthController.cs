using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DoranOfficeBackend.Dtos.Auth;
using DoranOfficeBackend.Models;
using NuGet.Common;
using Microsoft.EntityFrameworkCore;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<Masteruser>> GetUserByToken()
        {
            var userKode = Convert.ToInt32(User.FindFirst("Id")?.Value);
            if (userKode == null)
            {
                return BadRequest("User not found");
            }
            var user = _context.Masterusers.Where(e => e.Kodeku == userKode).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Your token is valid but User not found");
            }
            return user;
        }
        // POST: api/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoginResposeDto>> PostLogin(LoginDto login)
        {

            if (_context.Masterusers == null)
            {
                return Problem("Entity set 'DoranOfficeContext.Users'  is null.");
            }

            //try
            //{
            var user = await _context.Masterusers
                .Where(user => user.Usernameku.ToLower() == login.username.ToLower())
                .Where(user => user.Passwordku == login.password)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return Unauthorized();
            }
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt")["Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
          {
                new Claim("Id", user.Kodeku.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Usernameku),
                new Claim(JwtRegisteredClaimNames.Email, user.Usernameku),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                Expires = DateTime.Now.AddDays(1),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);
            return Ok(new LoginResposeDto
            {

                ApiToken = stringToken,
                Masteruser = user
            });

        }

    }
}
