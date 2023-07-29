using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dpphtambahan
    {
        public int Kodeh { get; set; }
        public sbyte Koded { get; set; }
        public short Jumlah { get; set; }
        public string Namabarang { get; set; } = null!;
        public int Harga { get; set; }
    }
}
