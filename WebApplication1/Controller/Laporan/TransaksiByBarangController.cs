using AutoMapper;
using DoranOfficeBackend.Dtos.Transaksi;
using DoranOfficeBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Dapper.FluentMap;
using System.Data;
using Dapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoranOfficeBackend.Controller.Laporan
{
    [Route("api/laporan/[controller]")]
    [ApiController]
    public class TransaksiByBarangController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;
        private readonly IDbConnection _dbConnection;


        public TransaksiByBarangController(IMapper mapper, MyDbContext context, IDbConnection dbConnection)
        {
            _mapper = mapper;
            _context = context;
            _dbConnection = dbConnection;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> Get([FromQuery] FindTransaksiByBarangDto dto)
        {
            var minDate = dto.MinDate?.Date;
            var maxDate = dto.MaxDate?.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            var builder = new SqlBuilder();
            var template = builder.AddTemplate(@"
        SELECT 
            masterbarang.brgKode,
            masterbarang.brgNama,
            SUM(dtrans.jumlah * dtrans.harga) AS sumTotal,
            SUM(dtrans.jumlah) AS jumlah
        FROM dtrans
        INNER JOIN htrans ON dtrans.kodeh = htrans.KodeH
        INNER JOIN masterbarang ON dtrans.kodebarang = masterbarang.brgKode
        /**where**/
        GROUP BY masterbarang.brgKode
        ORDER BY sumTotal DESC
    ");

            if (minDate.HasValue)
            {
                builder.Where("htrans.tglTrans >= @minDate", new { minDate });
            }

            if (maxDate.HasValue)
            {
                builder.Where("htrans.tglTrans <= @maxDate", new { maxDate });
            }

            if (dto.KodePelanggan.HasValue)
            {
                builder.Where("htrans.kodePelanggan = @kodePelanggan", new { dto.KodePelanggan });
            }

            if (dto.KodeSales.HasValue)
            {
                builder.Where("htrans.kodeSales = @kodeSales", new { dto.KodeSales });
            }

            using (var connection = _dbConnection)
            {
                connection.Open();

                var queryResult = await connection.QueryAsync<TransaksiByBarangResultDto>(template.RawSql, template.Parameters);

                return queryResult.ToList();
            }

            //var query = _context.Dtrans
            //    .AsNoTracking()
            //    .AsQueryable();
            // query = query.Include(e => e.Htrans);


            //if (dto.MinDate.HasValue)
            //{
            //    var minDate = new DateTime(dto.MinDate.Value.Year, dto.MinDate.Value.Month, dto.MinDate.Value.Day, 0, 0, 0);
            //    query = query.Where(x => x.Htrans.TglTrans >= minDate);
            //}

            //if (dto.MaxDate.HasValue)
            //{
            //    var maxDate = new DateTime(dto.MaxDate.Value.Year, dto.MaxDate.Value.Month, dto.MaxDate.Value.Day, 23, 59, 59);
            //    query = query.Where(x => x.Htrans.TglTrans <= maxDate);
            //}
            //var result = await query.GroupBy(e => e.Masterbarang)
            //        .Select(e => new TransaksiByBarangResultDto
            //        {
            //            Total = e.Sum(d => d.Jumlah * d.Harga),
            //            BrgKode = e.Key.BrgKode,
            //            Jumlah = e.Sum(d => d.Jumlah),
            //            BrgNama = e.Key.BrgNama
            //        }).ToListAsync();
            //return result;
        }

        private Dtrans populatedDtrans(Dtrans dtrans, Htrans htrans)
        {
            dtrans.Htrans = htrans;
            return dtrans;
        }

        private Dtrans populatedDtransMasterBarang(Dtrans dtrans, Masterbarang mb)
        {
            dtrans.Masterbarang = mb;
            return dtrans;
        }
    }
}
