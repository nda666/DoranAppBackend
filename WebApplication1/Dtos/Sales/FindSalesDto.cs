namespace DoranOfficeBackend.Dtos.Sales
{
    public class FindSalesDto
    {
        public string? Nama { get; set; }
        public bool? Aktif { get; set; }
        public sbyte? Kodetimsales { get; set; }
        public bool? Manager { get; set; }

        public bool? Deleted { get; set; }
    }
}
