using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Tagihansupplier
    {
        public int Kode { get; set; }
        public int Kodedetailbayar { get; set; }
        public int Kodehbeli { get; set; }
        public string Keterangan { get; set; } = null!;
        public int Jumlah { get; set; }
        public int Piutang { get; set; }
        public int Coa4 { get; set; }
        public sbyte InsertName { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
