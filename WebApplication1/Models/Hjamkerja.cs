using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hjamkerja
    {
        public sbyte Kode { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte Jammasuk { get; set; }
        public sbyte Jampulang { get; set; }
        public sbyte Batasjammasuk1 { get; set; }
        public sbyte Batasjammasuk2 { get; set; }
        public sbyte Batasjampulang1 { get; set; }
        public sbyte Batasjampulang2 { get; set; }
    }
}
