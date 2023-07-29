using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hrefund
    {
        public int KodeH { get; set; }
        public DateTime TglTrans { get; set; }
        public int KodeSupplier { get; set; }
        public int Jumlah { get; set; }
        public string Keterangan { get; set; } = null!;
        public bool InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public bool UpdateName { get; set; }
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 1:belum,0:jhonny
        /// </summary>
        public string HistoryNya { get; set; } = null!;
        /// <summary>
        /// 1 = lunas, 0 = belum lunas
        /// </summary>
        public string Lunas { get; set; } = null!;
        public DateTime TglLunas { get; set; }
    }
}
