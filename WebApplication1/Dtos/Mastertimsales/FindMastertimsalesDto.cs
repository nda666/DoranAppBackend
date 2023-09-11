
using Swashbuckle.AspNetCore.Annotations;
namespace DoranOfficeBackend.Dtos.Mastertimsales
{
    public class FindMastertimsalesDto
    {
        [SwaggerSchema(Description = "Cari by nama")]
        public string? Nama { get; set; }

        [SwaggerSchema(Description = "Cari by aktif")]
        public bool? Aktif { get; set; }

        [SwaggerSchema(Description = "Cari by kode channel \"Masterchannelsales\"")]
        public string? Kodechannel { get; set; }

        [SwaggerSchema(Description = "Cari by deleted")]
        public string? Deleted { get; set; }

        public bool? WithSales { get; set; }
    }
}
