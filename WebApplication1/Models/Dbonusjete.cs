using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dbonusjete
    {
        public int Kodeh { get; set; }
        public sbyte Koded { get; set; }
        public bool Carahitung { get; set; }
        public string Namasinonim { get; set; } = null!;
        public int Kodebarang { get; set; }
        public int Hrgmin { get; set; }
    }
}
