using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hkirimretur
    {
        public int KodeH { get; set; }
        public DateTime TglTrans { get; set; }
        public short KodeSupplier { get; set; }
        public int Jumlah { get; set; }
        public string Keterangan { get; set; } = null!;
        public bool InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public bool UpdateName { get; set; }
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 1:belum,0:jhonny
        /// </summary>
        public sbyte HistoryNya { get; set; }
        /// <summary>
        /// 1 = lunas, 0 = belum lunas
        /// </summary>
        public sbyte Lunas { get; set; }
        public DateTime TglLunas { get; set; }
        /// <summary>
        /// 0=returbiasa,1=penyesuaian
        /// </summary>
        public sbyte Penyesuaian { get; set; }
    }
}
