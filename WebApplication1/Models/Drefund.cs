using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Drefund
    {
        public int Kodeh { get; set; }
        public int Koded { get; set; }
        public DateTime Tgltrans { get; set; }
        public int Kodebarang { get; set; }
        public int Kodehbeli { get; set; }
        public int Kodebm { get; set; }
        public string Nonota { get; set; } = null!;
        public int Hargalama { get; set; }
        public int Hargabaru { get; set; }
        public int Jumlah { get; set; }
    }
}
