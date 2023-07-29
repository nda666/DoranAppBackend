using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hbonusjete
    {
        public int Kodeh { get; set; }
        public string Nama { get; set; } = null!;
        public int Qty1 { get; set; }
        public int Bonus1 { get; set; }
        public int Qty2 { get; set; }
        public int Bonus2 { get; set; }
    }
}
