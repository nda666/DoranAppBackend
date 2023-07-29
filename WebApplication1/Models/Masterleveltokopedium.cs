using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Masterleveltokopedium
    {
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte Urut { get; set; }
    }
}
