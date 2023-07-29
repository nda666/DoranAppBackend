using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Profileperush
    {
        public int Kode { get; set; }
        public string NamaProgram { get; set; } = null!;
        public string Header1 { get; set; } = null!;
        public string Header2 { get; set; } = null!;
        public string Header3 { get; set; } = null!;
        public string Footer1 { get; set; } = null!;
        public string Footer2 { get; set; } = null!;
        public string Footer3 { get; set; } = null!;
        public string Footer4 { get; set; } = null!;
        public int TargetAdmin { get; set; }
        public sbyte JamHabis { get; set; }
        public sbyte MenitHabis { get; set; }
        public sbyte JamTenggang { get; set; }
        public sbyte MenitTenggang { get; set; }
        public DateTime TglSandisk { get; set; }
        public DateTime TglLogitech { get; set; }
        public DateTime TglWd { get; set; }
        public DateTime Tglseagate { get; set; }
        public DateTime Tgltplink { get; set; }
        public short OmzetMin { get; set; }
        public short Profmin { get; set; }
        public short Profdibagi { get; set; }
        public string Memobonusjete { get; set; } = null!;
        public bool Akhirjamlaporan { get; set; }
        public int Versiprogram { get; set; }
        public sbyte Versiprogrampengiriman { get; set; }
        public sbyte Versiprogramjtol { get; set; }
        public sbyte Versiprogramreturan { get; set; }
        public sbyte Versicekorder { get; set; }
        public sbyte Versipujian { get; set; }
        public sbyte Kodebonusarea { get; set; }
        public int Minbonusarea { get; set; }
        public int KodePenyiap { get; set; }
    }
}
