using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    /// <summary>
    /// Buat Detail Barang Masuk
    /// </summary>
    public partial class Barangmasuk
    {
        public int Kode { get; set; }
        public int KodeBarang { get; set; }
        public short KodeSupplier { get; set; }
        public int Jumlah { get; set; }
        public int Harga { get; set; }
        public DateTime TglMasuk { get; set; }
        public string Keterangan { get; set; } = null!;
        public bool InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public string HistoryNya { get; set; } = null!;
        public bool UpdateName { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Kodegudang { get; set; }
        public int Kodeh { get; set; }
        public int JumSn { get; set; }
    }
}
