using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Daftarbaranghabi
    {
        public int Kode { get; set; }
        public int Kodebarang { get; set; }
        public int Kodegudang { get; set; }
        public int Minstok { get; set; }
        public int Maxstok { get; set; }
        public sbyte Kodegrupbaranghabis { get; set; }
        public sbyte Favorit { get; set; }
    }
}
