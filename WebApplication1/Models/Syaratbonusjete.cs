using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Syaratbonusjete
    {
        public sbyte Bulan { get; set; }
        public int Tahun { get; set; }
        /// <summary>
        /// 0=kodekat,1=kodebrg,2=namabrg
        /// </summary>
        public sbyte Jenis { get; set; }
        public int Kodebrg { get; set; }
        public string Sinonim { get; set; } = null!;
        public int Target { get; set; }
    }
}
