using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dresipengirimankepelanggan
    {
        public int Kodeh { get; set; }
        public string Resi { get; set; } = null!;
        public sbyte Koli { get; set; }
        /// <summary>
        /// 0=tdk,1=bayartujuan
        /// </summary>
        public bool OngkirBt { get; set; }
        /// <summary>
        /// 0=tdkfree,1=free
        /// </summary>
        public bool Ongkirfree { get; set; }
        public int Kodehtrans { get; set; }
        /// <summary>
        /// 1=DARAT,2=UDARA,3=LAUT
        /// </summary>
        public sbyte Kirimmelalui { get; set; }
    }
}
