using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Mastergudang
    {
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public bool? Aktif { get; set; }
        public sbyte Urut { get; set; }
        public short Boletransit { get; set; }
    }
}
