using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hkomisi
    {
        public int Kodeh { get; set; }
        public sbyte Bulan { get; set; }
        public int Tahun { get; set; }
        public int Kodesales { get; set; }
        public int Jumlah { get; set; }
        public int Komisi { get; set; }
        public int Sisagaji { get; set; }
        public long Totalomzet { get; set; }
        public long Untung { get; set; }
        public int Bonusarea { get; set; }
        public int Bonusjete { get; set; }
        public float PersenSedia { get; set; }
        /// <summary>
        /// 0=belum,1=sudah
        /// </summary>
        public sbyte Status { get; set; }
        public DateTime Tgltt { get; set; }
        public int Komisidanbonus { get; set; }
    }
}
