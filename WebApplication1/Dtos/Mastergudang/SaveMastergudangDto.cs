namespace DoranOfficeBackend.Dtos.Mastergudang
{
    public class SaveMastergudangDto
    {
        public string? Nama { get; set; }
        public bool? Aktif { get; set; }
        public sbyte? Urut { get; set; }
        public bool? Boletransit { get; set; }
    }
}
