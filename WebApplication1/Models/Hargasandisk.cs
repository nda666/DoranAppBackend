using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hargasandisk
    {
        public int Kodeh { get; set; }
        public int Kodebrg { get; set; }
        public int M1 { get; set; }
        public int M2 { get; set; }
        public int H1 { get; set; }
        public int H2 { get; set; }
        public int H3 { get; set; }
        public int H4 { get; set; }
        public int HolGrosir { get; set; }
        public int HolPromo { get; set; }
        public int HolEcer { get; set; }
        public int HolOfficial { get; set; }
        public int R1 { get; set; }
        public int R2 { get; set; }
        public int R3 { get; set; }
        public string Keterangan { get; set; } = null!;
        public sbyte Insertname { get; set; }
        public DateTime Inserttime { get; set; }
        public sbyte Aktif { get; set; }
    }
}
