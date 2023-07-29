using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hpenggantikirimretur
    {
        public int KodeH { get; set; }
        public DateTime TglTrans { get; set; }
        public short KodeSupplier { get; set; }
        public string Nonota { get; set; } = null!;
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
        /// 0=gantiretur, 1=potongnota
        /// </summary>
        public sbyte Status { get; set; }
        public int Jumlah { get; set; }
        public bool Sudahpotongnota { get; set; }
        public DateTime Tglpotongnota { get; set; }
        public bool Sudahexport { get; set; }
    }
}
