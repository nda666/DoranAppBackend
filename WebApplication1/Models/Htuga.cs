using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Htuga
    {
        public int Kodeh { get; set; }
        public sbyte Kodesales { get; set; }
        public int Kodetugas { get; set; }
        public bool Status { get; set; }
        public sbyte Poin { get; set; }
        public DateTime Tgldapattugas { get; set; }
        public DateTime Tglselesaitugas { get; set; }
    }
}
