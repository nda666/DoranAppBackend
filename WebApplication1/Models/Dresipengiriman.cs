using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dresipengiriman
    {
        public int Kodeh { get; set; }
        public short Koded { get; set; }
        public int Kodesupplier { get; set; }
        public string Resi { get; set; } = null!;
        public int Jumlah { get; set; }
    }
}
