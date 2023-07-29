using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Mastertarget
    {
        public int Kode { get; set; }
        public int Kodesales { get; set; }
        public long Target { get; set; }
        public int Bonus { get; set; }
        public int Kodepelanggan { get; set; }
        public int Kp2 { get; set; }
        public int Kp3 { get; set; }
        public int Kodepengirim { get; set; }
        public int Kota { get; set; }
        public int Provinsi { get; set; }
        public string Keterangan { get; set; } = null!;
        public string Tim { get; set; } = null!;
        public sbyte Urut { get; set; }
    }
}
