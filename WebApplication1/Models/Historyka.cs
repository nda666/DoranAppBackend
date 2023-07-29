using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Historyka
    {
        public int Kode { get; set; }
        public DateTime TglKas { get; set; }
        public string Keterangan { get; set; } = null!;
        public int Jumlah { get; set; }
        public bool InsertName { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
