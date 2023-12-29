namespace DoranOfficeBackend.Dtos.LokasiKota
{
    public class LokasiKotaDataDto
    {
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public sbyte Provinsi { get; set; }
        public sbyte Kodeareapengiriman { get; set; }
        public int Kodecoa4 { get; set; }
        public sbyte AdaKertasOrder { get; set; }
        public string NamaProvinsi { get; set; } = null!;
        public string NamaCoa { get; set; } = null!;
    }
}
