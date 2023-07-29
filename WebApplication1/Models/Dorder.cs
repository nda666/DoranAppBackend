using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dorder
    {
        public int Kodeh { get; set; }
        public short Koded { get; set; }
        public int Kodebarang { get; set; }
        public int Jumlah { get; set; }
        public string Keterangan { get; set; } = null!;
        public int Jumlahdikirim { get; set; }
        public int Sisa { get; set; }
        /// <summary>
        /// 0:belum. 1: kurang, 2: lunas. 3:cancel, 4:menyusul, 5:berespaksa
        /// </summary>
        public bool Lunas { get; set; }
        public string Keterangancancel { get; set; } = null!;
        public int KodehTrans { get; set; }
        public sbyte KodedTrans { get; set; }
        /// <summary>
        /// 0=belum, 1=disiapkan, 2=beres
        /// </summary>
        public bool Disiapkan { get; set; }
        public int Harga { get; set; }
        public int Komisi { get; set; }
    }
}
