using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hppntambahan
    {
        public int KodeH { get; set; }
        public DateTime TglTrans { get; set; }
        public int KodePelanggan { get; set; }
        public long Jumlah { get; set; }
        /// <summary>
        /// 0=tambahan,1=gunggungan
        /// </summary>
        public sbyte Tipe { get; set; }
        public int Ppn { get; set; }
        public sbyte InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public sbyte Ppndiarsip { get; set; }
        public DateTime TglLaporPpn { get; set; }
    }
}
