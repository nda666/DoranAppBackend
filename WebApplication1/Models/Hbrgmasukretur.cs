using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hbrgmasukretur
    {
        public int KodeH { get; set; }
        public DateTime TglTrans { get; set; }
        public string Keterangan { get; set; } = null!;
        public bool InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public bool UpdateName { get; set; }
        public DateTime UpdateTime { get; set; }
        public string HistoryNya { get; set; } = null!;
        public short KodePelanggan { get; set; }
        public string NamaCust { get; set; } = null!;
        public short KodePemberi { get; set; }
        public sbyte Kodesales { get; set; }
    }
}
