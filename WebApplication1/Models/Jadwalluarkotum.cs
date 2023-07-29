using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Jadwalluarkotum
    {
        public int Kode { get; set; }
        public DateTime Tanggal { get; set; }
        public int Kodepegawai { get; set; }
        public int Kodesupir { get; set; }
        public string Keterangan { get; set; } = null!;
        public int Insertname { get; set; }
        public DateTime Inserttime { get; set; }
        public int Status { get; set; }
    }
}
