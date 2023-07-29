using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dtran
    {
        public int Kodeh { get; set; }
        public short Koded { get; set; }
        public short Kodebarang { get; set; }
        public short Jumlah { get; set; }
        public int Harga { get; set; }
        public int Komisi { get; set; }
        public int Untung { get; set; }
        public sbyte PoinToko { get; set; }
        public bool? KuranginStok { get; set; }
        public sbyte Tukartipe { get; set; }
        public sbyte HargaOk { get; set; }
        public string Nmrsn { get; set; } = null!;
    }
}
