

namespace DoranOfficeBackend.Dtos.Sales
{
    public class SaveSalesDto
    {
        public sbyte Kode { get; set; }
        public string Nama { get; set; } = null!;
        public bool Aktif { get; set; }
        public sbyte Urutan { get; set; }
        public sbyte Tipe { get; set; }
        public string NamaPendamping { get; set; } = null!;
        /// <summary>
        /// 1 = Terima Email OMZET
        /// </summary>
        public bool Jenis { get; set; }
        public string Email { get; set; } = null!;
        public string Emailspv { get; set; } = null!;
        public int T1 { get; set; }
        public int T2 { get; set; }
        public int T3 { get; set; }
        public int T4 { get; set; }
        public int T5 { get; set; }
        public string Tim { get; set; } = null!;
        public sbyte Salesol { get; set; }
        public int Kodepegawai { get; set; }
        public sbyte Manager { get; set; }
        public sbyte Kodemanager { get; set; }
        public sbyte Persenkomisi { get; set; }
        public sbyte Persenbonus { get; set; }
        public sbyte Emailbos { get; set; }
        public sbyte Syaratbonus { get; set; }
        public sbyte Kodetimsales { get; set; }
        public bool Bisalihatomzettahunantim { get; set; }
        public bool EmailOmzetTerdahsyat { get; set; }
        public bool EmailJeteterdahsyat { get; set; }
        public bool EmailTargetTahunan { get; set; }
        public bool Emailresikiriman { get; set; }

        public int BonusJete { get; set; }
    }
}
