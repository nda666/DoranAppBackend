using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Mastertuga
    {
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public string? Keterangan { get; set; }
        public sbyte Poin { get; set; }
        public sbyte Tipetugas { get; set; }
        public sbyte Urut { get; set; }
        public sbyte Minlevel { get; set; }
        public sbyte Prioritas { get; set; }
        public bool Cycle { get; set; }
    }
}
