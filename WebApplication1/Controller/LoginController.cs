using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DoranOfficeBackend.Dtos.Auth;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DoranDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(DoranDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // POST: api/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Masteruser>> PostLogin(LoginDto login)
        {
         
          if (_context.Masterusers == null)
          {
              return Problem("Entity set 'DoranOfficeContext.Users'  is null.");
          }
            
            try
            {
                var user = _context.Masterusers.Where(user => user.Usernameku == login.username).First();

                Console.WriteLine("PASS " + user.Passwordku);
                if (login.password != user.Passwordku)
                {
                    return Unauthorized();
                }
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt")["Secret"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
              {
                new Claim("Id", user.Kodeku.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Usernameku),
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
                return new JsonResult(new
                {
                    api_token = stringToken
                });

                return user;
            } catch (InvalidOperationException ex){
                Console.WriteLine("123123 " + ex.Message);
                return Unauthorized();
            }
            
        }

    }
}
