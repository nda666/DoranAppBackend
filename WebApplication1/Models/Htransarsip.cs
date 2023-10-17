using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Htransarsip
    {
        public int Kode { get; set; }
        public int KodeH { get; set; }
        public DateTime TglTrans { get; set; }
        public int KodePelanggan { get; set; }
        public int Jumlah { get; set; }
        public int Jumlahbarangbiaya { get; set; }
        public int Diskon { get; set; }
        public int Dpp { get; set; }
        public int Ppn { get; set; }
        public int Ppnreal { get; set; }
        public int Terbitfakturppn { get; set; }
        public int AkanDjJurnalkan { get; set; }
        public int TambahanLainnya { get; set; }
        public string Keterangan { get; set; } = null!;
        public int KodeSales { get; set; }
        public int Kodegudang { get; set; }
        public string NoSeriOnline { get; set; } = null!;
        public string Barcodeonline { get; set; } = null!;
        public string Kodenota { get; set; } = null!;
        public int InsertName { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
