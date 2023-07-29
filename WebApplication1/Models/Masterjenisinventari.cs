using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Masterjenisinventari
    {
        public sbyte Kode { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte KodeTipe { get; set; }
        public sbyte Aktif { get; set; }
    }
}
