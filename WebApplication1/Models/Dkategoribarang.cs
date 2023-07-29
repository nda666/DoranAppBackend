using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dkategoribarang
    {
        public int Koded { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte Kodeh { get; set; }
        public sbyte Munculdimasterbarangapps { get; set; }
        public sbyte Cnp { get; set; }
        public sbyte Sn { get; set; }
        public sbyte Perlusetharga { get; set; }
    }
}
