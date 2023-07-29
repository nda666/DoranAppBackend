using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Mastertargettahunan
    {
        public int Kode { get; set; }
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public sbyte Sales { get; set; }
        public sbyte Jenis { get; set; }
        public string Keterangan { get; set; } = null!;
        public long Target { get; set; }
        public int Kota { get; set; }
        public int Provinsi { get; set; }
        public int KodeKategoriBarang { get; set; }
    }
}
