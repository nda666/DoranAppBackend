namespace DoranOfficeBackend.Dtos.Order
{
    public enum LevelOrderEnum
    {
        ADMIN = 0,
        GUDANG = 1
    }
    /**
     * public class FindTransaksiDto
     */
    public class FindOrderDto : PaginationDto
    {
        public int? Kodeh { get; set; }
        public string?NamaPelanggan { get; set; }
        public string? NamaCust { get; set;}
        public int? Kodesales { get; set; }
        public int? Kodepelanggan { get; set; }
        public LevelOrderEnum? LevelOrder { get; set; }

        public bool BelumCekOl { get; set; } = false;
        public bool? SalesOl {  get; set; }
        public bool? Dicetak {  get; set; }
        public string? Lunas { get; set; }
        public DateTime? MinDate { get; set;}
        public DateTime? MaxDate { get; set; }
    }


}
