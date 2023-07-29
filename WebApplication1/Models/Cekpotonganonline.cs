using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Cekpotonganonline
    {
        public int Kode { get; set; }
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public int Kodepelanggan { get; set; }
        /// <summary>
        /// 0=belum 1=sudah
        /// </summary>
        public int Periksa { get; set; }
    }
}
