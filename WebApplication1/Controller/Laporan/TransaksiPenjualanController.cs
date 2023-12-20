using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Models;
using AutoMapper;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Dtos.Transaksi;
using ConsoleDump;
using MySql.Data.MySqlClient;
using MySql.EntityFrameworkCore.Extensions;
using DoranOfficeBackend.Dtos.LaporanTransaksiPenjualan;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Swashbuckle.AspNetCore.SwaggerGen;
using Humanizer;

namespace DoranOfficeBackend.Controller.Laporan
{
    [Route("api/laporan/[controller]")]
    [ApiController]
    //[Auth]
    [Produces("application/json")]
    public class TransaksiPenjualanController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;
        private readonly IConfiguration _config;
        private readonly IDbConnection _connection;
        public TransaksiPenjualanController(IMapper mapper, MyDbContext context, IConfiguration config, IDbConnection connection)
        {
            _mapper = mapper;
            _config = config;
            _context = context;
            _connection = connection;
        }

        [HttpGet]
        public async Task<ActionResult<HtransResultDto>> GetLaporanTransaksiPenjualan([FromQuery] FindTransaksiPaginationDto dto)
        {
            var baseHtrans = _context.Htrans
               //.Where(e => e.Dtrans.Any())
               .AsNoTracking();
            var htransQ = FindTransaksiPaginationBase(baseHtrans, dto);

            var htransPagingQ = htransQ;
            var htransTotal = htransQ;
            var totalRow = await htransPagingQ.CountAsync();
            var totalSum = await htransTotal
                .GroupBy(e => 1)
                .Select(g => new HtransTotalDto
                {
                    Total = g.Sum(e => e.Jumlah),
                    Komisi = g.Sum(e => e.JumlahKomisi),
                    Untung = g.Sum(e => e.Untung),
                    UntungbelumpotOl = g.Sum(e => e.UntungbelumpotOl),
                    PpnFull = g.Sum(e => e.Ppnreal),
                    Ppn = g.Sum(e => e.Ppn),
                    DppFull = g.Sum(e => e.Dpp),
                    Dpp = g.Sum(e => e.Terbitfakturppn == true ? e.Dpp : 0),
                    Jumlahbarangbiaya = g.Sum(e => e.Jumlahbarangbiaya),
                    Diskon = g.Sum(e => e.Diskon),
                    TotalOmzetPPN = g.Sum(e => e.Terbitfakturppn == true ? e.Jumlah : 0),
                    TambahanLainnya = g.Sum(e => e.TambahanLainnya)
                }).FirstOrDefaultAsync();

            htransQ = htransQ.OrderByDescending(x => x.KodeH);

            if (dto.Limit.HasValue)
            {
                htransQ = htransQ.Take(dto.Limit.Value);
            }

            int skip = (dto.Page - 1) * dto.PageSize;

            htransQ = htransQ.Skip(skip)
                    .Take(dto.PageSize);
            htransQ = htransQ.Include(e => e.Dtrans)
                .ThenInclude(e => e.Masterbarang)
                .Include(e => e.Masterpelanggan)
                .ThenInclude(e => e.LokasiKota)
                .ThenInclude(e => e.LokasiProvinsi)
                .Include(e => e.Sales)
                .Include(e => e.Mastergudang);

            var htrans = await htransQ.ToListAsync();
            ICollection<HtransResult> htransResults = _mapper.Map<ICollection<HtransResult>>(htrans);
            var totalPage = (int)Math.Ceiling((double)totalRow / dto.PageSize);
            var result = new HtransResultDto
            {
                Data = htransResults,
                Page = dto.Page,
                PageSize = dto.PageSize,
                TotalPage = totalPage,
                TotalRow = totalRow,
                Total = totalSum
            };
            return Ok(result);
        }

