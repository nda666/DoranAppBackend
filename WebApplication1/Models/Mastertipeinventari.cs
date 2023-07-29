using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Mastertipeinventari
    {
        public sbyte Kode { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte Aktif { get; set; }
    }
}
