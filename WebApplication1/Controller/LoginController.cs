using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DoranOfficeBackend.Entities;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DoranOfficeBackend.Dto.Auth;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<User>> PostLogin(LoginDto login)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'DoranOfficeContext.Users'  is null.");
          }
            
            try
            {
                var user = _context.Users.Where(user => user.Username == login.username).First();
                if (!BCrypt.Net.BCrypt.Verify(login.password, user.Password))
                {
                    return Unauthorized();
                }
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt")["Secret"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
              {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Username),
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
                return Unauthorized();
            }
                
                
           
           
            
        }

    }
}
