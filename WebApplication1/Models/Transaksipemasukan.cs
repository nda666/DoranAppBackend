using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Transaksipemasukan
    {
        public int Kode { get; set; }
        public DateTime TglPemasukan { get; set; }
        public int KodePemasukan { get; set; }
        public string Keterangan { get; set; } = null!;
        public int Jumlah { get; set; }
        /// <summary>
        /// 0 1 Admin, 2 Jhonny
        /// </summary>
        public bool Setor { get; set; }
        public sbyte InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public sbyte UpdateName { get; set; }
        public DateTime UpdateTime { get; set; }
        public int KodeTotalSetoran { get; set; }
        public int Kodetotalsetoranglobal { get; set; }
    }
}
