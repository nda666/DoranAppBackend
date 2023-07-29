using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hpakaiinventari
    {
        public int Kodeh { get; set; }
        public int KodeInventaris { get; set; }
        public int KodePegawai { get; set; }
        public DateTime TglPakai { get; set; }
        public sbyte Aktif { get; set; }
    }
}
