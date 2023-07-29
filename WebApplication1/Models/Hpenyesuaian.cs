using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hpenyesuaian
    {
        public int Kodeh { get; set; }
        public DateTime Tgltrans { get; set; }
        /// <summary>
        /// 0=sudahdiperiksa,1=belum
        /// </summary>
        public bool? Historynya { get; set; }
        public int Kodegudang { get; set; }
        public sbyte Insertname { get; set; }
        public DateTime Inserttime { get; set; }
    }
}
