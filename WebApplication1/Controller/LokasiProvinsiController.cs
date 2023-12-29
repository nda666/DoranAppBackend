
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Models;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Extentsions;
using DoranOfficeBackend.Dtos.LokasiProvinsi;
using AutoMapper;
using DocumentFormat.OpenXml.InkML;

namespace DoranOfficeBackend.Controller.LokasiProvinsiController
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    public class LokasiProvinsiController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public LokasiProvinsiController(IMapper mapper , MyDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        private IQueryable<LokasiProvinsi> BaseQuery(FindLokasiProvinsiDto dto)
        {

            var query = _context.LokasiProvinsi.AsNoTracking().AsQueryable();
            if (!String.IsNullOrEmpty(dto.Nama))
            {
                query = query.Where(r => EF.Functions.Like(r.Nama, $"%{dto.Nama}%"));
            }

            return query;
        }

        // GET: api/LokasiProvinsi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LokasiProvinsi>>> GetLokasiProvinsi([FromQuery] FindLokasiProvinsiDto dto)
        {
          if (_context.LokasiProvinsi == null)
          {
              return NotFound();
          }
           var query = BaseQuery(dto);
           return await query.ToListAsync();
        }

        // GET: api/LokasiProvinsi/withKota
        [HttpGet("withkota", Name = "GetLokasiProvinsiWithKota")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetLokasiProvinsiWithKota([FromQuery] FindLokasiProvinsiDto dto)
        {
            if (_context.LokasiProvinsi == null)
            {
                return NotFound();
            }
            var query = BaseQuery(dto)
                    .Include(e => e.LokasiKota)
                    .Select( e=> new
                    {
                       Kode = e.Kode,
                       Nama = e.Nama,
                       LokasiKota = e.LokasiKota.Select(k => new 
                       {
                           Kode = k.Kode,
                           Nama = k.Nama,
                           Provinsi = k.Provinsi
                       }).ToList()
                    });
            
            return await query.ToListAsync();
        }

        // GET: api/LokasiProvinsi/5
        [HttpGet("{kode}")]
        public async Task<ActionResult<LokasiProvinsi>> GetLokasiProvinsiByKode(int kode)
        {
          if (_context.LokasiProvinsi == null)
          {
              return NotFound();
          }
            var hkategoriBarang = await _context.LokasiProvinsi.FindAsync(kode);

            if (hkategoriBarang == null)
            {
                return NotFound();
            }

            return hkategoriBarang;
        }

        // PUT: api/LokasiProvinsi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kode}")]
        public async Task<ActionResult<LokasiProvinsi>> PutLokasiProvinsi(int kode, SaveLokasiProvinsiDto dto)
        {
            var lokasiProvinsi = await _context.LokasiProvinsi?.Where(e => e.Kode == kode).FirstOrDefaultAsync();
            if (lokasiProvinsi == null)
            {
                return NotFound();
            }
            try
            {
                _mapper.Map(dto, lokasiProvinsi);
                var result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(lokasiProvinsi);
        }

        // POST: api/LokasiProvinsi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LokasiProvinsi>> PostLokasiProvinsi([FromBody] SaveLokasiProvinsiDto dto)
        {
          if (_context.LokasiProvinsi == null)
          {
              return Problem("Entity set 'MyDbContext.LokasiProvinsi'  is null.");
          }
         
            var lastProv = await _context.LokasiProvinsi
                .OrderByDescending(e => e.Kode)
                .FirstOrDefaultAsync();
            var user = (Masteruser)HttpContext.Items["User"];
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var lokasiProvinsi = _mapper.Map<LokasiProvinsi>(dto);
                    lokasiProvinsi.Kode = (sbyte)((lastProv?.Kode ?? 0) + 1);
                    _context.LokasiProvinsi.Add(lokasiProvinsi);

                    var logFile = new Logfile();
                    logFile.Keterangan = $"Tambah Master Provinsi {lastProv.Nama}";
                    logFile.Tanggal = DateTime.Now;
                    logFile.Username = user.Kodeku;
                    _context.Logfile.Add(logFile);


                    await _context.SaveChangesAsync();

                    transaction.Commit();
                    return CreatedAtAction("GetLokasiProvinsi", new { kode = lokasiProvinsi.Kode }, lokasiProvinsi);
                }
                catch (Exception)
                {
                    // If an exception occurs, roll back the transaction
                    transaction.Rollback();
                    return BadRequest();
                }
            }
        }

        // DELETE: api/LokasiProvinsi/5
        [HttpDelete("{kode}")]
        public async Task<IActionResult> DeleteLokasiProvinsi(int kode)
        {
            if (_context.LokasiProvinsi == null)
            {
                return NotFound();
            }
            var hkategoriBarang = await _context.LokasiProvinsi.FindAsync(kode);
            if (hkategoriBarang == null)
            {
                return NotFound();
            }

            _context.LokasiProvinsi.Remove(hkategoriBarang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //// DELETE: api/LokasiProvinsi/5/restore
        //[HttpDelete("{kode}/restore")]
        //public async Task<ActionResult<LokasiProvinsi>> RestoreLokasiProvinsi(int kode)
        //{
        //    if (_context.LokasiProvinsi == null)
        //    {
        //        return NotFound();
        //    }
        //    var hkategoriBarang = await _context.LokasiProvinsi.FindAsync(kode);
        //    if (hkategoriBarang == null)
        //    {
        //        return NotFound();
        //    }

        //     await _context.RestoreSoftDeleteAsync<LokasiProvinsi>(hkategoriBarang);

        //    return NoContent();
        //}
    }
}
