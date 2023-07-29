using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Idolshop
    {
        public int Kode { get; set; }
        public int Kodesales { get; set; }
        public sbyte Tipeid { get; set; }
        public string Userid { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Namatoko { get; set; } = null!;
        public string Nohpterdaftar { get; set; } = null!;
        public int Jumfoto { get; set; }
        public int Jumfollower { get; set; }
    }
}
