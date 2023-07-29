using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Transaksipengeluaran
    {
        public int Kode { get; set; }
        public DateTime TglPengeluaran { get; set; }
        public int KodePengeluaran { get; set; }
        public string Keterangan { get; set; } = null!;
        public long Jumlah { get; set; }
        public int JumlahLainnya { get; set; }
        /// <summary>
        /// 0 1 Admin, 2 Master Admin, 3 Jhonny
        /// </summary>
        public bool Setor { get; set; }
        /// <summary>
        /// 0 Normal, 1 Cargo Masuk, 2 Setoran, 3 Cargo Keluar
        /// </summary>
        public sbyte JenisPengeluaran { get; set; }
        public sbyte InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public sbyte UpdateName { get; set; }
        public DateTime UpdateTime { get; set; }
        public int KodeTotalSetoran { get; set; }
        public int Kodetotalsetoranglobal { get; set; }
        /// <summary>
        /// 0=tunai,1=bank
        /// </summary>
        public sbyte Bank { get; set; }
        /// <summary>
        /// 0=belum,1=sudah
        /// </summary>
        public sbyte Sudahjurnal { get; set; }
    }
}
