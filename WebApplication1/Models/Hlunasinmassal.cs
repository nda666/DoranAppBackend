using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hlunasinmassal
    {
        public int Kodeh { get; set; }
        public int Jumlah { get; set; }
        public DateTime Tanggal { get; set; }
        public int Insertname { get; set; }
        public DateTime Inserttime { get; set; }
        /// <summary>
        /// 0=Belum,1=Sudah
        /// </summary>
        public sbyte Periksa { get; set; }
    }
}
