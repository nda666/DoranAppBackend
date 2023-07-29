using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Historylimit
    {
        public int Kode { get; set; }
        public DateTime Tglnaik { get; set; }
        public int Kodepelanggan { get; set; }
        public int Jumlah { get; set; }
        public int Insertname { get; set; }
    }
}
