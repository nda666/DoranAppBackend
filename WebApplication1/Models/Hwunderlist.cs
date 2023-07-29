using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hwunderlist
    {
        public int Kode { get; set; }
        public DateTime Tglbuat { get; set; }
        public DateTime Tgltarget { get; set; }
        public int Kodepegawai { get; set; }
        public string Pekerjaan { get; set; } = null!;
        public sbyte Status { get; set; }
        public int Insertname { get; set; }
        public DateTime Tglselesai { get; set; }
        public int Adminselesai { get; set; }
    }
}
