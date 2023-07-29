using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dkomisidetail
    {
        public int Kodeh { get; set; }
        public sbyte Koded { get; set; }
        public string Nama { get; set; } = null!;
        public int Jumlah { get; set; }
        /// <summary>
        /// 0:biasa,1:gapok,2:bonusarea,3:barangkurang,4:uangkurang,5:barangspesial,6:denda,7:komisi,8:bonusjete,9:tagihan,10:cicilan,11:titipanuangsales
        /// </summary>
        public sbyte Jenis { get; set; }
        public int Periksa { get; set; }
        public sbyte Urut { get; set; }
        public int Kodehtrans { get; set; }
        public sbyte Persen { get; set; }
    }
}
