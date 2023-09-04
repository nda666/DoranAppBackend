using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Masterpengeluaran
    {
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte JenisKas { get; set; }
        public int Sales { get; set; }
        public bool Cargo { get; set; }
        public sbyte Kodeareapengiriman { get; set; }
        public string Telpekspedisi { get; set; } = null!;
        public bool Aktif { get; set; }
        /// <summary>
        /// 0=UK, 1=Cicilan
        /// </summary>
        public sbyte JenisUk { get; set; }
        public int NomorCicilan { get; set; }
        public int Kodecoa4 { get; set; }
        public sbyte HarusInputNoHp { get; set; }
        public bool? AdaBarcode { get; set; }
        public sbyte OllangusungCetak { get; set; }
    }
}
