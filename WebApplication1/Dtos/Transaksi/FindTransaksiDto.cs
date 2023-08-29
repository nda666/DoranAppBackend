namespace DoranOfficeBackend.Dtos.Transaksi
{
    /**
     * public class FindTransaksiDto
     */
    public class FindTransaksiDto : PaginationDto
    {
        public int? Kodegudang { get; set; }
        public string? NamaPelanggan {get; set;}

        public DateTime? MinDate { get; set;}

        public DateTime? MaxDate { get; set; }
    }

    public class PaginationDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
