using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Syaratkomisi
    {
        public int Kodesales { get; set; }
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public sbyte GapokTarget { get; set; }
        public sbyte GapokNotaTrans { get; set; }
        public string GapokNotaTransKet { get; set; } = null!;
        public sbyte GapokNotaBlok { get; set; }
        public string GapokNotaBlokKet { get; set; } = null!;
        public sbyte GapokTagTitip { get; set; }
        public string GapokTagTitipKet { get; set; } = null!;
        public sbyte GapokManager { get; set; }
        public string GapokManagerKet { get; set; } = null!;
        public sbyte GapokPembelian { get; set; }
        public string GapokPembelianKet { get; set; } = null!;
        public sbyte GapokAdmin { get; set; }
        public string GapokAdminKet { get; set; } = null!;
        public sbyte KomisiKoper { get; set; }
        public string KomisiKoperket { get; set; } = null!;
        public sbyte KomisiNotaTrans { get; set; }
        public string KomisiNotaTransKet { get; set; } = null!;
        public sbyte KomisiNotaBlok { get; set; }
        public string KomisiNotaBlokKet { get; set; } = null!;
        public sbyte KomisiTagTitip { get; set; }
        public string KomisiTagTitipKet { get; set; } = null!;
        public sbyte KomisiManager { get; set; }
        public string KomisiManagerKet { get; set; } = null!;
        public sbyte KomisiPembelian { get; set; }
        public string KomisiPembelianKet { get; set; } = null!;
        public sbyte KomisiDoranCare { get; set; }
        public string KomisiDoranCareKet { get; set; } = null!;
        public sbyte KomisiEvaluasi { get; set; }
        public sbyte KomisiAdmin { get; set; }
        public string KomisiAdminKet { get; set; } = null!;
    }
}
