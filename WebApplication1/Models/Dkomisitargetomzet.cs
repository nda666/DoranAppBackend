using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dkomisitargetomzet
    {
        public int Kodeh { get; set; }
        public sbyte Koded { get; set; }
        public string Nama { get; set; } = null!;
        public long Omzet { get; set; }
        public long Target { get; set; }
        public int Bonus { get; set; }
    }
}
