using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Kaizen
    {
        public int Kode { get; set; }
        public sbyte Bulan { get; set; }
        public int Tahun { get; set; }
        public int Kodepegawai { get; set; }
        public string Judul { get; set; } = null!;
        public string Isi { get; set; } = null!;
        public int Admin { get; set; }
        public sbyte Diperiksa { get; set; }
    }
}
