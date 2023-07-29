using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Daftarkomplain
    {
        public int Kode { get; set; }
        public DateTime Tgl { get; set; }
        public string Daridivisi { get; set; } = null!;
        public string Kepadadivisi { get; set; } = null!;
        public string? Komplain { get; set; }
        public string Jawaban { get; set; } = null!;
        public int Statusdrpengirim { get; set; }
        public int Statusdrpenerima { get; set; }
    }
}
