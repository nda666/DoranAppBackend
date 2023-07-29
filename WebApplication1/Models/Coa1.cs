using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Coa1
    {
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte Tipe { get; set; }
        public sbyte Nr { get; set; }
    }
}
