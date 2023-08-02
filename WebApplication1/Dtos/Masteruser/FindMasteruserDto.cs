namespace DoranOfficeBackend.Dtos.Masteruser
{
    public class FindMasteruserDto
    {
        public string? Username { get; set; }
        public string? Akses { get; set; }
        public bool? Aktif { get; set; }
        public bool? Deleted { get; set; }
    }
}
