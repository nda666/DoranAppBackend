using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Barangsn
    {
        public string NmrSn { get; set; } = null!;
        public int Kodebarang { get; set; }
        public int Kodegudang { get; set; }
        /// <summary>
        /// 0=stok,1=terjual
        /// </summary>
        public sbyte Status { get; set; }
        public int Kodehbeli { get; set; }
        public int Kodedbeli { get; set; }
        public int Kodehjual { get; set; }
        public int Kodedjual { get; set; }
        public int Insertnamebeli { get; set; }
        public DateTime Inserttimebeli { get; set; }
        public int Insertnamejual { get; set; }
        public DateTime Inserttimejual { get; set; }
        public int Insertnametransit { get; set; }
        public DateTime Inserttimetransit { get; set; }
    }
}
