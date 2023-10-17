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
    public class GetOrderRequest : PaginationDto
    {
        public int? Kodeh { get; set; }
        public string?NamaPelanggan { get; set; }
        public string? NamaCust { get; set;}
        public int? Kodesales { get; set; }
        public int? Kodepelanggan { get; set; }
        public int? Kodegudang { get; set; }
        public sbyte? Historynya { get; set; }
        public LevelOrderEnum? LevelOrder { get; set; }

        /// <summary>
        /// "You can use the pattern function like '%' for example: '%value%
        /// </summary>
        public string? NoSeriOnline { get; set; }

        /// <summary>
        /// "You can use the pattern function like '%' for example: '%value%
        /// </summary>
        public string? Barcodeonline { get; set; }
        public bool BelumCekOl { get; set; } = false;
        public bool? SalesOl {  get; set; }
        public bool? Dicetak {  get; set; }
        public sbyte? Lunas { get; set; }
        public DateTime? MinDate { get; set;}
        public DateTime? MaxDate { get; set; }
    }

    public class FindOrderRequest : GetOrderRequest
    {
        public bool CheckTransaksi { get; set ; } = false;
    }
}
