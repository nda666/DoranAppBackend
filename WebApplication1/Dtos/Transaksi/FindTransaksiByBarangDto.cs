namespace DoranOfficeBackend.Dtos.Transaksi
{
    public class FindTransaksiByBarangDto
    {
        public int? Kodegudang { get; set; }
        public string? BrgNama { get; set; }

        public int? KodeSales { get; set; }

        public int? KodePelanggan { get; set; }

        public int? KodeKota { get; set; }

        public string? Lunas { get; set; }

        public string? Kodenota { get; set; }

        public int? KodeProvinsi { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
    }
}
