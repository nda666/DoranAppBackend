using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hongkircina
    {
        public int Kodeh { get; set; }
        public DateTime Tanggal { get; set; }
        public string Nama { get; set; } = null!;
        public int Jumlah { get; set; }
    }
}
