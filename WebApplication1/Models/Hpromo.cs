using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hpromo
    {
        public int Kode { get; set; }
        public DateTime Tglawal { get; set; }
        public DateTime Tglakhir { get; set; }
        public string Nama { get; set; } = null!;
        public string Target { get; set; } = null!;
        public string Hadiah { get; set; } = null!;
        public bool? Aktif { get; set; }
    }
}
