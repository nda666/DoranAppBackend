using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Simpandendum
    {
        public sbyte Bulan { get; set; }
        public int Tahun { get; set; }
        public int Kodepegawai { get; set; }
        public int Jumlah { get; set; }
        public sbyte Telat { get; set; }
        public sbyte Tidakmasuk { get; set; }
        public sbyte History { get; set; }
        public int Besardenda { get; set; }
        public int Dendabriefing { get; set; }
        public int Jumharikerja { get; set; }
        public int Jumhadir { get; set; }
        public int Jumpulanglebihawal { get; set; }
    }
}
