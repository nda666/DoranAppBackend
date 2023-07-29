using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hsidikjari
    {
        public int Kodeh { get; set; }
        public int Kodepegawai { get; set; }
        public DateTime Jamsidikjari { get; set; }
        /// <summary>
        /// 0=masuk,1=pulang
        /// </summary>
        public bool Jenisabsen { get; set; }
        public sbyte Jamacuan { get; set; }
        public int Kodeonline { get; set; }
    }
}
