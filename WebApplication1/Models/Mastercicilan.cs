using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Mastercicilan
    {
        public DateTime Tanggal { get; set; }
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public long Besarpinjaman { get; set; }
        public int Jumlah { get; set; }
        public int Kodepegawai { get; set; }
        /// <summary>
        /// 0=gapok,1=komisi
        /// </summary>
        public sbyte Potongdi { get; set; }
        /// <summary>
        /// 0=belum,1=lunas
        /// </summary>
        public sbyte Status { get; set; }
    }
}
