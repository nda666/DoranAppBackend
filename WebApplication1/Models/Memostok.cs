using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Memostok
    {
        public int Kode { get; set; }
        public DateTime Tgl { get; set; }
        public int Kodegudang { get; set; }
        public int Kodebrg { get; set; }
        public int Jumlah { get; set; }
    }
}
