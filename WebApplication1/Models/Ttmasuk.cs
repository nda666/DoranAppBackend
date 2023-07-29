using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Ttmasuk
    {
        public int Kode { get; set; }
        public DateTime Tgl { get; set; }
        public bool Kodebank { get; set; }
        public int Kodepelanggan { get; set; }
        public long Jumlah { get; set; }
        public string Keterangan { get; set; } = null!;
        public sbyte Insertname { get; set; }
        public DateTime? InsertTime { get; set; }
        public sbyte Updatename { get; set; }
        public DateTime Updatetime { get; set; }
        public int Urut { get; set; }
        /// <summary>
        /// 0=belum, 1=beres, 2=dicekJhonny
        /// </summary>
        public bool History { get; set; }
        /// <summary>
        /// 0=Kredit,1=Debit
        /// </summary>
        public sbyte Kreditdebit { get; set; }
        public int Kodeonline { get; set; }
    }
}
