using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dbawatagihan
    {
        public int KodeH { get; set; }
        public short KodePelanggan { get; set; }
        public int KodeHtrans { get; set; }
        public bool StatusNota { get; set; }
    }
}
