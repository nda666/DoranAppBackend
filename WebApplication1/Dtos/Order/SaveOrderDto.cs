namespace DoranOfficeBackend.Dtos.Order
{
    public class DetailOrder
    {
        public short Kodebarang { get; set; }
        public short Jumlah { get; set; }
        public int Harga { get; set; }
        public string Keterangan { get; set; } = null!;
    }
    public class SaveOrderDto: SaveOrderHeaderDto
    {
        public List<DetailOrder> Details { get; set; }
    }
}
