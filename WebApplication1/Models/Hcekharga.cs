using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hcekharga
    {
        public sbyte Kodeh { get; set; }
        public string Nama { get; set; } = null!;
        /// <summary>
        /// 0=Kode,1=Sinonim Nama
        /// </summary>
        public sbyte Carahitung { get; set; }
    }
}
