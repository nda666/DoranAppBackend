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
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // POST: api/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoginResposeDto>> PostLogin(LoginDto login)
        {
         
          if (_context.Masteruser == null)
          {
              return Problem("Entity set 'DoranOfficeContext.Users'  is null.");
          }
            
            //try
            //{
                var user = _context.Masteruser.Where(user => user.Usernameku.ToLower() == login.username.ToLower()).First();


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
                return Ok(new LoginResposeDto
                {
                    
                    ApiToken = stringToken,
                    Masteruser = user
                });
            //} catch (InvalidOperationException ex){
            //    ConsoleDump.Extensions.Dump(ex);
            //    Console.WriteLine("123123 " + ex.Message);
            //    return Unauthorized();
            //}
            
        }

    }
}
