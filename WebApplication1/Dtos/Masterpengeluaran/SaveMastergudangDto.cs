namespace DoranOfficeBackend.Dtos.Masterpengeluaran
{
    public class SaveMasterpengeluaranDto
    {
        public string? Nama { get; set; }
        public bool? Aktif { get; set; }
        public sbyte? Urut { get; set; }
        public bool? Boletransit { get; set; }
    }
}
