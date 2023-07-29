using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Mastersupplier
    {
        public short SupplierKode { get; set; }
        public string SupplierNama { get; set; } = null!;
        public sbyte SupplierAktif { get; set; }
        public bool InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public bool UpdateName { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Namalengkap { get; set; } = null!;
        public string Rekening { get; set; } = null!;
        public string? Npwp { get; set; }
        public int Kodecoa4 { get; set; }
        public sbyte Jurnalbeli { get; set; }
        public string EmailBarangHabis { get; set; } = null!;
        public sbyte Distiresmi { get; set; }
    }
}
