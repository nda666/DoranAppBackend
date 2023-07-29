using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Daftarbc
    {
        public sbyte Kode { get; set; }
        public string Judul { get; set; } = null!;
        public string Isi { get; set; } = null!;
    }
}
