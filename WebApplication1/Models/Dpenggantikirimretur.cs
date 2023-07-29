using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dpenggantikirimretur
    {
        public int Kodeh { get; set; }
        public short Koded { get; set; }
        public int Kodebarang { get; set; }
        public int Jumlah { get; set; }
        public int Harga { get; set; }
        public string Keterangan { get; set; } = null!;
        public int Kodehpengganti { get; set; }
        public short Kodedpengganti { get; set; }
        public bool Status { get; set; }
    }
}
