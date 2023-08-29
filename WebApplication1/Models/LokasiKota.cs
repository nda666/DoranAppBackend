using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class LokasiKota
    {
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte Provinsi { get; set; }
        public sbyte Kodeareapengiriman { get; set; }
        public int Kodecoa4 { get; set; }
        public sbyte AdaKertasOrder { get; set; }

        public virtual ICollection<Masterpelanggan>? Masterpelanggans { get; set; }
    }
}
