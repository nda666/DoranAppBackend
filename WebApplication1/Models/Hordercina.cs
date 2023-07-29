using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hordercina
    {
        public int Kodeh { get; set; }
        public DateTime Tglorder { get; set; }
        public DateTime Tglkirim { get; set; }
        public DateTime Perkiraantglkirim { get; set; }
        public sbyte Insertname { get; set; }
        public DateTime Inserttime { get; set; }
        public sbyte? Updatename { get; set; }
        public DateTime Updatetime { get; set; }
        public int Kodesupplier { get; set; }
        public sbyte Kirim { get; set; }
        public int Jumlah { get; set; }
        public int Jumlahdp { get; set; }
        public sbyte Kelengkapanberes { get; set; }
        public string Keterangan { get; set; } = null!;
    }
}
