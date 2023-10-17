using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Logfile
    {
        public long Id { get; set; }
        public int Username { get; set; }
        public DateTime Tanggal { get; set; }
        public string Keterangan { get; set; } = null!;
    }
}
