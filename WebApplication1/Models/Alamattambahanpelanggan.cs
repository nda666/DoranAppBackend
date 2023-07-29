using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Alamattambahanpelanggan
    {
        public int Kode { get; set; }
        public int Kodepelanggan { get; set; }
        public string Alamat { get; set; } = null!;
        public int Tokoexp { get; set; }
        public int Kirimmelalui { get; set; }
        public int Lokasi { get; set; }
    }
}
