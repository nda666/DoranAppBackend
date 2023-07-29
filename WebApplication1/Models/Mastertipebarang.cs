using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Mastertipebarang
    {
        public sbyte Kode { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte Shownya { get; set; }
        public sbyte Urut { get; set; }
    }
}
