using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Bathippo
    {
        public short Kode { get; set; }
        public short BrgKode { get; set; }
        public int HargaTerendah { get; set; }
        public int HargaTertinggi { get; set; }
        public int BonusTerendah { get; set; }
        public int BonusTertinggi { get; set; }
    }
}
