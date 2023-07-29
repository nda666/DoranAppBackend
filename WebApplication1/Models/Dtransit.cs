using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dtransit
    {
        public int Kodet { get; set; }
        public short Koded { get; set; }
        public short Kodebarang { get; set; }
        public short Jumlah { get; set; }
        public bool Sudahdicek { get; set; }
        public string Namapenerima { get; set; } = null!;
        public string NmrSn { get; set; } = null!;
    }
}
