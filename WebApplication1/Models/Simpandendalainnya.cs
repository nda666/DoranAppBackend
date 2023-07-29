using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Simpandendalainnya
    {
        public int Kode { get; set; }
        public sbyte Bulan { get; set; }
        public int Tahun { get; set; }
        public int Kodepegawai { get; set; }
        public string Namadenda { get; set; } = null!;
        public int? Jumlah { get; set; }
        public sbyte History { get; set; }
    }
}
