using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hbayarsupplier
    {
        public int Kodeh { get; set; }
        public DateTime Tanggal { get; set; }
        public int Jumlah { get; set; }
        /// <summary>
        /// 0=tunai,1=bank
        /// </summary>
        public sbyte Bank { get; set; }
        /// <summary>
        /// 0=belum,1=sudahterekam
        /// </summary>
        public sbyte Status { get; set; }
    }
}
