using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dpromopoin
    {
        public sbyte Kode { get; set; }
        public bool Carahitung { get; set; }
        public string Namasinonim { get; set; } = null!;
        public int Kodebarang { get; set; }
        public float Poin { get; set; }
    }
}
