using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dbrgmasukretur
    {
        public int Kode { get; set; }
        public int KodeH { get; set; }
        public short KodeD { get; set; }
        public short Kodebarang { get; set; }
        public short Jumlah { get; set; }
        public bool AdaPacking { get; set; }
        public int KodeHpengganti { get; set; }
        public short KodedPengganti { get; set; }
        public string Keterangan { get; set; } = null!;
        public DateTime TglGantiStok { get; set; }
        public string NmrSn { get; set; } = null!;
        public string KetMasuk { get; set; } = null!;
        public int Harga { get; set; }
        public DateTime Tglterakhirbeli { get; set; }
    }
}
