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
using DoranOfficeBackend.Dtos.Masterpelanggan;
using DoranOfficeBackend.Dtos.Transaksi;
using Microsoft.AspNetCore.Mvc.Filters;
using StackExchange.Profiling.Internal;
using ConsoleDump;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using DocumentFormat.OpenXml.InkML;
using MySqlX.XDevAPI;
using ZstdSharp.Unsafe;

namespace DoranOfficeBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Auth]
    [Produces("application/json")]
    public class TransaksiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;
        public TransaksiController(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HtransResultDto>>> GetTransaksi([FromQuery] FindTransaksiDto dto)
        {
            var htransQ = _context.Htrans
                .AsNoTracking()
                .AsQueryable();


            if (dto.MinDate.HasValue)
            {
                var minDate = new DateTime(dto.MinDate.Value.Year, dto.MinDate.Value.Month, dto.MinDate.Value.Day, 0, 0, 0);
                htransQ = htransQ.Where(x => x.TglTrans >= minDate);
            }

            if (dto.MaxDate.HasValue)
            {
                var maxDate = new DateTime(dto.MaxDate.Value.Year, dto.MaxDate.Value.Month, dto.MaxDate.Value.Day, 23, 59, 59);
                htransQ = htransQ.Where(x => x.TglTrans <= maxDate);
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

            //var htransPagingQ = htransQ;
            //var totalRow = await htransPagingQ.CountAsync();

            htransQ = htransQ.OrderByDescending(x => x.KodeH);

            //if (dto.Limit.HasValue)
            //{
            //    htransQ = htransQ.Take(dto.Limit.Value);
            //}
            if (!String.IsNullOrEmpty(dto.NamaPelanggan))
            {
                htransQ = htransQ.Take(30);
            }
            else
            {
                htransQ = htransQ.Take(300);
            }
            //int skip = (dto.Page - 1) * dto.PageSize;
            //htransQ = htransQ.Skip(skip)
            //        .Take(dto.PageSize);
            htransQ = htransQ.Include(e => e.Dtrans)
                .ThenInclude(e => e.Masterbarang)
                .Include(e => e.Masterpelanggan)
                .ThenInclude(e => e.LokasiKota)
                .ThenInclude(e => e.LokasiProvinsi)
                .Include(e => e.Sales)
                .Include(e => e.Mastergudang);

            var htrans = await htransQ.ToListAsync();
            ICollection<HtransResult> htransResults = _mapper.Map<ICollection<HtransResult>>(htrans);
            //var totalPage = (int)Math.Ceiling((double)totalRow / dto.PageSize);
            //var result = new HtransResultDto
            //{
            //    Data = htransResults,
            //    Page = dto.Page,
            //    PageSize = dto.PageSize,
            //    TotalPage = totalPage,
            //    TotalRow = totalRow
            //};
            return Ok(htransResults);
        }

        [HttpGet("{kodeh}")]
        public async Task<ActionResult<HtransResult>> GetTransaksiByKodeh(int kodeh)
        {
            var htrans = await _context.Htrans
               .AsNoTracking()
               .Where(e => e.KodeH == kodeh)
               .Include(e => e.Dtrans)
             .ThenInclude(e => e.Masterbarang)
             .Include(e => e.Masterpelanggan)
             .ThenInclude(e => e.LokasiKota)
             .Include(e => e.Sales)
             .Include(e => e.Mastergudang)
             .Include(e => e.MasteruserInsert)
             .FirstOrDefaultAsync();
            if (htrans == null) {
                return BadRequest(new { message = "Transaksi tidak ditemukan" });
            }
            var result = _mapper.Map<HtransResult>(htrans);
            return result;
             
        }

            [HttpGet("{kodeh}/nota-ppn")]
        public async Task<ActionResult<NotaTransaksiPpnResultDto>> GetNotaTransaksiPpn(int kodeh)
        {
            var htransCheck = await _context.Htrans.Where(e => e.KodeH == kodeh).Select(e => new
            {
                e.Terbitfakturppn,
                e.Retur,
                e.TglTrans
            }).FirstOrDefaultAsync();
            double PEMBAGI_PPN = 0;
            if (htransCheck == null)
            {
                return BadRequest(new { message = "Data tidak ditemukan" });
            }
            if (htransCheck.Terbitfakturppn == false || htransCheck.Retur != "0")
            {
                return BadRequest(new { message = "Data tidak ditemukan" });
            }
            if (htransCheck.TglTrans.Month <= 2022 && htransCheck.TglTrans.Month <= 3)
            {
                PEMBAGI_PPN = Constants.PEMBAGI_PPN10;
            }
            else
            {
                PEMBAGI_PPN = Constants.PEMBAGI_PPN11;
            }
            var htransQ = _context.Htrans
                .AsNoTracking()
                .Where(e => e.KodeH == kodeh)
                .Include(e => e.Dtrans)
              .ThenInclude(e => e.Masterbarang)
              .Include(e => e.Masterpelanggan)
              .ThenInclude(e => e.LokasiKota)
              .Include(e => e.Sales)
              .Include(e => e.Mastergudang)
              .Include(e => e.MasteruserInsert)
              .Select(h => new NotaTransaksiPpnResultDto
              {
                  Kodenota = h.Kodenota,
                  Tambahanlainnya = h.TambahanLainnya,
                  Diskon = h.Diskon,
                  Kodeh = h.KodeH,
                  Dpp = h.Dpp,
                  Ppn = h.Ppn,
                  Diskonppn = -1 * h.Ppn,
                  Tanggal = h.TglTrans,
                  TglPPN = h.TglPpn,
                  Infopenting = h.Infopenting,
                  Tgltempo = h.Tgltempo,
                  Tipetempo = "-",
                  Nama = h.Masterpelanggan.Nama,
                  Jumlah = h.Jumlah,
                  Oleh = h.MasteruserInsert.Usernameku,
                  Namasales = h.Sales.Nama,
                  Lokasi = $"{h.Masterpelanggan.LokasiKota.Nama} - {h.Masterpelanggan.LokasiKota.LokasiProvinsi.Nama}",
                  Detail = h.Dtrans.Select(d => new DetailNotaTransaksiPpnResultDto
                  {
                      Namabarang = d.Masterbarang.BrgNama,
                      Pcs = d.Jumlah,
                      Kodebarang = d.Kodebarang,
                      Harganya = d.Harga,
                      Hargabelumppn = (decimal)(Math.Round(d.Harga / PEMBAGI_PPN)),
                      Subtotalbelumppn = (decimal)(Math.Round(d.Harga / PEMBAGI_PPN) * d.Jumlah),
                      TotalNya = d.Jumlah * d.Harga
                  }).ToList(),
                  TotalNya = h.Dtrans.Sum(d => d.Jumlah * d.Harga),
              });

            var htrans = await htransQ.FirstOrDefaultAsync();
            if (htrans == null)
            {
                return BadRequest(new { message = "Transaksi tidak ditemukan" });
            }
            return Ok(htrans);
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
        public async Task<ActionResult> SaveTransaksi([FromBody] SaveTransaksiDto dto)
        {
            var jumlahHutang = await _context.Htrans
                .Where(e => e.Lunas == "0" && e.KodePelanggan == dto.KodePelanggan)
                .SumAsync(e => e.Jumlah);
            var pelanggan = await _context.Masterpelanggan
                .Where(e => e.Kode == dto.KodePelanggan)
                .Include(e => e.LokasiKota)
                .FirstOrDefaultAsync();
            var user = getUser();
            if (pelanggan == null)
            {
                return BadRequest(new { message = $"Pelanggan tidak ditemukan" });
            }
            var currentTotal = dto.Details.Sum(e => e.Harga * e.Jumlah);
            if (
                currentTotal + jumlahHutang > pelanggan.BatasOmzet
                && pelanggan.BatasOmzet > 0
                && user?.Akses?.ToLower() != "bos"
                && dto.Force == false
                )
            {
                return BadRequest(new
                {
                    message = "Pelanggan dalam limit",
                    errorType = "LIMIT_TRANSAKSI",
                    data = new
                    {
                        limitMessage = $"Pelanggan \"{pelanggan.Nama}-{pelanggan.LokasiKota.Nama}\" Limit diberikan = " +
                    $"{pelanggan.BatasOmzet.ToString("N0")}. Total Utang akan menjadi = " +
                    $"{(currentTotal + jumlahHutang).ToString("N0")}, TOKO AKAN OVERLIMIT. TETAP PAKSAKAN ?",
                        isTokenError = false
                    }
                });
            }

            Horder? horder = null;
            if (dto.NoOrder.HasValue && dto.NoOrder != 0)
            {
                horder = await _context.Horder
                        .AsNoTracking()
                        .Include(e => e.Dorder)
                        .Where(e => e.Kodeh == dto.NoOrder)
                        .FirstOrDefaultAsync();
                if (horder == null)
                {
                    return BadRequest(new { message = "Kode order tidak ditemukan" });
                }
                var checkNoSeri = await _context.Htrans
                        .Where(e => e.NoSeriOnline == horder.NoSeriOnline || e.NoSeriOnline == horder.NoSeriOnline.Trim())
                        .FirstOrDefaultAsync();
                if (checkNoSeri != null)
                {
                    return BadRequest(new { message = "Tidak bisa disimpan karena No Seri Online sudah pernah ada" });
                }

            }

            var entity = _mapper.Map<Htrans>(dto);

            using (var transaction = _context.Database.BeginTransaction())//Begin Transaction
            {
                var tryCreate = true;
                while (tryCreate)
                {
                    try
                    {
                        var kodeh = await GetLastKodeh();
                        var noTrans = await GetLastNoTrans();
                        var kodeNota = GetKodeNota(noTrans);

                        entity.HistoryNya = Constants.DEFAULT_HISTORY_TRANSAKSI;
                        entity.Kodenota = kodeNota;
                        entity.Notrans = noTrans;
                        entity.KodeH = kodeh;
                        entity.InsertName = (sbyte)user?.Kodeku;
                        entity.InsertTime = DateTime.Now;
                        entity.AkanDjJurnalkan = pelanggan.DefaultJurnalPenjualan;


                        if (pelanggan.DefaultJurnalPenjualan == 1)
                        {
                            entity.Ppnreal = dto.Ppn;
                        }
                        else
                        {
                            entity.Dpp = 0;
                            entity.Ppn = 0;
                            entity.Ppnreal = 0;
                        }

                        if (dto.Terbitfakturppn)
                        {
                            entity.Ppn = 0;
                        }


                        _context.Htrans.Add(entity);
                        await _context.SaveChangesAsync();

                        var dtrans = _mapper.Map<List<Dtrans>>(dto.Details);
                        var jumlahKomisi = await InsertToDtrans(entity.KodeH, dtrans, pelanggan, user, horder);

                        if (entity.NoOrder != null || entity.NoOrder != 0)
                        {
                            for (var i = 0; i < dtrans.Count; i++)
                            {
                                var dorder = await _context.Dorder
                                     .Where(e => e.Koded == i + 1 && e.Kodeh == dto.NoOrder)
                                     .FirstOrDefaultAsync();
                                if (dorder != null)
                                {
                                    dorder.KodehTrans = entity.KodeH;
                                    dorder.KodedTrans = (sbyte)(i + 1);
                                    dorder.Jumlahdikirim = dtrans[i].Jumlah;
                                    dorder.Sisa = dorder.Jumlah - dtrans[i].Jumlah;
                                    dorder.Lunas = (sbyte)(dto.Tipetempo == 0 ? 2 : 0);
                                    _context.Dorder.Update(dorder);
                                }
                            }
                        }

                        if (horder != null)
                        {
                            horder.Historynya = 1;
                            _context.Horder.Update(horder);
                        }

                        if (pelanggan.LokasiKota?.Provinsi != 23)
                        {
                            entity.JumlahKomisi = jumlahKomisi;
                        }

                        var logFile = new Logfile
                        {
                            Keterangan = $"Tambah Trans Penjualan No : {entity.KodeH}" +
                            $"",
                            Username = getUser()?.Kodeku ?? 0,
                            Tanggal = DateTime.Now
                        };
                        _context.Logfile.Add(logFile);
                        await _context.SaveChangesAsync();

                        transaction.Commit();
                        tryCreate = false;
                        //transaction.Rollback();
                        //entity.Dump();
                    }
                    catch (DbUpdateException ex)
                    {
                        transaction.Rollback();
                        var isHtransTable = false;

                        foreach (var entry in ex.Entries)
                        {
                            // Now 'GetTableName' contains the name of the table that caused the exception
                            if (entry.Metadata.GetTableName() == "htrans")
                            {
                                isHtransTable = true;
                            }
                        }

                        if (isHtransTable &&
                            ex.InnerException is MySqlException sqlException &&
                            (sqlException.Number == 1062))
                        {
                            // Retry if a duplicate exception occurred.
                            tryCreate = true;

                        }
                        else
                        {
                            tryCreate = false;
                            throw;
                        }
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        tryCreate = false;
                        throw;
                    }
                }
            }
            return Ok();
        }

        [HttpPut("{kode}")]
        public async Task<ActionResult<Htrans>> UpdateTransaksi(int kode, [FromBody] UpdateTransaksiDto dto)
        {
            var htrans = await _context.Htrans
                .Where(e => e.KodeH == kode)
                .FirstOrDefaultAsync();


            if (htrans == null)
            {
                return NotFound();
            }

            var user = getUser();
            if (user == null)
            {
                return BadRequest(new
                {
                    message = "User anda tidak ditemukan, coba login ulang"
                });
            }

            var pelanggan = await _context.Masterpelanggan
              .Where(e => e.Kode == dto.KodePelanggan)
              .Include(e => e.LokasiKota)
              .FirstOrDefaultAsync();
            if (pelanggan == null)
            {
                return BadRequest(new { message = $"Pelanggan tidak ditemukan" });
            }

            var anyErrorMessage = await CekDataUpdate(htrans, user);
            if (!String.IsNullOrEmpty(anyErrorMessage))
            {
                return BadRequest(new { message = anyErrorMessage });
            }

            var tempHtrans = await _context.Htrans
                .AsNoTracking()
                .Include(e => e.Masterpelanggan)
                .Include(e => e.Mastergudang)
                .Where(e => e.KodeH == kode)
                .FirstOrDefaultAsync();

            var tempDtrans = await _context.Dtrans
                .AsNoTracking()
                .Where(e => e.Kodeh == htrans.KodeH)
                .ToListAsync();

            var horder = await _context.Horder
                .Where(e => e.Kodeh == htrans.NoOrder)
                .FirstOrDefaultAsync();

            _mapper.Map(dto, htrans);
            var dtrans = _mapper.Map<List<Dtrans>>(dto.Details);
            htrans.Ppnreal = dto.Ppn;

            using (var transaction = _context.Database.BeginTransaction())//Begin Transaction
            {
                try
                {
                    if (pelanggan.DefaultJurnalPenjualan != 1)
                    {
                        htrans.Dpp = 0;
                        htrans.Ppn = 0;
                        htrans.Ppnreal = 0;
                    }

                    string updateQuery = $"UPDATE barangSN SET " +
                        $"kodehjual = 0, kodedjual = 0, " +
                        $"status = 1, " +
                        $"insertnamejual = {user.Kodeku}, " +
                        $"inserttimejual = '{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}' " +
                        $"WHERE kodehjual = {kode}";
                    await _context.Database.ExecuteSqlRawAsync(updateQuery);

                    string deleteDtransQ = $"DELETE from dtrans where kodeh = {kode}";
                    await _context.Database.ExecuteSqlRawAsync(deleteDtransQ);

                    int kodeUpdate = await GetKodeUpdate();
                    var updateDOrder = "";
                    if (htrans.NoOrder > 0)
                    {
                        for (short i = 0; i < dtrans.Count; i++)
                        {
                            if (dto.HanyaGantiHarga == false)
                            {
                                if (updateDOrder != "")
                                {
                                    updateDOrder += " OR ";
                                }
                                updateDOrder += $" (kodeh = {htrans.NoOrder} AND koded = {(i + 1)}) ";
                            }
                        }

                        if (updateDOrder != "")
                        {
                            updateDOrder = $"UPDATE dorder SET " +
                                $"{(dto.CancelOrder ? "lunas=0," : "")}" +
                                $"kodehtrans = 0,kodedtrans = 0 " +
                                $"WHERE ({updateDOrder})";
                            updateDOrder.Dump();
                            await _context.Database.ExecuteSqlRawAsync(updateDOrder);
                        }
                    }
                    await _context.Entry(htrans).Reference(e => e.Masterpelanggan).LoadAsync();
                    await _context.Entry(htrans).Reference(e => e.Mastergudang).LoadAsync();
                    var komisi = await UpdateToDtrans(
                        htrans, dtrans, pelanggan, user, horder, tempHtrans, tempDtrans, false, false
                        ); ;
                    htrans.JumlahKomisi = komisi;
                    htrans.UpdateName = (sbyte)user?.Kodeku;
                    htrans.UpdateTime = DateTime.Now;
                    htrans.HistoryNya = Constants.DEFAULT_HISTORY_TRANSAKSI;

                    _context.Update(htrans);
                    await _context.SaveChangesAsync();

                    var logFile = new Logfile
                    {
                        Keterangan = $"Update Trans Penjualan No : {htrans.KodeH}",
                        Username = getUser()?.Kodeku ?? 0,
                        Tanggal = DateTime.Now
                    };
                    _context.Logfile.Add(logFile);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                    return Ok(htrans);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        [HttpPut("{kode}/cancel")]
        public async Task<ActionResult<Htrans>> CancelTransaksi(int kode)
        {
            var htrans = await _context.Htrans
               .Where(e => e.KodeH == kode)
               .FirstOrDefaultAsync();

            if (htrans == null)
            {
                return BadRequest(new
                {
                    message = "Htrans tidak ditemukan"
                });
            }

            var user = getUser();
            if (user == null)
            {
                return BadRequest(new
                {
                    message = "User anda tidak ditemukan, coba login ulang"
                });
            }

            var anyErrorMessage = await CekDataUpdate(htrans, user);
            if (!String.IsNullOrEmpty(anyErrorMessage))
            {
                return BadRequest(new { message = anyErrorMessage });
            }


            return Ok(htrans);
        }

        private async Task<string?> CekDataUpdate(Htrans htrans, Masteruser user)
        {

            if (htrans.Retur == "2")
            {
                return "Harus Update menggunakan Program Returan. Serahkan pada Doran Care";
            }

            var bisaUpdate = false;
            if (user.Akses.ToLower() != "bos" && user.Akses.ToLower() != "supermasteraudit")
            {
                if ((user.Akses.ToLower() == "kagud" || user.Akses.ToLower() == "masterkagud")
                    && Convert.ToInt32(htrans.HistoryNya) >= Constants.DEFAULT_HISTORY_TRANSAKSI_INT)
                {
                    bisaUpdate = true;
                }
                else if (user.Akses.ToLower() == "seketaris"
                         && Convert.ToInt32(htrans.HistoryNya) > 3)
                {
                    bisaUpdate = true;
                }
                else if ((user.Akses.ToLower() == "masteradmin"
                          || user.Akses.ToLower() == "masteradmin2"
                          || user.Akses.ToLower() == "mastersuperadmin")
                         && Convert.ToInt32(htrans.HistoryNya) > 2)
                {
                    bisaUpdate = true;
                }
                else if ((user.Akses.ToLower() == "auditor" || user.Akses.ToLower() == "masteraudit")
                         && Convert.ToInt32(htrans.HistoryNya) > 1)
                {
                    bisaUpdate = true;
                }
                else if (user.Akses.ToLower() == "masteraudit"
                         && Convert.ToInt32(htrans.HistoryNya) >= 1)
                {
                    bisaUpdate = true;
                }
            }
            else
            {
                bisaUpdate = true;
            }

            if (!bisaUpdate)
            {
                return "Maaf, Tidak bisa edit transaksi ini";
            }

            if (bisaUpdate &&
                user.Akses.ToLower() != "masteraudit" &&
                Convert.ToInt32(htrans.HistoryNya) != 0 &&
                htrans.HistoryNya != "")
            {
                return "Maaf, Tidak bisa edit karena tgl PPN Telah diSet";
            }

            var htransArsip = new Htransarsip();
            _mapper.Map(htrans, htransArsip);
            _context.Add(htransArsip);
            await _context.SaveChangesAsync();

            string dtransArsipSql = "INSERT INTO dtransarsip " +
            "(kodeh, koded, kodebarang, jumlah, harga, nmrSN) " +
            "SELECT kodeh, koded, kodebarang, jumlah, harga, nmrSN FROM dtrans " +
            $"WHERE kodeh = {htrans.KodeH}";

            await _context.Database.ExecuteSqlRawAsync(dtransArsipSql);

            return null;
        }
        private async Task LoadDtransMasterbarang(List<Dtrans> dtrans)
        {
            var masterbarangIds = dtrans.Select(d => d.Kodebarang).Distinct().ToList();

            // Bulk read Masterbarang entities
            var masterbarangEntities = _context.Masterbarang
                .Where(mb => masterbarangIds.Contains(mb.BrgKode))
                .ToList();

            // Create a dictionary for quick lookup based on MasterbarangId
            var masterbarangLookup = masterbarangEntities.ToDictionary(mb => mb.BrgKode);

            // Set the Masterbarang relationships for each DTrans object
            foreach (var d in dtrans)
            {
                if (masterbarangLookup.TryGetValue(d.Kodebarang, out var masterbarang))
                {
                    d.Masterbarang = masterbarang;
                }
            }
        }

        private async Task<int> InsertToDtrans(int kodeh, List<Dtrans> dtrans, Masterpelanggan pelanggan, Masteruser user, Horder? horder)
        {
            var totalKomisi = 0;
            var dorder = horder?.Dorder.OrderBy(e => e.Koded).ToList();

            LoadDtransMasterbarang(dtrans);

            for (short i = 0; i < dtrans.Count; i++)
            {
                dtrans[i].Koded = (short)(i + 1);
                dtrans[i].Kodeh = kodeh;

                // IF bukan online
                if (pelanggan.LokasiKota.Provinsi != 23)
                {
                    var komisi = (int)HitungKomisi(
                        Convert.ToDouble(dtrans[i].Masterbarang?.Modal),
                        Convert.ToDouble(dtrans[i].Harga),
                        (double)pelanggan.Potongan,
                        (double)0, (double)0,
                        (int)pelanggan.KursKomisi,
                        (int)(dtrans[i].Masterbarang?.Komisi ?? 0)
                   );
                    totalKomisi += (komisi * dtrans[i].Jumlah);
                }
                dtrans[i].Komisi = totalKomisi;
                if (dtrans[i].Nmrsn.Trim() != "")
                {
                    string updateQuery = $"UPDATE barangSN SET " +
                        $"kodehjual = {kodeh}, kodedjual = {dtrans[i].Koded}, " +
                        $"status = 1, " +
                        $"insertnamejual = {user.Kodeku}, " +
                        $"inserttimejual = '{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}' " +
                        $"WHERE (nmrSN = '{dtrans[i].Nmrsn}' OR nmrSN = '{dtrans[i].Nmrsn}\n') " +
                        $"AND kodebarang = {dtrans[i].Kodebarang}";
                    await _context.Database.ExecuteSqlRawAsync(updateQuery);
                }
                if (horder != null)
                {
                    if (dorder[i] == null)
                    {
                        continue;
                    }
                    var beresOrder = 1;
                    var sisaOrder = dorder[i].Jumlah - dtrans[i].Jumlah;
                    if (sisaOrder == 0)
                    {
                        beresOrder = 2;
                    }
                    string updateQuery = $"UPDATE dorder SET " +
                         $"kodehTrans = {kodeh}, " +
                         $"kodedTrans = {i}, " +
                         $"jumlahdikirim = {dtrans[i].Jumlah}, " +
                         $"sisa = {sisaOrder}, " +
                         $"lunas = {beresOrder} " +
                         $"WHERE kodeh = {horder.Kodeh} " +
                         $"AND koded = {dtrans[i].Koded};";
                    await _context.Database.ExecuteSqlRawAsync(updateQuery);
                }
            }

            //string insertQuery = "INSERT INTO dtrans (kodeh,koded,kodebarang,jumlah,harga,nmrsn) VALUES ";
            //string values = string.Join(", ", dtrans.Select(item => $"({item.Kodeh},{item.Koded},{item.Kodebarang},{item.Jumlah},{item.Harga},'{item.Nmrsn}')"));
            //insertQuery += values;
            //await _context.Database.ExecuteSqlRawAsync(insertQuery);
            await _context.BulkInsertAsync(dtrans);
            return totalKomisi;
        }
        private async Task<int> UpdateToDtrans(
            Htrans htrans, List<Dtrans> dtrans,
            Masterpelanggan pelanggan, Masteruser user, Horder? horder,
            Htrans tempHtrans,
            List<Dtrans?> tempDtrans,
            bool hanyaGantiHarga,
            bool penambahan
            )
        {
            var totalKomisi = 0;

            var dorder = horder?.Dorder?.OrderBy(e => e.Koded)?.ToList();
            var insertDUpdate = "";
            var kodeHUpdate = await GetListKodeHupdate();

            await LoadDtransMasterbarang(dtrans);
            for (short i = 0; i < dtrans.Count; i++)
            {
                dtrans[i].Koded = (short)(i + 1);
                dtrans[i].Kodeh = htrans.KodeH;

                // IF bukan online
                if (pelanggan.LokasiKota.Provinsi != 23)
                {
                    var komisi = (int)HitungKomisi(
                        Convert.ToDouble(dtrans[i].Masterbarang?.Modal),
                        Convert.ToDouble(dtrans[i].Harga),
                        (double)pelanggan.Potongan,
                        (double)0, (double)0,
                        (int)pelanggan.KursKomisi,
                        (int)(dtrans[i].Masterbarang?.Komisi ?? 0)
                   );
                    totalKomisi += (komisi * dtrans[i].Jumlah);
                }
                dtrans[i].Komisi = totalKomisi;
                if (dtrans[i].Nmrsn.Trim() != "")
                {
                    string updateQuery = $"UPDATE barangSN SET " +
                        $"kodehjual = {htrans.KodeH}, kodedjual = {i}, " +
                        $"status = 1, " +
                        $"insertnamejual = {user.Kodeku}, " +
                        $"inserttimejual = '{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}' " +
                        $"WHERE (nmrSN = '{dtrans[i].Nmrsn}' OR nmrSN = '{dtrans[i].Nmrsn}\n') " +
                        $"AND kodebarang = {dtrans[i].Kodebarang}";
                    await _context.Database.ExecuteSqlRawAsync(updateQuery);
                }
                if (horder == null)
                {
                    goto AfterCheckHorder;
                }
                if (dorder != null)
                {
                    var foundDorder = dorder.Where(e => e.KodedTrans == dtrans[i].Koded).FirstOrDefault();
                    if (foundDorder == null)
                    {
                        goto AfterCheckHorder;
                    }
                    var beresOrder = 1;
                    var sisaOrder = foundDorder.Jumlah - dtrans[i].Jumlah;
                    if (sisaOrder == 0)
                    {
                        beresOrder = 2;
                    }

                    string updateQuery = $"UPDATE dorder SET " +
                         $"kodehTrans = {htrans.KodeH}, " +
                         $"kodedTrans = {dtrans[i].Koded}, " +
                         $"jumlahdikirim = {dtrans[i].Jumlah}, " +
                         $"sisa = {sisaOrder}, " +
                         $"lunas = {beresOrder} " +
                         $"WHERE kodeh = {horder.Kodeh} " +
                         $"AND koded = {foundDorder.Koded};";
                    await _context.Database.ExecuteSqlRawAsync(updateQuery);

                    if (!hanyaGantiHarga)
                    {
                        var beresOrderNotGantiHarga = 1;
                        var sisaOrderNotGantiHarga = foundDorder.Jumlah - dtrans[i].Jumlah;
                        if (sisaOrderNotGantiHarga == 0)
                        {
                            beresOrder = 2;
                        }
                        string updateQueryDorder = $"UPDATE dorder SET " +
                             $"kodehTrans = {htrans.KodeH}, " +
                             $"kodedTrans = {dtrans[i].Koded}, " +
                             $"jumlahdikirim = {dtrans[i].Jumlah}, " +
                             $"sisa = {sisaOrderNotGantiHarga}, " +
                             $"lunas = {beresOrder} " +
                             $"WHERE kodeh = {horder.Kodeh} " +
                             $"AND koded = {foundDorder.Koded};";
                        await _context.Database.ExecuteSqlRawAsync(updateQueryDorder);
                    }
                }


            AfterCheckHorder:
                if (!hanyaGantiHarga)
                {
                    var jumlahPerubahan = 0;
                    int j = 0;
                    int? kodePerubahan = null;
                    bool ketemu = false;

                    while (!ketemu && j < tempDtrans.Count)
                    {
                        if (dtrans[i]?.Kodebarang == tempDtrans[j]?.Kodebarang)
                        {
                            jumlahPerubahan = dtrans[i].Jumlah - tempDtrans[j].Jumlah;

                            if (jumlahPerubahan != 0)
                            {
                                kodePerubahan = tempDtrans[j].Kodebarang;
                                tempDtrans[j] = null;
                                ketemu = true;
                            }
                            else
                            {
                                tempDtrans[j] = null;
                                kodePerubahan = null;
                                ketemu = true;
                            }
                        }
                        else
                        {
                            j++;
                        }
                    }

                    if (!ketemu)
                    {
                        jumlahPerubahan = (int)(dtrans[i]?.Jumlah ?? 0);
                        kodePerubahan = dtrans[i]?.Kodebarang;
                    }

                    var b = 0;
                    if (kodePerubahan != null)
                    {
                        b++;

                        if (insertDUpdate != "")
                            insertDUpdate += ", \n";

                        insertDUpdate +=
                            "(" +
                            kodeHUpdate + "," +
                            b + ",'" +
                            kodePerubahan + "', " +
                            jumlahPerubahan + ")";

                        /*string ss = 
                            "INSERT into dupdate (kodeHUpdate, koded, kodebarang, jumlah) " +
                            "values (" +
                            kodeHUpdate + "," +
                            b + ",'" +
                            kodePerubahan + "', " +
                            jumlahPerubahan + " ); ";

                        ADO_Temp.Close();
                        ADO_Temp.SQL.Clear();
                        ADO_Temp.SQL.Add(ss);
                        ADO_Temp.ExecSQL();*/
                    }
                }
            }
            await _context.BulkInsertAsync(dtrans);
            if (insertDUpdate != "")
            {
                insertDUpdate = " INSERT into dupdate (kodeHUpdate, koded, kodebarang, jumlah) " +
                        " Values " + insertDUpdate + ";";

            }

            if (!hanyaGantiHarga)
            {
                insertDUpdate = "";
                int b = 0;
                // UNTUK BARANG CANCEL !!
                for (int j = 0; j < dtrans.Count; j++)
                {
                    if (tempDtrans[j] != null)
                    {
                        b++;
                        int kodeB = tempDtrans[j].Kodebarang;
                        int jumlahPerubahan = 0 - tempDtrans[j].Jumlah;

                        if (insertDUpdate != "")
                            insertDUpdate += ", \n";

                        insertDUpdate +=
                            "(" +
                            kodeHUpdate + "," +
                            b + ",'" +
                            kodeB.ToString() + "', " +
                            jumlahPerubahan.ToString() + " )";
                    }
                }

                if (insertDUpdate != "")
                {
                    insertDUpdate =
                        " INSERT into dupdate (kodeHUpdate, koded, kodebarang, jumlah) " +
                        " Values " + insertDUpdate + ";";
                    insertDUpdate.Dump();
                    await _context.Database.ExecuteSqlRawAsync(insertDUpdate);
                }

                if (b > 0)
                {
                    var keterangan = "";
                    if (tempHtrans.KodePelanggan != htrans.KodePelanggan)
                        keterangan = "Nama Toko Diganti dari " + tempHtrans.Masterpelanggan.Nama + " menjadi " + htrans.Masterpelanggan.Nama;

                    if (tempHtrans.Kodegudang != htrans.Kodegudang)
                        keterangan = "Gudang Diganti dari " + tempHtrans.Mastergudang.Nama + " menjadi " + htrans.Mastergudang.Nama;

                    var insertHupdate = "INSERT into hupdate (kodeHUpdate, kodeH, insertName, insertTime, keterangan) " +
                        "values (" +
                        kodeHUpdate + "," +
                        htrans.KodeH + "," +
                        user.Kodeku + ", " +
                        " '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "', " +
                        " '" + keterangan + "' ); ";
                    await _context.Database.ExecuteSqlRawAsync(insertHupdate);
                }
            }
            return totalKomisi;
        }

        private double HitungKomisi(double hargaModal, double hargaJual, double potongan, double ongkir, double maksOngkir, int kurskomisi, int komisibarang)
        {
            double besarKomisi, besarPersenSales, untung;
            double biayaOngkir;

            if (hargaModal == 0 || hargaJual == 0)
            {
                return 0;
            }
            else
            {
                if (potongan != 0)
                {
                    biayaOngkir = 0;
                    if (ongkir != 0)
                    {
                        biayaOngkir = Math.Round(hargaJual * ongkir / 100, 0);
                        if (biayaOngkir > maksOngkir)
                            biayaOngkir = maksOngkir;
                    }

                    hargaJual = hargaJual - hargaJual * potongan / 100 - biayaOngkir;
                }

                besarKomisi = Math.Round(Constants.PERSEN_KOMISI / 100 * hargaJual, 0);
                untung = hargaJual - hargaModal;
                besarPersenSales = Math.Round(Constants.PERSEN_PROFIT / 100 * untung, 0);

                if (besarKomisi > besarPersenSales)
                    besarKomisi = besarPersenSales * kurskomisi;
                else
                    besarKomisi = besarKomisi * kurskomisi;

                if (besarKomisi > 0)
                    besarKomisi = besarKomisi * komisibarang;

                /* Uncomment this block to show the message
                MessageBox.Show(
                  "JUAL : " + hargaJual.ToString() + "\n" +
                  "MODAL : " + hargaModal.ToString() + "\n" +
                  "KMS : " + besarKomisi.ToString()
                );
                */

                return besarKomisi;
            }
        }

        private async Task<int> GetListKodeHupdate()
        {
            var lastKodeh = await _context.Hupdate.MaxAsync(e => e.KodeHupdate);
            var kodeh = 1;
            if (lastKodeh != null)
            {
                kodeh = lastKodeh + 1;
                //kodeh = lastKodeh;
            }
            return kodeh;
        }
        private async Task<int> GetLastKodeh()
        {
            var lastKodeh = await _context.Htrans.MaxAsync(e => e.KodeH);
            var kodeh = 1;
            if (lastKodeh != null)
            {
                kodeh = lastKodeh + 1;
                //kodeh = lastKodeh;
            }
            return kodeh;
        }

        private async Task<int> GetLastNoTrans()
        {
            var lastNoTrans = await _context.Htrans
                .Where(e => e.TglTrans.Month == DateTime.Now.Month && e.TglTrans.Year == DateTime.Now.Year)
                //.Select(e => e.Notrans)
                .MaxAsync(e => e.Notrans);
            var noTrans = 1;
            if (lastNoTrans != null && lastNoTrans > noTrans)
            {
                noTrans = lastNoTrans + 1;
            }
            return noTrans;
        }

        private string GetKodeNota(int notrans)
        {
            DateTime currentDate = DateTime.Now;
            string monthYear = currentDate.ToString("MMyyyy");
            string formattedInvoiceNumber = notrans.ToString().PadLeft(4, '0');

            return monthYear + formattedInvoiceNumber;
        }

        private async Task<int> GetKodeUpdate()
        {
            var kode = await _context.Hupdate.MaxAsync(e => e.KodeHupdate);
            return kode + 1;
        }
    }
}
