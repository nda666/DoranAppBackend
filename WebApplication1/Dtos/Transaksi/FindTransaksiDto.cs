namespace DoranOfficeBackend.Dtos.Transaksi
{
    /**
     * public class FindTransaksiDto
     */
    public class FindTransaksiPaginationDto : PaginationDto
    {
        public int? Kodeh { get; set; }
        public int? Kodegudang { get; set; }
        public string? NamaPelanggan {get; set;}
        public int? KodeSales { get; set; }
        public int? KodePelanggan { get; set; }
        public int? KodeKota { get; set; }
        public string? Lunas { get; set; }
        public string? Kodenota { get; set; }
        public int? KodeProvinsi { get; set; }
        public DateTime? MinDate { get; set;}
        public DateTime? MaxDate { get; set; }
        public int? InsertName { get; set; }
        public string? Keterangan { get; set; }
        public string? NamaBarang { get; set; }
        public int? HargaMin { get; set; }
        public int? HargaMax { get; set; }
        public bool? HargaTidakNol { get; set; }
        public string? NoSeriOnline { get; set; }
        public string? Barcodeonline { get; set; }
        public bool? SudahJatuhTempo { get; set; }
        public int? Jumlah { get; set; }
        public sbyte? TipeTempo { get; set; }
        public bool? NotaTitip { get; set; }
        public bool? Admingantiharga { get; set; }
        public sbyte? AkanDjJurnalkan { get; set; }
        public sbyte? Valid { get; set; }
        public int? Limit { get; set; }
    }

    public class FindTransaksiDto
    {
        public int? Kodeh { get; set; }
        public int? Kodegudang { get; set; }
        public string? NamaPelanggan { get; set; }

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
