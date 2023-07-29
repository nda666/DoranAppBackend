using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Glassperwilayah
    {
        public short Kode { get; set; }
        public short Sales { get; set; }
        public string Lokasi { get; set; } = null!;
        public short Jumlah { get; set; }
    }
}
