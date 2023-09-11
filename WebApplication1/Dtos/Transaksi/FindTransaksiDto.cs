﻿namespace DoranOfficeBackend.Dtos.Transaksi
{
    /**
     * public class FindTransaksiDto
     */
    public class FindTransaksiDto : PaginationDto
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

        public int? Limit { get; set; }
    }

    public class PaginationDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
