namespace DoranOfficeBackend.Dtos.PermintaanSales
{
    /**
     * public class GetOrderRequest
     */
    public class FindPermintaanSalesDto : PaginationDto
    {
        public int? Kodesales { get; set; }
        public int? Kodebarang { get; set; }
        public int? Kodegudang { get; set; }
        public string? Namagudang { get; set; }
       
    }
}
