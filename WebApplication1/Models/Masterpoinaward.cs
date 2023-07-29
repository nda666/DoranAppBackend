using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Masterpoinaward
    {
        public sbyte Kode { get; set; }
        public string Nama { get; set; } = null!;
        public bool? Aktif { get; set; }
        public bool? Urut { get; set; }
    }
}
