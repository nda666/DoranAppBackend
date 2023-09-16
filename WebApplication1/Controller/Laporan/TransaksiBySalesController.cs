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
    public class TransaksiBySalesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;
        private readonly IDbConnection _dbConnection;


        public TransaksiBySalesController(IMapper mapper, MyDbContext context, IDbConnection dbConnection)
        {
            _mapper = mapper;
            _context = context;
            _dbConnection = dbConnection;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> Get([FromQuery] FindTransaksiBySalesDto dto)
        {
            ConsoleDump.Extensions.Dump(dto);
            var minDate = dto.MinDate?.Date;
            var maxDate = dto.MaxDate?.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            var builder = new SqlBuilder();
            var template = builder.AddTemplate(@"
        SELECT 
            /**select**/
        FROM dtrans
        LEFT JOIN htrans ON dtrans.kodeh = htrans.KodeH
        LEFT JOIN sales on htrans.kodeSales = sales.kode
        LEFT JOIN mastertimsales ON mastertimsales.kode = sales.kodetimsales
        LEFT JOIN masterbarang ON dtrans.kodebarang = masterbarang.brgKode
        LEFT JOIN dkategoribarang ON dkategoribarang.koded = masterbarang.kategoriBrg
        /**join**/
        /**where**/
        /**groupby**/
    ");
            builder.Where("dtrans.harga <> 0");
            switch (dto.ShowMode )
            {
                case TransaksiBySalesShowMode.BY_OMZET:
                    builder.Select("SUM(dtrans.jumlah * dtrans.harga) AS sumTotal");
                    break;
                default:
                    builder.Select("SUM(dtrans.jumlah ) AS sumTotal");
                    break;
            }
            switch (dto.TipeGroup)
            {
                
                case TransaksiBySalesTipeGroup.GROUP_BY_CHANNEL:
                    builder.Select("(SELECT masterchannelsales.nama FROM masterchannelsales WHERE masterchannelsales.kode = mastertimsales.kodechannel LIMIT 1) AS nama, sales.kode");
                    builder.GroupBy("mastertimsales.kodechannel");
                    break;
                default:
                    builder.Select("sales.kode, sales.nama");
                    builder.GroupBy("htrans.kodesales");
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

            if (!String.IsNullOrWhiteSpace(dto.BrgNama))
            {
                builder.Where("masterbarang.brgNama like %@brgNama%", new { dto.BrgNama });
            }

            if (dto.KodeTimSales.HasValue)
            {
                builder.Where("sales.kodetimsales = @kodeTimSales", new { dto.KodeTimSales });
            }

            if (dto.KodeChannelSales.HasValue)
            {
                builder.Where("mastertimsales.kodechannel = @kodeChannel", new {  dto.KodeChannelSales });
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

            if (dto.JurnalPenjualan.HasValue)
            {
                builder.Where("htrans.akanDjJurnalkan = @jurnalPenjualan", new { dto.JurnalPenjualan });
            }
            //var retur = (dto.Retur == true ? 2 : 0).ToString();
            //builder.Where("htrans.retur = @retur", new { retur });


            using (var connection = _dbConnection)
            {
                connection.Open();
                var queryResult = await connection.QueryAsync<TransaksiBySalesResultDto>(template.RawSql, template.Parameters);
                Console.WriteLine(template.RawSql);
                var grandTotal = queryResult.Sum(e => e.SumTotal);
                var result = queryResult.Select((e) => new TransaksiBySalesResultDto
                {
                    Kode = e.Kode,
                    Nama = e.Nama,
                    SumTotal = e.SumTotal,
                    Persen = (float)(e.SumTotal / (float)grandTotal * (float) 100)
                }).ToList();
                connection.Close();
                return result;
            }
        }
    }
}
