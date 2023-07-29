using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Komponenprestasi
    {
        public short Lebar { get; set; }
        public short Baris { get; set; }
        public short Kolom { get; set; }
        public string Fungsi { get; set; } = null!;
        public sbyte Tebal { get; set; }
        public sbyte BackAbu { get; set; }
    }
}
