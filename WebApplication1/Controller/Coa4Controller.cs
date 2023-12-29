using AutoMapper;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Dtos.Coa4;
using DoranOfficeBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class Coa4Controller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public Coa4Controller(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Masterbarang
        [HttpGet()]
        public async Task<ActionResult<ICollection<Coa4>>> GetCoa4([FromQuery] GetCoa4Dto dto)
        {
            if (_context.Barangsn == null)
            {
                return NotFound();
            }
            var query = _context.Coa4s
                     .AsNoTracking()
                     .AsQueryable();

            if (dto.Kodecoa3.HasValue)
            {
                query = query.Where(e => e.Kodecoa3 == dto.Kodecoa3.Value);
            }

            var result = await query.ToListAsync();
            return result;
        }

        [HttpGet("options")]
        public async Task<ActionResult<ICollection<Coa4OptionDto>>> GetCoa4Options([FromQuery] GetCoa4Dto dto)
        {
            if (_context.Barangsn == null)
            {
                return NotFound();
            }
            var query = _context.Coa4s
                     .AsNoTracking()
                     .AsQueryable();

            if (dto.Kodecoa3.HasValue)
            {
                query = query.Where(e => e.Kodecoa3 == dto.Kodecoa3.Value);
            }
            query = query.OrderBy(e => e.Nama);

            var result = await query.Select(e => new Coa4OptionDto
            {
                Kode = e.Kode,
                Nama = e.Nama
            }).ToListAsync();

            return result;
        }
    }
}
