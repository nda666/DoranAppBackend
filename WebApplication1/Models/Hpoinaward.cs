using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hpoinaward
    {
        public sbyte Bulan { get; set; }
        public int Tahun { get; set; }
        public int Kodeh { get; set; }
        public int KodePeg { get; set; }
        public int Jumlah { get; set; }
        public sbyte InsertName { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
