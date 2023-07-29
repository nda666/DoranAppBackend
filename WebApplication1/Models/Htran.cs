using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Htran
    {
        public int KodeH { get; set; }
        public DateTime TglTrans { get; set; }
        public int KodePelanggan { get; set; }
        public int Jumlah { get; set; }
        public int TambahanLainnya { get; set; }
        public int Ppn { get; set; }
        public string Keterangan { get; set; } = null!;
        public sbyte InsertName { get; set; }
        public DateTime? InsertTime { get; set; }
        public sbyte UpdateName { get; set; }
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 3:belum,2:yanti,1:audit,0:jhonny
        /// </summary>
        public string HistoryNya { get; set; } = null!;
        public int JumlahKomisi { get; set; }
        public sbyte KodeSales { get; set; }
        public int Untung { get; set; }
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
        public bool? Tipetempo { get; set; }
        public DateTime Tgltempo { get; set; }
        public string Infopenting { get; set; } = null!;
        public int Notrans { get; set; }
        public int Noretur { get; set; }
        public string Kodenota { get; set; } = null!;
        public int Kodeonline { get; set; }
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
        /// BUAT KEPERLUAN CROWN UPDATE STATUS TERKIRIM DI APPS DORAN.ID
        /// </summary>
        public sbyte Sudahupdateorderapps { get; set; }
        /// <summary>
        /// UNTUK UPDATE NMR HP
        /// </summary>
        public sbyte Sudahupdatephone { get; set; }
    }
}