        private IQueryable<Htrans> FindTransaksiPaginationBase(IQueryable<Htrans> htransQ, FindTransaksiPaginationDto dto, int tipeFilter = 0)
        {


            if (dto.MinDate.HasValue)
            {
                var minDate = new DateTime(dto.MinDate.Value.Year, dto.MinDate.Value.Month, dto.MinDate.Value.Day, 0, 0, 0);
                htransQ = htransQ.Where(x => x.TglTrans >= dto.MinDate);
            }

            if (dto.MaxDate.HasValue)
            {
                var maxDate = new DateTime(dto.MaxDate.Value.Year, dto.MaxDate.Value.Month, dto.MaxDate.Value.Day, 23, 59, 59);
                htransQ = htransQ.Where(x => x.TglTrans <= dto.MaxDate);
            }

            if (dto.Kodeh.HasValue)
            {
                htransQ = htransQ.Where(x => x.KodeH == dto.Kodeh);
            }

            if (dto.Kodegudang.HasValue && dto.Kodegudang >= 0)
            {
                htransQ = htransQ.Where(x => x.Kodegudang == dto.Kodegudang);
            }

            if (dto.KodeSales.HasValue)
            {
                htransQ = htransQ.Where(x => x.KodeSales == dto.KodeSales);
            }

            if (dto.KodePelanggan.HasValue)
            {
                htransQ = htransQ.Where(x => x.KodePelanggan == dto.KodePelanggan);
            }

            if (dto.KodeKota.HasValue)
            {
                htransQ = htransQ.Where(x => x.Masterpelanggan.Kota == dto.KodeKota);
            }

            if (dto.KodeProvinsi.HasValue)
            {
                htransQ = htransQ.Where(x => x.Masterpelanggan.LokasiKota.Provinsi == dto.KodeProvinsi);
            }

            if (!String.IsNullOrEmpty(dto.NamaPelanggan))
            {
                htransQ = htransQ.Where(x => EF.Functions.Like(x.Masterpelanggan.Nama, $"%{dto.NamaPelanggan}%"));
            }

            if (!String.IsNullOrEmpty(dto.Kodenota))
            {
                htransQ = htransQ.Where(x => x.Kodenota == dto.Kodenota);
            }

            if (!String.IsNullOrEmpty(dto.Lunas))
            {
                htransQ = htransQ.Where(x => x.Lunas == dto.Lunas);
            }

            if (dto.InsertName.HasValue)
            {
                htransQ = htransQ.Where(x => x.InsertName == dto.InsertName);
            }

            if (!String.IsNullOrEmpty(dto.Keterangan))
            {
                htransQ = htransQ.Where(x => EF.Functions.Like(x.Keterangan, $"%{dto.Keterangan}%"));
            }

            if (tipeFilter == 0)
            {

                if (!String.IsNullOrEmpty(dto.NamaBarang))
                {
                    htransQ = htransQ.Where(x => x.Dtrans.Any(d => EF.Functions.Like(d.Masterbarang.BrgNama, $"%{dto.NamaBarang}%")));
                }
                if (dto.HargaMin.HasValue)
                {
                    htransQ = htransQ.Where(x => x.Dtrans.Any(d => d.Harga >= dto.HargaMin));
                }

                if (dto.HargaMax.HasValue)
                {
                    htransQ = htransQ.Where(x => x.Dtrans.Any(d => d.Harga <= dto.HargaMax));
                }

                if (dto.HargaTidakNol == true)
                {
                    htransQ = htransQ.Where(x => x.Dtrans.Any(d => d.Harga != 0));
                }
            }



            if (!String.IsNullOrEmpty(dto.NoSeriOnline))
            {
                htransQ = htransQ.Where(x => EF.Functions.Like(x.NoSeriOnline, $"%{dto.NoSeriOnline}%"));
            }

            if (!String.IsNullOrEmpty(dto.Barcodeonline))
            {
                htransQ = htransQ.Where(x => EF.Functions.Like(x.Barcodeonline, $"%{dto.Barcodeonline}%"));
            }

            if (dto.SudahJatuhTempo == true)
            {
                htransQ = htransQ.Where(x => x.Tgltempo <= DateTime.Now);
            }

            if (dto.TipeTempo.HasValue)
            {
                htransQ = htransQ.Where(x => x.Tipetempo == dto.TipeTempo);
            }

            if (dto.Jumlah.HasValue)
            {
                htransQ = htransQ.Where(x => x.Jumlah == dto.Jumlah);
            }

            if (dto.NotaTitip == true)
            {
                htransQ = htransQ.Where(x => x.StatusNota == 3);
            }

            if (dto.Admingantiharga == true)
            {
                htransQ = htransQ.Where(x => x.Admingantiharga == 1);
            }

            if (dto.AkanDjJurnalkan.HasValue)
            {
                htransQ = htransQ.Where(x => x.AkanDjJurnalkan == dto.AkanDjJurnalkan);
            }

            if (dto.Valid.HasValue)
            {
                htransQ = htransQ.Where(x => x.Valid == dto.Valid);
            }

            return htransQ;
        }

