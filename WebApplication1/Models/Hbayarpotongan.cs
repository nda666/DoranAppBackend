using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hbayarpotongan
    {
        public int Kodeh { get; set; }
        public int Kodedetailbayar { get; set; }
        public int Kodedbukubesar { get; set; }
        public int Kodesupplier { get; set; }
        public DateTime Tgllunas { get; set; }
        public string Keterangan { get; set; } = null!;
        public int Jumlah { get; set; }
        public sbyte Urut { get; set; }
        public int Kodehbayar { get; set; }
        public int Piutang { get; set; }
        public int Coa4 { get; set; }
    }
}
