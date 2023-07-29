using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Totalsetoran
    {
        public int KodeTotalSetoran { get; set; }
        public DateTime TglSetoran { get; set; }
        public int TotalSetoran1 { get; set; }
        public string Ket1 { get; set; } = null!;
        public int Jum1 { get; set; }
        public string Ket2 { get; set; } = null!;
        public int Jum2 { get; set; }
        public string Ket3 { get; set; } = null!;
        public int Jum3 { get; set; }
        public string Ket4 { get; set; } = null!;
        public int Jum4 { get; set; }
        public bool Setor { get; set; }
        public int Kodetotalsetoranglobal { get; set; }
    }
}
