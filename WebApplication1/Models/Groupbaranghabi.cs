using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Groupbaranghabi
    {
        public sbyte Kode { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte Aktif { get; set; }
        public sbyte Urut { get; set; }
        public string Email { get; set; } = null!;
        public int JumData { get; set; }
        public int JumHabis { get; set; }
    }
}