        [HttpGet("group-by-kota")]
        public async Task<ActionResult<IEnumerable<LaporanTransaksiPenjualanGroupKotaDto>>> GetLaporanTransaksiPenjualaGroupKota([FromQuery] FindTransaksiPaginationDto dto)
        {

            var whereCondition = GroupByWhere(dto);
            string query = @"
                SELECT 
                    CONCAT(masterpelanggan.nama, ' - ', lokasi_provinsi.nama) as NamaKota,
                    SUM(htrans.Jumlah) as Jumlah
                FROM 
                    htrans
                INNER JOIN masterpelanggan ON htrans.kodepelanggan = masterpelanggan.kode
                INNER JOIN sales ON htrans.kodesales = sales.kode
                INNER JOIN lokasi_kota ON masterpelanggan.kota = lokasi_kota.kode
                INNER JOIN lokasi_provinsi ON lokasi_kota.provinsi = lokasi_provinsi.kode";

            query += whereCondition.conditions.Length > 0 ? " WHERE " + whereCondition.conditions : ""; // Assuming parameterFilter is a string holding additional conditions

            query += @" GROUP BY NamaKota order by Jumlah desc";
            
            var laporanQuery = await _connection.QueryAsync<LaporanTransaksiPenjualanGroupKotaDto>(query, whereCondition.parameters);
            var result = laporanQuery.ToList();
            
            return Ok(result);
        }

        [HttpGet("group-by-provinsi")]
        public async Task<ActionResult<IEnumerable<LaporanTransaksiPenjualanGroupProvinsiDto>>> GetLaporanTransaksiPenjualaGroupProvinsi([FromQuery] FindTransaksiPaginationDto dto)
        {

            var whereCondition = GroupByWhere(dto);
            string query = @"
                SELECT 
                    lokasi_provinsi.nama as NamaProvinsi,
                    SUM(htrans.Jumlah) as Jumlah
                FROM 
                    htrans
                INNER JOIN sales ON htrans.kodesales = sales.kode
                INNER JOIN masterpelanggan ON htrans.kodepelanggan = masterpelanggan.kode
                INNER JOIN lokasi_provinsi ON masterpelanggan.provinsi = lokasi_provinsi.kode";

            query += whereCondition.conditions.Length > 0 ? " WHERE " + whereCondition.conditions : ""; // Assuming parameterFilter is a string holding additional conditions

            query += @" GROUP BY NamaProvinsi order by Jumlah desc";
            
            var laporanQuery = await _connection.QueryAsync<LaporanTransaksiPenjualanGroupProvinsiDto>(query, whereCondition.parameters);
            var result = laporanQuery.ToList();
            
            return Ok(result);

        }

        [HttpGet("group-by-toko")]
        public async Task<ActionResult<IEnumerable<GetLaporanTransaksiPenjualanGroupTokoDto>>> GetLaporanTransaksiPenjualaGroupToko([FromQuery] FindTransaksiPaginationDto dto)
        {

            var whereCondition = GroupByWhere(dto);
            string query = @"
            SELECT 
                BigToInt(1) AS nomornya, 
                salespemilik, 
                s1.nama as NamaSales,
                masterpelanggan.email AS email, 
                CONCAT(masterpelanggan.nama, ' - ', lokasi_kota.nama) AS Nama, 
                SUM(htrans.Jumlah) AS JumlahNya, 
                SUM(htrans.untung) * 100 / SUM(htrans.Jumlah) AS PersenUntung, 
                masterpelanggan.batasOmzet AS limitnya, 
                masterpelanggan.kursKomisi AS blok, 
                masterpelanggan.kode AS kodePelanggan, 
                SUM(htrans.untung) AS untungnya 
            FROM htrans
            JOIN masterpelanggan on htrans.kodepelanggan = masterpelanggan.kode
            JOIN sales ON htrans.kodesales = sales.kode
            JOIN lokasi_kota on  masterpelanggan.kota = lokasi_kota.kode
            LEFT JOIN sales s1 ON s1.kode = masterpelanggan.salespemilik";

            query += whereCondition.conditions.Length > 0 ? " WHERE " + whereCondition.conditions : ""; // Assuming parameterFilter is a string holding additional conditions

            query += @" 
            GROUP BY 
                masterpelanggan.nama, 
                lokasi_kota.nama 
            ORDER BY 
                JumlahNya DESC;
";
            
            var laporanQuery = await _connection.QueryAsync<GetLaporanTransaksiPenjualanGroupTokoDto>(query, whereCondition.parameters);
            var result = laporanQuery.ToList();
            
            return Ok(result);

        }

