namespace DoranOfficeBackend.Dtos.Masteruser
{
    public class SaveMasteruserDto
    {
        public string Usernameku { get; set; } = null!;
        public string Passwordku { get; set; } = null!;
        public string Akses { get; set; } = null!;
        public bool Aktif { get; set; }
    }
}
