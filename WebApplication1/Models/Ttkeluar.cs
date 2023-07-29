using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Ttkeluar
    {
        public int Kodett { get; set; }
        /// <summary>
        /// 0=tag,1=biaya,2=gaji
        /// </summary>
        public sbyte Tipe { get; set; }
        /// <summary>
        /// kode lookup
        /// </summary>
        public int Kodepenggunaan { get; set; }
        public int Kodepenggunaan2 { get; set; }
    }
}
