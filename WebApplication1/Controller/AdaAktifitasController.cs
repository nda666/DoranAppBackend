using AutoMapper;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class AdaAktifitasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public AdaAktifitasController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("/set-ada-orderan")]
        public async Task<ActionResult> SetAdaOrderan()
        {
            await _context.Database.ExecuteSqlRawAsync("UPDATE adaaktifitas SET adaorderan=1 WHERE 1=1");
            return Ok();
        }
    }
}
