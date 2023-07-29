using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class MasterPelangganGabungan
    {
        public long Id { get; set; }
        public DateTime? Tanggal { get; set; }
        public int Kodeh { get; set; }
        public int KodePelanggan { get; set; }
        public int? KodeSales { get; set; }
        public sbyte IsOrder { get; set; }
        public sbyte Nomorgudang { get; set; }
        public int KodeBarang { get; set; }
        public int BrandId { get; set; }
        public int Pcs { get; set; }
        public long? Harga { get; set; }
        public string? NamaCust { get; set; }
        public string? Phone { get; set; }
        public bool HasUpdated { get; set; }
    }
}
