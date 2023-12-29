using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend;
using DoranOfficeBackend.Models;
using AutoMapper;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Exceptions;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Dtos.Masterbarang;
using ConsoleDump;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class BarangsnController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public BarangsnController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Masterbarang
        [HttpGet("find")]
        public async Task<ActionResult<Barangsn>> FindBarangsnBySn([FromQuery]string sn)
        {
            if (_context.Barangsn == null)
            {
                return NotFound();
            }
            Console.WriteLine(sn);
            var query = _context.Barangsn
                     .AsNoTracking()
                     .AsQueryable()
                     .Where(e => e.NmrSn == sn);
            var result = await query.FirstOrDefaultAsync();
            if (result == null)
            {
                return BadRequest(new { message = "Barang tidak ditemukan" });
            }
            return result;
        }
    }
}
