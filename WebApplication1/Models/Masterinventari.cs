using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Masterinventari
    {
        public int Kode { get; set; }
        public sbyte Kodejenis { get; set; }
        public DateTime Tglbeli { get; set; }
        public int Harga { get; set; }
        public sbyte Aktif { get; set; }
        public int Kodepegawai { get; set; }
        public DateTime TglPakai { get; set; }
        public string Keterangan { get; set; } = null!;
    }
}
