using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hbelicina
    {
        public int Kodeh { get; set; }
        public DateTime Tglkirim { get; set; }
        public DateTime Tglnyampe { get; set; }
        public sbyte Kodesuppliercina { get; set; }
        /// <summary>
        /// 0=FASDELI,1=INTEGRA
        /// </summary>
        public int Kodeekspedisi { get; set; }
        public sbyte Insertname { get; set; }
        public DateTime Inserttime { get; set; }
        public sbyte Updatename { get; set; }
        public DateTime Updatetime { get; set; }
        /// <summary>
        /// 2=Belum Periksa,1=Sudah
        /// </summary>
        public bool? Historynya { get; set; }
        /// <summary>
        /// 0=air,1=sea
        /// </summary>
        public bool Kirimvia { get; set; }
        public int Marking { get; set; }
        public bool Sudahdatang { get; set; }
        public float Berat { get; set; }
        public DateTime Tgllunas { get; set; }
        public bool Lunas { get; set; }
        public int Jumlah { get; set; }
        public int Kodehongkircina { get; set; }
        public int Hargaongkir { get; set; }
        public int Ongkirtambahan { get; set; }
    }
}
