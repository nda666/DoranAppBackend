using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dcekharga
    {
        public int Kodeh { get; set; }
        public int Kodebrg { get; set; }
        public int Harga { get; set; }
        public string Namasinonim { get; set; } = null!;
    }
}
