using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dtos.Mastertimsales
{
    [SwaggerSchema(Required = new[] { "Nama" , "Kodechannel" })]
    public class SaveMastertimsalesDto
    {
        [SwaggerRequestBody("Add a new Pet to the store")]
        public string Nama { get; set; } = null!;
        public long Targetjete { get; set; }
        public long Targetomzet { get; set; }
        public bool Tampiltahunlalu { get; set; }
        public bool Aktif { get; set; }
        public bool SyaratKomisi { get; set; }

        [SwaggerSchema("Kode channel from masterchannelsale")]
        public int Kodechannel { get; set; }
    }
}
