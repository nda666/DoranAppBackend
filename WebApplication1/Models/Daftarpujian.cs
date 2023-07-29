using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Daftarpujian
    {
        public int Kode { get; set; }
        public sbyte Hari { get; set; }
        public sbyte Bulan { get; set; }
        public short Tahun { get; set; }
        public int Dari { get; set; }
        public int Kepada { get; set; }
        public string Isi { get; set; } = null!;
        /// <summary>
        /// 0 blm dibaca. 1 uda dibaca
        /// </summary>
        public sbyte Dibaca { get; set; }
        public sbyte Prioritas { get; set; }
    }
}
