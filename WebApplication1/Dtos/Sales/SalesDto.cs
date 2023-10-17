namespace DoranOfficeBackend.Dtos.Sales
{
    public class SalesDto
    {
        public Guid Id { get; set; }
        public int Kode { get; set; }
        public string Nama { get; set; }
        public bool Aktif { get; set; }
        public sbyte Urutan { get; set; }
        public sbyte Tipe { get; set; }
        public string NamaPendamping { get; set; } 
        public bool Jenis { get; set; }
        public string Email { get; set; }
        public string Emailspv { get; set; }
        public int T1 { get; set; }
        public int T2 { get; set; }
        public int T3 { get; set; }
        public int T4 { get; set; }
        public int T5 { get; set; }
        public string Tim { get; set; } = null!;
        public bool Salesol { get; set; }
        public int Kodepegawai { get; set; }
        public bool Manager { get; set; }
        public int Kodemanager { get; set; }
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
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? NamaManager { get; set; }
        public string? NamaTim { get; set; }
    }

}
