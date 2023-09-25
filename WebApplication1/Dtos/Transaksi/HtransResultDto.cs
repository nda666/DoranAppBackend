using DoranOfficeBackend.Dtos.Masterbarang;
using DoranOfficeBackend.Dtos.Masterpelanggan;
using DoranOfficeBackend.Models;
using _Masterbarang = DoranOfficeBackend.Models.Masterbarang;
namespace DoranOfficeBackend.Dtos.Transaksi
{
    public class HtransResult
    {
        public int KodeH { get; set; }
        public DateTime TglTrans { get; set; }
        public int KodePelanggan { get; set; }
        public long Jumlah { get; set; }
        /// <summary>
        /// TOTAL DARI BRG2 YG BERUPA BIAYA NON JURNAL PENJUALAN
        /// </summary>
        public int Jumlahbarangbiaya { get; set; }
        public int TambahanLainnya { get; set; }
        public int Diskon { get; set; }
        public long Dpp { get; set; }
        public int Ppn { get; set; }
        /// <summary>
        /// PPN 100% UNTUK SEMUA
        /// </summary>
        public int Ppnreal { get; set; }
        /// <summary>
        /// UNTUK SIMPAN CADANGAN PPN SEBELUM DILAKUKAN PERUBAHAN BESAR
        /// </summary>
        public int Cadanganppn { get; set; }
        /// <summary>
        /// 0=TIDAK_TERBIT. 1=TERBIT_FAKTUR_PPN
        /// </summary>
        public sbyte Terbitfakturppn { get; set; }
        /// <summary>
        /// 1=AKAN MASUK JURNAL PENJUALAN. 0=TIDAK MASUK JURNAL PENJUALAN
        /// </summary>
        public sbyte AkanDjJurnalkan { get; set; }
        public string Keterangan { get; set; } = null!;
        public int InsertName { get; set; }
        public DateTime? InsertTime { get; set; }
        public int UpdateName { get; set; }
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 3:belum,2:yanti,1:audit,0:jhonny
        /// </summary>
        public string HistoryNya { get; set; } = null!;
        public int JumlahKomisi { get; set; }
        public int KodeSales { get; set; }
        public int Untung { get; set; }
        public int UntungbelumpotOl { get; set; }
        /// <summary>
        /// 1 = lunas, 0 = belum lunas
        /// </summary>
        public string Lunas { get; set; } = null!;
        public string JumlahOnString { get; set; } = null!;
        public short PoinToko { get; set; }
        /// <summary>
        /// 1 = uda bagi, 0 = belum bagi
        /// </summary>
        public string BagiKomisi { get; set; } = null!;
        public DateTime TglBagiKomisi { get; set; }
        public DateTime TglLunas { get; set; }
        public int Kodegudang { get; set; }
        public bool DiCetak { get; set; }
        public short SalesPenagih { get; set; }
        public bool StatusNota { get; set; }
        /// <summary>
        /// 0=NORMAL. 2=RETUR. 1 TIDAK DIPAKE
        /// </summary>
        public string Retur { get; set; } = null!;
        public int Dikirim { get; set; }
        public DateTime Tgldikirim { get; set; }
        public bool Adminkiriman { get; set; }
        public DateTime TglPpn { get; set; }
        public bool Stoknota { get; set; }
        public int JumKoli { get; set; }
        public string NoSeriOnline { get; set; } = null!;
        public string Barcodeonline { get; set; } = null!;
        public sbyte Ppndiarsip { get; set; }
        public DateTime TglLaporPpn { get; set; }
        public sbyte Tipetempo { get; set; }
        public DateTime Tgltempo { get; set; }
        public string Infopenting { get; set; } = null!;
        public int Notrans { get; set; }
        public int Noretur { get; set; }
        public string Kodenota { get; set; } = null!;
        public long Kodeonline { get; set; }
        public string NamaCust { get; set; } = null!;
        public string NmrHp { get; set; } = null!;
        public string CustOlkota { get; set; } = null!;
        public string CustOlprovinsi { get; set; } = null!;
        public string CustOlwilayah { get; set; } = null!;
        public string CustOlkodepos { get; set; } = null!;
        public int NoOrder { get; set; }
        /// <summary>
        /// Buat isi kapan dicek oleh tim finance
        /// </summary>
        public DateTime Tglcek { get; set; }
        public int? Kodeorderapps { get; set; }
        /// <summary>
        /// Penanda Bila Admin ada ganti harga
        /// </summary>
        public sbyte Admingantiharga { get; set; }
        /// <summary>
        /// BUAT KEPERLUAN CROWN UPDATE STATUS TERKIRIM DI APPS DORAN.ID
        /// </summary>
        public sbyte Sudahupdateorderapps { get; set; }
        /// <summary>
        /// UNTUK UPDATE NMR HP
        /// </summary>
        public sbyte Sudahupdatephone { get; set; }

        public ICollection<DtransResult> Dtrans { get; set; }

        public virtual MasterpelangganWithLokasiKotaOptionDto? Masterpelanggan { get; set; }
        public virtual CommonResultDto? Mastergudang { get; set; }

        public virtual CommonResultDto? Sales { get; set; }
    }

    public class DtransResult
    {
        public int Id { get; set; }
        public int Kodeh { get; set; }
        public short Koded { get; set; }
        public short Kodebarang { get; set; }
        public short Jumlah { get; set; }
        public long Harga { get; set; }
        public int Komisi { get; set; }
        public int Untung { get; set; }
        public sbyte PoinToko { get; set; }
        public bool? KuranginStok { get; set; }
        public sbyte Tukartipe { get; set; }
        public sbyte HargaOk { get; set; }
        public string Nmrsn { get; set; } = null!;
        public virtual MasterbarangOptionDto? Masterbarang { get; set; }
    }

    public class HtransResultDto : PaginationResultDto
    {
        public ICollection<HtransResult> Data {get; set;}
    }

}
