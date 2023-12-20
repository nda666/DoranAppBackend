namespace DoranOfficeBackend.Dtos.Transaksi
{
    public class OmzetBelumLunasBySalesQueryParams
    {
        public DateTime DateMin { get; set; }
        public DateTime DateMax { get; set; }
        public int[] KodeSales { get; set; }

    }
}
