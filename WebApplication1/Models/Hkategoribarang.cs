using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hkategoribarang
    {
        public int Kodeh { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte Aktif { get; set; }
        public sbyte Perlusetharga { get; set; }
        public sbyte Cektahunan { get; set; }
        public int Hargakhusus { get; set; }
    }
}
