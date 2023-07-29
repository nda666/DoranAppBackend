using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Simpanbonusjete
    {
        public sbyte Bulan { get; set; }
        public int Tahun { get; set; }
        public int Kodesales { get; set; }
        public int Jumlah { get; set; }
        public sbyte History { get; set; }
    }
}
