using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Sethargalevel
    {
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public float AcuanTambah { get; set; }
        public float AcuanPotong { get; set; }
        public int Modal { get; set; }
        public sbyte Online { get; set; }
        public sbyte Urutan { get; set; }
    }
}
