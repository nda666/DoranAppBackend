namespace DoranOfficeBackend.Dtos.Mastertimsales
{
    public class SaveMastertimsalesDto
    {
        [Swashbuckle.AspNetCore.Annotations.SwaggerRequestBody(Description = "Nama Mastertimsales", Required = true)]
        public string Nama { get; set; } = null!;
        public long Targetjete { get; set; }
        public long Targetomzet { get; set; }
        public bool Tampiltahunlalu { get; set; }
        public bool Aktif { get; set; }
        public bool SyaratKomisi { get; set; }

        [
            Swashbuckle.AspNetCore.Annotations.SwaggerRequestBody(
            Description = "Kode channel from masterchannelsales", Required = true)
        ]
        public int Kodechannel { get; set; }
    }
}
