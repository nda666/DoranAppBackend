using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Potonganbarangkurang
    {
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public int Kodepegawai { get; set; }
        public int Jumlah { get; set; }
        /// <summary>
        /// 0=belum,1=sudahdipotonggaji
        /// </summary>
        public sbyte Status { get; set; }
    }
}
