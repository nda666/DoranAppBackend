using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Masterbank
    {
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public int Kodecoa4 { get; set; }
        public string Kodebuku { get; set; } = null!;
    }
}
