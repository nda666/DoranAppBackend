using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Targetomzettoko
    {
        public int Kode { get; set; }
        public DateTime Tglawal { get; set; }
        public DateTime Tglakhir { get; set; }
        public int Kodepelanggan { get; set; }
        public sbyte Kodesales { get; set; }
        public long Omzet { get; set; }
        public int Toko2 { get; set; }
        public int Toko3 { get; set; }
        public int Toko4 { get; set; }
        public int Toko5 { get; set; }
        public string Hadiah { get; set; } = null!;
    }
}
