using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dkomisiomzet
    {
        public int Kodeh { get; set; }
        public int Koded { get; set; }
        public string Nama { get; set; } = null!;
        public int Jumlah { get; set; }
    }
}