        private GroupByWhere GroupByWhere(FindTransaksiPaginationDto dto)
        {
            List<string> conditions = new List<string>();
            DynamicParameters parameters = new DynamicParameters();

            if (dto.MinDate.HasValue)
            {
                conditions.Add("htrans.TglTrans >= @MinDate");
                parameters.Add("@MinDate", dto.MinDate.Value.Date, DbType.Date);
            }

            if (dto.MaxDate.HasValue)
            {
                conditions.Add("htrans.TglTrans <= @MaxDate");
                parameters.Add("@MaxDate", dto.MaxDate.Value.Date.AddDays(1).AddSeconds(-1), DbType.Date);
            }

            if (dto.Kodeh.HasValue)
            {
                conditions.Add("htrans.KodeH = @Kodeh");
                parameters.Add("@Kodeh", dto.Kodeh.Value, DbType.Int32);
            }

            if (dto.Kodegudang.HasValue && dto.Kodegudang >= 0)
            {
                conditions.Add("htrans.Kodegudang = @Kodegudang");
                parameters.Add("@Kodegudang", dto.Kodegudang.Value, DbType.Int32);
            }

            if (dto.KodeSales.HasValue)
            {
                conditions.Add("htrans.KodeSales = @KodeSales");
                parameters.Add("@KodeSales", dto.KodeSales.Value, DbType.Int32);
            }

            if (dto.KodePelanggan.HasValue)
            {
                conditions.Add("htrans.KodePelanggan = @KodePelanggan");
                parameters.Add("@KodePelanggan", dto.KodePelanggan.Value, DbType.Int32);
            }

            if (dto.KodeKota.HasValue)
            {
                conditions.Add("htrans.Masterpelanggan.Kota = @KodeKota");
                parameters.Add("@KodeKota", dto.KodeKota.Value, DbType.Int32);
            }

            if (dto.KodeProvinsi.HasValue)
            {
                conditions.Add("htrans.Masterpelanggan.LokasiKota.Provinsi = @KodeProvinsi");
                parameters.Add("@KodeProvinsi", dto.KodeProvinsi.Value, DbType.Int32);
            }

            if (!string.IsNullOrEmpty(dto.NamaPelanggan))
            {
                conditions.Add("Masterpelanggan.Nama LIKE @NamaPelanggan");
                parameters.Add("@NamaPelanggan", $"%{dto.NamaPelanggan}%", DbType.String);
            }

            if (!string.IsNullOrEmpty(dto.Kodenota))
            {
                conditions.Add("Kodenota = @Kodenota");
                parameters.Add("@Kodenota", dto.Kodenota, DbType.String);
            }

            if (!string.IsNullOrEmpty(dto.Lunas))
            {
                conditions.Add("Lunas = @Lunas");
                parameters.Add("@Lunas", dto.Lunas, DbType.String);
            }

            if (dto.InsertName.HasValue)
            {
                conditions.Add("InsertName = @InsertName");
                parameters.Add("@InsertName", dto.InsertName, DbType.Int32);
            }

            if (!string.IsNullOrEmpty(dto.Keterangan))
            {
                conditions.Add("Keterangan LIKE @Keterangan");
                parameters.Add("@Keterangan", $"%{dto.Keterangan}%", DbType.String);
            }

            if (!string.IsNullOrEmpty(dto.NoSeriOnline))
            {
                conditions.Add("NoSeriOnline LIKE @NoSeriOnline");
                parameters.Add("@NoSeriOnline", $"%{dto.NoSeriOnline}%", DbType.String);
            }

            if (!string.IsNullOrEmpty(dto.Barcodeonline))
            {
                conditions.Add("Barcodeonline LIKE @Barcodeonline");
                parameters.Add("@Barcodeonline", $"%{dto.Barcodeonline}%", DbType.String);
            }

            if (dto.SudahJatuhTempo == true)
            {
                conditions.Add("Tgltempo <= @CurrentDateTime");
                parameters.Add("@CurrentDateTime", DateTime.Now, DbType.DateTime);
            }

            if (dto.TipeTempo.HasValue)
            {
                conditions.Add("Tipetempo = @TipeTempo");
                parameters.Add("@TipeTempo", dto.TipeTempo.Value, DbType.Int32);
            }

            if (dto.Jumlah.HasValue)
            {
                conditions.Add("Jumlah = @Jumlah");
                parameters.Add("@Jumlah", dto.Jumlah.Value, DbType.Int32);
            }

            if (dto.NotaTitip == true)
            {
                conditions.Add("StatusNota = 3");
            }

            if (dto.Admingantiharga == true)
            {
                conditions.Add("Admingantiharga = 1");
            }

            if (dto.AkanDjJurnalkan.HasValue)
            {
                conditions.Add("AkanDjJurnalkan = @AkanDjJurnalkan");
                parameters.Add("@AkanDjJurnalkan", dto.AkanDjJurnalkan.Value, DbType.Int32);
            }

            if (dto.Valid.HasValue)
            {
                conditions.Add("Valid = @Valid");
                parameters.Add("@Valid", dto.Valid.Value, DbType.Boolean);
            }

            return new GroupByWhere
            {
                conditions = string.Join(" AND ", conditions),
                parameters = parameters
            };
        }
    }

    internal class GroupByWhere
    {
        public string conditions { get; set; }
        public DynamicParameters parameters { get; set; }
    }
}
