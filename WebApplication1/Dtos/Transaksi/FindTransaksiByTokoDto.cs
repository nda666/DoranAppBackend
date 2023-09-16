namespace DoranOfficeBackend.Dtos.Transaksi
{
    public enum TransaksiByTokoTipeGroup
    {
        GROUP_BY_TOKO=0,
        GROUP_BY_KOTA=1,
    }
    public class FindTransaksiByTokoDto
    {
        public TransaksiByTokoTipeGroup? TipeGroup { get; set; } = 0;
        public int? Kodegudang { get; set; }
        public string? BrgNama { get; set; }
        public int? KodeKategori { get; set; }
        public int? KodeBrand { get; set; }
        public bool Retur { get; set; } = false;
        public int? KodeSales { get; set; }
        public int? KodeTimSales { get; set; }
        public int? KodeChannelSales { get; set; }
        public int? KodePelanggan { get; set; }
        public int? KodeKota { get; set; }
        public string? Lunas { get; set; }
        public string? Kodenota { get; set; }
        public int? KodeProvinsi { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
    }
}
