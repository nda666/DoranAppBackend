using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoranOfficeBackend.Controller
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        public HomeController( IWebHostEnvironment env)
        {
            this.env = env;
        }

        [HttpGet]
        public async Task<String> Get()
        {
            return "Go go go!!!! goooooooooooOOOOO!!! yes DASHYAT";
        }
    }
}
