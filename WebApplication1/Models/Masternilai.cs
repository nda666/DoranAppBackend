using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Masternilai
    {
        public sbyte Kode { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte Bobot { get; set; }
    }
}
