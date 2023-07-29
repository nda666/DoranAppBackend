using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hnilaipegawai
    {
        public int Kodeh { get; set; }
        public int KodePeg { get; set; }
        public sbyte Bulan { get; set; }
        public int Tahun { get; set; }
        /// <summary>
        /// 0 : TDK BISA UPDATE, 1 BISA UPDATE
        /// </summary>
        public bool? Status { get; set; }
        public string Pesan { get; set; } = null!;
    }
}
