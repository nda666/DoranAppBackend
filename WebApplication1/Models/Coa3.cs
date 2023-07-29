using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Coa3
    {
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte? Tipe { get; set; }
        public int Kodecoa2 { get; set; }
        public int Kodecoa1 { get; set; }
        public sbyte Nr { get; set; }
    }
}
