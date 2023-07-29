using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dkirimretur
    {
        public int Kodeh { get; set; }
        public short Koded { get; set; }
        public int Kodebarang { get; set; }
        public int Jumlah { get; set; }
        public float Harga { get; set; }
        public string Keterangan { get; set; } = null!;
        /// <summary>
        /// 0=belum,1=sedang,2=lunas,3=potnota
        /// </summary>
        public sbyte Lunas { get; set; }
    }
}
