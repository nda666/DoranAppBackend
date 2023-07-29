using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Masterpemasukan
    {
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public int Sales { get; set; }
        public sbyte Aktif { get; set; }
        public int NomorCicilan { get; set; }
        public int Kodecoa4 { get; set; }
    }
}
