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
    public class TransaksiByTokoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;
        private readonly IDbConnection _dbConnection;


        public TransaksiByTokoController(IMapper mapper, MyDbContext context, IDbConnection dbConnection)
        {
            _mapper = mapper;
            _context = context;
            _dbConnection = dbConnection;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> Get([FromQuery] FindTransaksiByTokoDto dto)
        {
            
            var minDate = dto.MinDate?.Date;
            var maxDate = dto.MaxDate?.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            var builder = new SqlBuilder();
            var template = builder.AddTemplate(@"
        SELECT 
            /**select**/,
            SUM(dtrans.jumlah * dtrans.harga) AS sumTotal,
            SUM(dtrans.jumlah) AS jumlah
        FROM dtrans
        JOIN htrans ON dtrans.kodeh = htrans.KodeH
         JOIN sales on htrans.kodeSales = sales.kode
         JOIN mastertimsales ON mastertimsales.kode = sales.kodetimsales
        JOIN masterpelanggan ON masterpelanggan.kode = htrans.kodePelanggan
        JOIN lokasi_kota ON masterpelanggan.kota = lokasi_kota.kode
        JOIN masterbarang ON dtrans.kodebarang = masterbarang.brgKode
        JOIN dkategoribarang ON dkategoribarang.koded = masterbarang.kategoriBrg
        /**join**/
        /**where**/
        /**groupby**/
        ORDER BY sumTotal DESC
    ");
            switch (dto.TipeGroup)
            {
                
                case TransaksiByTokoTipeGroup.GROUP_BY_KOTA:
                    builder.Select("lokasi_kota.kode, lokasi_kota.nama");
                    builder.GroupBy("masterpelanggan.kota");
                    break;
                default:
                    builder.Select("masterpelanggan.kode, CONCAT(masterpelanggan.nama, ' - ', lokasi_kota.nama) as nama");
                    builder.GroupBy("htrans.kodePelanggan");
                    break;
            }

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

            if (dto.KodeTimSales.HasValue)
            {
                builder.Where("sales.kodetimsales = @kodeTimSales", new { dto.KodeTimSales });
            }

            if (dto.KodeChannelSales.HasValue)
            {
                builder.Where("mastertimsales.kodechannelsales = @kodeChannelSales", new { dto.KodeChannelSales });
            }

            if (dto.KodeKategori.HasValue)
            {
                builder.Where("masterbarang.kategoriBrg = @kodeKategori", new { dto.KodeKategori });
            }

            if (dto.KodeBrand.HasValue)
            {
                builder.Where("dkategoribarang.kodeh = @kodeBrand", new { dto.KodeBrand });
            }

            if (dto.Kodegudang.HasValue)
            {
                builder.Where("htrans.kodegudang = @kodegudang", new { dto.Kodegudang });
            }
            //var retur = (dto.Retur == true ? 2 : 0).ToString();
            //builder.Where("htrans.retur = @retur", new { retur });
            

            using (var connection = _dbConnection)
            {
                connection.Open();
                Console.WriteLine(template.RawSql);
                var queryResult = await connection.QueryAsync<TransaksiByTokoResultDto>(template.RawSql, template.Parameters);
               
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
            //        .Select(e => new TransaksiByTokoResultDto
            //        {
            //            Total = e.Sum(d => d.Jumlah * d.Harga),
            //            BrgKode = e.Key.BrgKode,
            //            Jumlah = e.Sum(d => d.Jumlah),
            //            BrgNama = e.Key.BrgNama
            //        }).ToListAsync();
            //return result;
        }
    }
}
