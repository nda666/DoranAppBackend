namespace DoranOfficeBackend.Dtos.LaporanTransaksiPenjualan
{
    public class GetLaporanTransaksiPenjualanGroupTokoDto
    {
        public int Nomornya { get; set; }
        public int SalesPemilik { get; set; }
        public string Email { get; set; }
        public string Nama { get; set; }
        public string NamaSales { get; set; }
        public string NamaKota { get; set; }
        public decimal JumlahNya { get; set; }
        public decimal PersenUntung { get; set; }
        public decimal Limitnya { get; set; }
        public sbyte Blok { get; set; }
        public int KodePelanggan { get; set; }
        public decimal Untungnya { get; set; }

    }
}
