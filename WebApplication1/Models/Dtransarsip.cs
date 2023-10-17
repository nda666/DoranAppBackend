using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dtransarsip
    {
        public int Kodeh { get; set; }
        public short Koded { get; set; }
        public int Kodebarang { get; set; }
        public short Jumlah { get; set; }
        public int Harga { get; set; }
        public string Nmrsn { get; set; } = null!;
    }
}
