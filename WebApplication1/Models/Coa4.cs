using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Coa4
    {
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        /// <summary>
        /// 1=Debit,2=Kredit
        /// </summary>
        public sbyte Tipe { get; set; }
        public int Kodecoa3 { get; set; }
        public int Kodecoa2 { get; set; }
        public int Kodecoa1 { get; set; }
        /// <summary>
        /// 0=Neraca,1=RL
        /// </summary>
        public sbyte Nr { get; set; }
        public string Prefix { get; set; } = null!;
        /// <summary>
        /// 0=Belum, 1=Kas
        /// </summary>
        public sbyte Golongan { get; set; }
        public int KodehTrans { get; set; }
    }
}
