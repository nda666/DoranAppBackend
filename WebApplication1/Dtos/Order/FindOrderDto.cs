namespace DoranOfficeBackend.Dtos.Order
{
    /**
     * public class FindTransaksiDto
     */
    public class FindOrderDto : PaginationDto
    {
        public int? Kodeh { get; set; }
        public int? Kodegudang { get; set; }
        public string? NamaPelanggan {get; set;}

        public int? Kodesales { get; set; }

        public int? Kodepelanggan { get; set; }

        public int? KodeKota { get; set; }

        public string? Lunas { get; set; }

        public string? Kodenota { get; set; }

        public int? KodeProvinsi { get; set; }
        public DateTime? MinDate { get; set;}
        public DateTime? MaxDate { get; set; }

        public int? Limit { get; set; }
    }


}
