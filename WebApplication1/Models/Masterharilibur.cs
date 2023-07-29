using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Masterharilibur
    {
        public sbyte Kode { get; set; }
        public DateTime Tanggal { get; set; }
        public string Keterangan { get; set; } = null!;
    }
}
