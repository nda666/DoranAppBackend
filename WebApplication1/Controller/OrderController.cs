
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Models;
using AutoMapper;
using DoranOfficeBackend.Attributes;
using DoranOfficeBackend.Dtos.Order;
using DocumentFormat.OpenXml.InkML;
using Humanizer;
using NuGet.Protocol;
using StackExchange.Profiling.Internal;
using ConsoleDump;
using DoranOfficeBackend.Dtos.Transit;
using FluentValidation;
using MySqlX.XDevAPI.Common;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;
        private readonly WebSocketService _webSocket;
        private IValidator<SaveOrderDto> _SaveOrderValidator;

        public OrderController(
            IMapper mapper,
            MyDbContext context,
            WebSocketService webSocket,
            IValidator<SaveOrderDto> SaveOrderValidator)
        {
            _mapper = mapper;
            _context = context;
            _webSocket = webSocket;
            _SaveOrderValidator = SaveOrderValidator;
        }

        private IQueryable<Horder> BaseHorderQuery(GetOrderRequest dto)
        {
            dto.Dump();
            var HorderQ = _context.Horder
               .AsNoTracking()
               .AsQueryable();


            if (dto.MinDate.HasValue)
            {
                var minDate = new DateTime(dto.MinDate.Value.Year, dto.MinDate.Value.Month, dto.MinDate.Value.Day, 0, 0, 0);
                HorderQ = HorderQ.Where(x => x.Tglorder >= minDate);
            }

            if (dto.MaxDate.HasValue)
            {
                var maxDate = new DateTime(dto.MaxDate.Value.Year, dto.MaxDate.Value.Month, dto.MaxDate.Value.Day, 23, 59, 59);
                HorderQ = HorderQ.Where(x => x.Tglorder <= maxDate);
            }

            if (!String.IsNullOrWhiteSpace(dto.NamaCust))
            {
                HorderQ = HorderQ.Where(x => EF.Functions.Like(x.NamaCust, $"%{dto.NamaCust}%"));
            }

            if (!String.IsNullOrWhiteSpace(dto.NamaPelanggan))
            {
                HorderQ = HorderQ.Where(x => EF.Functions.Like(x.Masterpelanggan.Nama, $"%{dto.NamaCust}%"));
            }

            if (!String.IsNullOrEmpty(dto.Namagudang))
            {
                HorderQ = HorderQ.Where(x => EF.Functions.Like(x.Mastergudang.Nama, $"%{dto.Namagudang}%"));
            }

            if (dto.Kodeh.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Kodeh == dto.Kodeh);
            }

            if (dto.Dicetak == true)
            {
                HorderQ = HorderQ.Where(x => x.Dicetak > 0);
            }

            if (dto.Dicetak == false)
            {
                HorderQ = HorderQ.Where(x => x.Dicetak <= 0 && x.Historynya >= 2);
            }

            if (dto.LevelOrder.HasValue)
            {

                if (dto.LevelOrder == LevelOrderEnum.ADMIN)
                {

                    HorderQ = HorderQ.Where(x => x.Historynya >= 3);
                }

                if (dto.LevelOrder == LevelOrderEnum.GUDANG)
                {
                    HorderQ = HorderQ.Where(x =>  x.Historynya <= 2);
                }
            }

            if (dto.BelumCekOl)
            {
                HorderQ = HorderQ.Where(x => x.Historynya >= 5);
            }

            if (dto.SalesOl.HasValue)
            {
                if (dto.SalesOl == true)
                {
                    HorderQ = HorderQ.Where(x => x.Sales.Salesol > 0);
                }
                else
                {
                    HorderQ = HorderQ.Where(x => x.Sales.Salesol == 0);
                }
            }

            if (dto.Kodesales.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Kodesales == dto.Kodesales);
            }

            if (dto.Kodepelanggan.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Kodepelanggan == dto.Kodepelanggan);
            }

            if (dto.Kodegudang.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Kodegudang == dto.Kodegudang);
            }

            if (!String.IsNullOrEmpty(dto.NoSeriOnline))
            {
                HorderQ = HorderQ.Where(x => EF.Functions.Like(x.NoSeriOnline, dto.NoSeriOnline));
            }

            if (!String.IsNullOrEmpty(dto.Barcodeonline))
            {
                HorderQ = HorderQ.Where(x => EF.Functions.Like(x.Barcodeonline, dto.Barcodeonline));
            }

            if (dto.Historynya.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Historynya == dto.Historynya);
            }


            if (dto.StokSales.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.StokSales == dto.StokSales);
            }

            if (dto.KodeBarang.HasValue)
            {
                HorderQ = HorderQ.Where(x => x.Dorder.Any(e => e.Kodebarang == dto.KodeBarang));
            }

            return HorderQ;
        }

        private IQueryable<Horder> IncludeHorderRelation(IQueryable<Horder> HorderQ, GetOrderRequest dto)
        {
            HorderQ = HorderQ
                .Include(e => e.Mastergudang)
                .Include(e => e.Sales)
                .Include(e => e.Penyiaporder)
                .Include(e => e.MasteruserInsert)
                .Include(e => e.MasteruserUpdate)
                .Include(e => e.Ekspedisi)
                .Include(e => e.Masterpelanggan)
                .ThenInclude(e => e.LokasiKota);

            HorderQ = HorderQ.Include(e => e.Dorder )
                 .ThenInclude(e => e.Masterbarang)
                 .ThenInclude(e => e.Mastertipebarang);
            return HorderQ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorderResultDto>>> GetOrder([FromQuery] GetOrderRequest dto)
        {
            var HorderQ = BaseHorderQuery(dto);
            var HorderPagingQ = HorderQ;
            var totalRow = await HorderPagingQ.CountAsync();

            HorderQ = HorderQ.OrderByDescending(x => x.Tglorder);

            int skip = (dto.Page - 1) * dto.PageSize;
            HorderQ = HorderQ.Skip(skip)
                    .Take(dto.PageSize);
            HorderQ = IncludeHorderRelation(HorderQ, dto);

            var Horder = await HorderQ.ToListAsync();
            ICollection<HorderResult> HorderResults = _mapper.Map<ICollection<HorderResult>>(Horder);

            var totalPage = (int)Math.Ceiling((double)totalRow / dto.PageSize);
            var result = new HorderResultDto
            {
                Data = HorderResults,
                Page = dto.Page,
                PageSize = dto.PageSize,
                TotalPage = totalPage,
                TotalRow = totalRow
            };
            return Ok(result);
        }

        [HttpGet("find", Name = "FindOrder")]
        public async Task<ActionResult<HorderResult>> FindOrder([FromQuery] FindOrderRequest dto)
        {
            var HorderQ = BaseHorderQuery(dto);
            HorderQ = IncludeHorderRelation(HorderQ, dto);
            var result = await HorderQ.FirstOrDefaultAsync();
            if (result == null)
            {
                return BadRequest(new { message = "Orderan tidak ditemukan" });
            }
            if (dto?.CheckTransaksi == true)
            {
                result.NoSeriOnline?.Dump();
                var checkNoSeri = await _context.Htrans
                        .Where(e => e.NoSeriOnline == result.NoSeriOnline || e.NoSeriOnline == result.NoSeriOnline.Trim())
                        .FirstOrDefaultAsync();
                if (checkNoSeri != null)
                {
                    return BadRequest(new { message = "Tidak bisa disimpan karena No Seri Online sudah pernah ada" });
                }
            }
            HorderResult horderResult = _mapper.Map<HorderResult>(result);
            return Ok(horderResult);
        }


        private Masteruser? getUser()
        {
            var user = (Masteruser)HttpContext.Items["User"];
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult> SaveOrder([FromBody] SaveOrderDto dto)
        {
            var validationResult = await _SaveOrderValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();

                // Return a BadRequestObjectResult with the error messages
                return StatusCode(422, new { Errors = errorMessages });
            }

            var lastKodeh = await _context.Horder.MaxAsync(e => e.Kodeh);
            var kodeh = 1;
            if (lastKodeh != null)
            {
                kodeh = lastKodeh + 1;
            }
            var user = getUser();
            var entity = _mapper.Map<Horder>(dto);
            entity.Kodeh = kodeh;
            entity.Insertname = (sbyte)user?.Kodeku;
            entity.Inserttime = DateTime.Now;
            entity.Historynya = 3;
            if (user.Akses.ToLower() == "salesonline" ||
               user.Akses.ToLower() == "managersalesonline" ||
               user.Akses.ToLower() == "managerbusiness")
            {
                entity.Historynya = 5;
            }
            _context.Horder.Add(entity);
            using (var transaction = _context.Database.BeginTransaction())//Begin Transaction
            {
                try
                {
                    await _context.SaveChangesAsync();
                    var dorder = _mapper.Map<List<Dorder>>(dto.Details);
                    await InsertToDorder(entity.Kodeh, dorder);
                    transaction.Commit();
                    return Ok(lastKodeh);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest(ex.Message);
                }
            }
        }

        /// <summary>
        /// Update Order by kode
        /// </summary>
        ///  
        /// <param name="kode"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{kode}")]
        public async Task<ActionResult> UpdateOrder(int kode, [FromBody] SaveOrderDto dto)
        {
            var Horder = await _context.Horder.Where(e => e.Kodeh == kode).FirstOrDefaultAsync();
            if (Horder == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, Horder);
            var user = getUser();

            Horder.Updatename = (sbyte)user?.Kodeku;
            Horder.Updatetime = DateTime.Now;
            using (var transaction = _context.Database.BeginTransaction())//Begin Transaction
            {

                try
                {
                    await _context.SaveChangesAsync();
                    var deleteDorder = _context.Dorder.Where(e => e.Kodeh == kode);
                    if (deleteDorder.Any())
                    {
                        _context.Dorder.RemoveRange(deleteDorder);
                        await _context.SaveChangesAsync();
                    }
                    var dorder = _mapper.Map<List<Dorder>>(dto.Details);
                    await InsertToDorder(kode, dorder);
                    await _webSocket.SendToAll("order", _mapper.Map<HorderResult>(Horder));

                    transaction.Commit();
                    return Ok(Horder);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ConsoleDump.Extensions.Dump(ex);
                    return BadRequest(ex.Message);
                }
            }
        }


        /// <summary>
        /// Update header Order by kode
        /// </summary>
        /// <param name="kode"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{kode}/header", Name = "UpdateOrderHeader")]
        public async Task<ActionResult> UpdateOrderHeader(int kode, [FromBody] SaveOrderHeaderDto dto)
        {
            var Horder = await _context.Horder.Where(e => e.Kodeh == kode).FirstOrDefaultAsync();
            if (Horder == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, Horder);
            var user = getUser();

            Horder.Updatename = (sbyte)user?.Kodeku;
            Horder.Updatetime = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(Horder);
        }

        [HttpDelete("{kode}/header", Name = "CancelOrderHeader")]
        public async Task<ActionResult> CancelOrderHeader(int kode)
        {
            var horder = await _context.Horder.Where(e => e.Kodeh == kode)
                    .Where(e => e.Lunas == 0)
                    .FirstOrDefaultAsync();
            if (horder == null)
            {
                return BadRequest(new { message = "OrderData Detail harus dicek dulu semua nya" });
            }
            string query = "UPDATE horder SET historynya = 1, dicetak = 1 " +
               $"WHERE kodeh = {kode}";
            await _context.Database.ExecuteSqlRawAsync(query);
            return Ok();
        }

        [HttpDelete("{kode}/detail", Name = "CancelOrderDetail")]
        public async Task<ActionResult> CancelOrderDetail(int kode, [FromBody] CancelOrderDetailDto dto)
        {
            var dorder = await _context.Dorder
                .Where(e => e.Kodeh == kode)
                .Where(e => e.Koded == dto.koded)
                .FirstOrDefaultAsync();
            if (dorder == null)
            {
                return BadRequest(new { message = "Detail order tidak ditemukan" });
            }
            dorder.Lunas = (sbyte) dto.kodecancel;
            dorder.Keterangancancel = dto.keterangancancel;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{kode}/set-penyiap", Name = "SetPenyiapOrder")]
        public async Task<ActionResult> SetPenyiapOrder(int kode, [FromBody] SetPenyiapOrderDto dto)
        {
            var Horder = await _context.Horder
                .Include(e => e.Dorder)
                .Include(e => e.Sales)
                .Where(e => e.Kodeh == kode)
                .FirstOrDefaultAsync();
            if (Horder == null)
            {
                return BadRequest(new { message = "Order tidak ditemukan" });
            }

            if (Horder.Historynya >= 4)
            {
                return BadRequest(new { message = "Tidak bisa set penyiap karena Trans Online belum dicek" });
            }

            var penyiap = await _context.Penyiaporder.FindAsync(dto.Kodepenyiap);
            if (penyiap == null)
            {
                return BadRequest(new { message = "Penyiap tidak ditemukan" });
            }
            var totalHutang = (await _context.Htrans
                .Where(e => e.Lunas == "0")
                .Where(e => e.KodePelanggan == Horder.Kodepelanggan)
                .SumAsync(e => e.Jumlah));
            var totalDorder = Horder.Dorder.Sum(e => e.Jumlah * e.Harga);
            totalHutang += totalDorder;
            var pelanggan = await _context.Masterpelanggan
                .Include(e => e.LokasiKota)
                .Where(e => e.Kode == Horder.Kodepelanggan)
                .FirstOrDefaultAsync();
            if (pelanggan == null)
            {
                return BadRequest(new { message = "Pelanggan tidak ditemukan" });
            }
            var user = getUser();
            var isPaksa = !String.IsNullOrEmpty(dto.Password);

            var validPaksa = false;
            var validPassword = dto.Password == user?.Passwordku;
            if (dto.Password != null && validPassword)
            {
                validPaksa = true;
            }
            if (totalHutang >= pelanggan.BatasOmzet && pelanggan.BatasOmzet > 0 && !validPaksa)
            {
                return BadRequest(new
                {
                    message = "Pelanggan dalam limit",
                    errorType = "LIMIT_TRANSAKSI",
                    data = new
                    {
                        limitMessage = $"Nama Toko: {pelanggan.Nama} - {pelanggan.LokasiKota.Nama}\n" +
                    $"Sales: {Horder.Sales.Nama}\n" +
                    $"Tipe: {Horder.Tipetempo} Hari\n" +
                    $"Jatuh Tempo: {Horder.Tgltempo.ToString("dd/MM/yyyy")}\n" +
                    $"Limit Diberikan: {pelanggan.BatasOmzet.ToString("N0")}, " +
                    $"Total Utang akan menjadi: {totalHutang.ToString("N0")}, " +
                    $"TOKO AKAN OVERLIMIT. TETAP PAKSAKAN ?",
                        isPasswordError = isPaksa ? true : false
                    }
                });
            }

            Horder.Kodepenyiap = dto.Kodepenyiap;
            Horder.Historynya = 2;
            await _context.SaveChangesAsync();
            return Ok(Horder);
        }

        [HttpPut("{kode}/tim-online-cek", Name = "TimOnlineCek")]
        public async Task<ActionResult> TimOnlineCek(int kode)
        {
            var profilPerush = await _context.Profileperush.FirstOrDefaultAsync();
            if (profilPerush == null)
            {
                return BadRequest(new { message = "Default penyiap tidak ditemukan" });
            }
            var horder = await _context.Horder
                .Include(e => e.Dorder)
                .Include(e => e.Sales)
                .Include(e => e.Ekspedisi)
                .Include(e => e.Masterpelanggan)
                .ThenInclude(e => e.LokasiKota)
                .Where(e => e.Kodeh == kode)
                .FirstOrDefaultAsync();
            if (horder == null)
            {
                return BadRequest(new { message = "Orderan tidak ditemukan" });
            }
            horder.Kodepenyiap = (sbyte)profilPerush.KodePenyiap;

            if (
                horder.Masterpelanggan?.LokasiKota?.AdaKertasOrder == 1 &&
                horder.Ekspedisi?.OllangusungCetak == 1
               )
            {
                horder.Historynya = 2;
                horder.Dicetak = 1;
                horder.Tglcetak = DateTime.Now;
            }

            _context.Update(horder);
            await _context.SaveChangesAsync();
            HorderResult horderResult = _mapper.Map<HorderResult>(horder);
            return Ok();
        }

        [HttpGet("{kodeh}/{koded}/info")]
        public async Task<ActionResult<string>> InfoOrderan(int kodeh, int koded)
        {

            var dorder = await _context.Dorder
                .Where(e => e.Kodeh == kodeh)
                .Where(e => e.Koded == koded)
                .FirstAsync();
            var horder = await _context.Horder
                .Where(e => e.Kodeh == kodeh)
                .FirstOrDefaultAsync();
            dorder.Dump();
            var message = "";
            if (horder == null || dorder == null)
            {
                return BadRequest(new { message = "Orderan tidak ditemukan"});
            }
          
            if (dorder.Lunas == 0)
            {
                message = "Orderan ini belum disiapkan";
            }

            if (dorder.Lunas == 3)
            {
                message = $"Orderan ini DICANCEL, alasan : {dorder.Keterangancancel}";
            }

            var detailTrans = await _context.Dtrans
                    .AsNoTracking()
                    .Include(e => e.Htrans)
                    .Include(e => e.Masterbarang)
                    .Where(e => e.Kodeh == dorder.KodehTrans)
                    .Where(e => e.Koded == dorder.KodedTrans)
                    .FirstOrDefaultAsync();

            if (dorder.Lunas == 1)
            {
                message = $"ORDERAN INI MASI KURANG KIRIM\r\n\r\n";
            } else
            {
                if (dorder.Keterangancancel == "")
                {
                    message = $"ORDERAN INI BERES\r\n\r\n";
                } else
                {
                    message = $"ORDERAN INI DIPAKSA BERES, alasan : {dorder.Keterangancancel}\r\n\r\n";
                }
            }
            detailTrans?.Htrans.Dump();
            message += $"Disiapkan Pada : \r\n";
            message += $"{detailTrans?.Htrans?.TglTrans.ToString("dd/MM/yyyy")} \r\n";
            message += $"{detailTrans?.Jumlah} {detailTrans?.Masterbarang?.BrgNama}";
            return Ok(message);
        }

        [HttpGet("{kode}/print")]
        public async Task<ActionResult<PrintOrderResultDto>> PrintOrderan(int kode)
        {
            int counterCetak, jumNotaTrans, jumNotaRetur;
            string TotalBarangLabel = "";
            string JumlahKirimanLabel = "";
            bool StatusBlok;
            PrintHorderDto horderResult;
            List<PrintDorderDto> dorderResult;
            sbyte printOL = 0;
            var horder = await _context.Horder
                .AsNoTracking()
                .Include(e => e.Masterpelanggan)
                .ThenInclude(e => e.LokasiKota)
                .Where(e => e.Kodeh == kode)
                .FirstOrDefaultAsync();

            if (horder == null || horder?.Historynya == 3)
            {
                return BadRequest(new { message = "Data Tidak Ada" });

            }

            var kodeProvinsi = horder.Masterpelanggan?.LokasiKota?.Provinsi;
            printOL = 0;
            kodeProvinsi.Dump("KODEPROV");
            //if (getUser()?.Akses == "gudangol" && kodeProvinsi == 23)
            if (kodeProvinsi == 23)
            {
                printOL = 1;
            }

            if (horder.Masterpelanggan?.KursKomisi <= 0)
            {
                return BadRequest(new { message = "TOKO DIBLOK !! HUBUNGI ADMIN !!" });
            }
            if (horder.Kodepenyiap == 0)
            {
                return BadRequest(new { message = "Harap Tentukan Penyiap Orderan Terlebih Dahulu" });
            }

            horder.Dicetak += 1;
            await _context.SaveChangesAsync();

            var query = from h in _context.Horder
                        join p in _context.Masterpelanggan on h.Kodepelanggan equals p.Kode
                        join s in _context.Sales on h.Kodesales equals s.Kode
                        join mtp in _context.Masterpengeluaran on h.Kodeexp equals mtp.Kode
                        join k in _context.LokasiKota on p.Kota equals k.Kode
                        join pr in _context.LokasiProvinsi on k.Provinsi equals pr.Kode
                        join po in _context.Penyiaporder on h.Kodepenyiap equals po.Kode
                        where h.Kodeh == kode
                        orderby h.Kodeh descending
                        select new PrintHorderDto
                        {
                            KodeH = h.Kodeh,
                            InfoPenting = h.Infopenting,
                            Keterangan = h.Keterangan,
                            Tanggal = h.Tglorder.ToString("dd/MM/yyyy"),
                            Nama = $"{p.Nama} - {k.Nama}",
                            NamaSales = s.Nama,
                            Lokasi = $"{k.Nama} - {pr.Nama}",
                            PenyiapOrder = po.Nama,
                            TanggalInput = h.Inserttime.ToString("dd/MM/yyyy HH:mm:ss"),
                            TanggalCetak = h.Tglcetak.ToString("dd/MM/yyyy HH:mm:ss"),
                            NamaExp = mtp.Nama,
                            Melalui = h.Kirimmelalui == 0 ? "Belum Diisi" :
                                      h.Kirimmelalui == 1 ? "DARAT" :
                                      h.Kirimmelalui == 2 ? "UDARA" : "LAUT"
                        };
            horderResult = await query.FirstAsync();
            var dorderQuery = from d in _context.Dorder
                              join b in _context.Masterbarang on d.Kodebarang equals b.BrgKode
                              where d.Kodeh == kode
                              orderby d.Koded ascending
                              select new PrintDorderDto
                              {
                                  NamaKeterangan = b.BrgNama + " ///// KET : " + d.Keterangan,
                                  NamaBarang = b.BrgNama,
                                  Pcs = d.Jumlah,
                                  KeteranganBrg = d.Keterangan,
                                  StokAtas = 0,
                                  StokBawah = 0,
                                  StokSales = 0
                              };

             dorderResult = await dorderQuery.ToListAsync();


            if (printOL == 1)
            {
                TotalBarangLabel = $"Total Varian Barang : {dorderResult.Count.ToString()}";
            }
            else
            {
                if (kodeProvinsi == 23)
                {
                    JumlahKirimanLabel = $"SERI OL : {horder.NoSeriOnline}";
                }
                else
                {
                    JumlahKirimanLabel = "Nota lainnya : ";
                    jumNotaTrans = _context.Htrans.Where(e => e.KodePelanggan == horder.Kodepelanggan)
                            .Where(e => e.HistoryNya == Constants.DEFAULT_HISTORY_TRANSAKSI)
                            .Where(e => e.Dikirim == 0)
                            .Where(e => e.Retur == "0")
                            .Count();

                    jumNotaRetur = _context.Htrans.Where(e => e.KodePelanggan == horder.Kodepelanggan)
                           .Where(e => e.HistoryNya == Constants.DEFAULT_HISTORY_TRANSAKSI)
                           .Where(e => e.Dikirim == 0)
                           .Where(e => e.Retur != "0")
                           .Count();
                    JumlahKirimanLabel += jumNotaTrans.ToString() + " N, ";
                    JumlahKirimanLabel += jumNotaRetur.ToString() + " R";

                }
                StatusBlok = horder?.Masterpelanggan?.KursKomisi < 0;
            }

            return new PrintOrderResultDto
            {
                Horder = horderResult,
                Dorder = dorderResult,
                JumlahKirimanLabel = JumlahKirimanLabel,
                PrintOl = printOL,
                TotalBarangLabel = TotalBarangLabel
            };
        }

        private async Task InsertToDorder(int kodeh, List<Dorder> dtrans)
        {
            for (short i = 0; i < dtrans.Count; i++)
            {
                dtrans[i].Koded = (short)(i + 1);
                dtrans[i].Kodeh = kodeh;
            }

            string insertQuery = "INSERT INTO dorder (kodeh,koded,kodebarang,jumlah,harga,keterangan) VALUES ";
            string values = string.Join(", ", dtrans.Select(item => $"({item.Kodeh},{item.Koded},{item.Kodebarang},{item.Jumlah},{item.Harga},'{item.Keterangan}')"));
            insertQuery += values;
            await _context.Database.ExecuteSqlRawAsync(insertQuery);
        }
    }
}
