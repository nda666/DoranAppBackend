using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hlevelgaji
    {
        public sbyte Kodeh { get; set; }
        public string Nama { get; set; } = null!;
        /// <summary>
        /// Bila 1, maka gaji akan FIX di jumlah hari SPG (1 minggu libur 4x
        /// </summary>
        public sbyte Formatspg { get; set; }
    }
}
