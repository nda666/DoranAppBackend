using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hbeli
    {
        public int KodeH { get; set; }
        public DateTime TglTrans { get; set; }
        public int Kodegudang { get; set; }
        public short KodeSupplier { get; set; }
        public string Nonota { get; set; } = null!;
        public long Jumlah { get; set; }
        public int Ppn { get; set; }
        public sbyte Ppndiarsip { get; set; }
        public DateTime Tglppn { get; set; }
        public DateTime TglLaporPpn { get; set; }
        public int TambahanLainnya { get; set; }
        public string Keterangan { get; set; } = null!;
        public bool InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public bool UpdateName { get; set; }
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 1:belum,0:jhonny
        /// </summary>
        public string HistoryNya { get; set; } = null!;
        /// <summary>
        /// 1 = lunas, 0 = belum lunas
        /// </summary>
        public string Lunas { get; set; } = null!;
        public DateTime TglLunas { get; set; }
        public int KodehBayar { get; set; }
        public sbyte Urut { get; set; }
        public string Kodefaktur { get; set; } = null!;
        /// <summary>
        /// 0=Belum,1=Sudah
        /// </summary>
        public sbyte Export { get; set; }
    }
}
