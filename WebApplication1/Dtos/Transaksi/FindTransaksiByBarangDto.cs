﻿namespace DoranOfficeBackend.Dtos.Transaksi
{
    public enum TransaksiByBarangTipeGroup
    {
        GROUP_BY_BARANG=0,
        GROUP_BY_BRAND=1,
        GROUP_BY_SUBBRAND=2,
    }
    public class FindTransaksiByBarangDto
    {
        public TransaksiByBarangTipeGroup? TipeGroup { get; set; } = 0;
        public int? Kodegudang { get; set; }
        public string? BrgNama { get; set; }
        public string? BrgNama2 { get; set; }
        public string? BrgNama3 { get; set; }
        public string? BrgNama4 { get; set; }
        public string? BrgNama5 { get; set; }
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
