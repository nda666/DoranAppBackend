namespace DoranOfficeBackend.Dtos.Transaksi
{
    public enum TransaksiBySalesTipeGroup
    {
        GROUP_BY_SALES=0,
        GROUP_BY_CHANNEL=1,
    }
    public enum TransaksiBySalesShowMode
    {
        BY_OMZET = 0,
        BY_PCS = 1
    }
    public class FindTransaksiBySalesDto
    {
        public TransaksiBySalesTipeGroup? TipeGroup { get; set; } = 0;
        public TransaksiBySalesShowMode? ShowMode { get; set; } = 0;
        public sbyte? JurnalPenjualan { get; set; }
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
