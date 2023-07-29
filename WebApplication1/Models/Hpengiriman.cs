using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hpengiriman
    {
        public int Kodeh { get; set; }
        public DateTime Tglkirim { get; set; }
        public int Kodepengiriman { get; set; }
        public int Kodehtrans { get; set; }
    }
}
