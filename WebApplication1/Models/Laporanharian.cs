using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Laporanharian
    {
        public int Kode { get; set; }
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public int Kodepegawai { get; set; }
        public int Jumtidaklaporan { get; set; }
    }
}
