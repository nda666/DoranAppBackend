using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Logfileserver
    {
        public int Kode { get; set; }
        public DateTime Tgl { get; set; }
        public string Perintah { get; set; } = null!;
        public short Pengirim { get; set; }
        public string Isilaporan { get; set; } = null!;
        /// <summary>
        /// 0:BELUM. 1:SUDAH
        /// </summary>
        public bool Sudahdibalas { get; set; }
    }
}
