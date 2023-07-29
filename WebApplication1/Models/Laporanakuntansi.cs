using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Laporanakuntansi
    {
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public int Kodecoa4 { get; set; }
        public long Jumlah { get; set; }
        /// <summary>
        /// 0=NR,1=LR
        /// </summary>
        public sbyte Jenis { get; set; }
        public int Insertname { get; set; }
        public DateTime Inserttime { get; set; }
    }
}
