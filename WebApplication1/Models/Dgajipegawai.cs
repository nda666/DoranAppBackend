using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dgajipegawai
    {
        public int Kodeh { get; set; }
        public int Koded { get; set; }
        public string Keterangan { get; set; } = null!;
        public int Jumlah { get; set; }
        public sbyte Urutan { get; set; }
        /// <summary>
        /// 1:detail, 2:total,3:fullheader
        /// </summary>
        public bool Tipe { get; set; }
        /// <summary>
        /// 0:tambahan,1:barangkurang,2:uangkurang,3:denda,4:tagihan,5:cicilan,6:fix,7:kata2
        /// </summary>
        public sbyte Jenis { get; set; }
        public int Periksa { get; set; }
        public int Kodehtrans { get; set; }
    }
}
