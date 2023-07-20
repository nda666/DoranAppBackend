using DoranOfficeBackend.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace DoranOfficeBackend.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext, MyDbContext dbContext)
        {

            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            Console.WriteLine("Token: " + token);
            if (token != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt")["Secret"]);
              
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                Console.WriteLine("JWT: " + jwtToken.Claims.First(x => x.Type == "Id").Value);
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "Id").Value);
                
                var user = dbContext.Users.FirstOrDefault(x => x.Id == userId);
                httpContext.Items["User"] = user;
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class JwtMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtMiddleware>();
        }
    }
}
