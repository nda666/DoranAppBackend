using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Datagrupnilai
    {
        public int Kodeh { get; set; }
        public sbyte Kodegrup { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte Bobot { get; set; }
    }
}
