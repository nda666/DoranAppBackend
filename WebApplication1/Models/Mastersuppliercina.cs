using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Mastersuppliercina
    {
        public short Kode { get; set; }
        public string Nama { get; set; } = null!;
        public bool? Aktif { get; set; }
    }
}
