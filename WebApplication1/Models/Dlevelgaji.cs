using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dlevelgaji
    {
        public sbyte Kodeh { get; set; }
        public sbyte Koded { get; set; }
        public string Keterangan { get; set; } = null!;
        /// <summary>
        /// 0=Total,1=Satuan Absensi,2=Bonus Kehadiran,3=Bonus Tidak Telat,4=Bonus Omzet,5=Insentif
        /// </summary>
        public sbyte Tindakan { get; set; }
        public sbyte Efekabsensi { get; set; }
        public float Jumlah { get; set; }
        public int Maks { get; set; }
        public int Urut { get; set; }
    }
}
