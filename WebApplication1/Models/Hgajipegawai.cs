using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    /// <summary>
    /// 1 belum dicek, 0 uda dicek
    /// </summary>
    public partial class Hgajipegawai
    {
        public int Kodeh { get; set; }
        public int KodePeg { get; set; }
        public sbyte Bulan { get; set; }
        public int Tahun { get; set; }
        public int Jumlah { get; set; }
        public int JumlahFull { get; set; }
        /// <summary>
        /// 3=Belum,2=siapdiberikan,1=sudahdiberikan,0=sudahdipotong
        /// </summary>
        public bool? Status { get; set; }
        public sbyte InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public sbyte UpdateName { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime TglBagi { get; set; }
        public DateTime TglPotong { get; set; }
        /// <summary>
        /// 0:Tunai;1:TT
        /// </summary>
        public bool Tunai { get; set; }
        public int KodeFormGaji { get; set; }
    }
}
