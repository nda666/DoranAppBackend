using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dtos.Masterchannelsales
{
    public class FindMasterchannelsalesDto
    {
        [SwaggerSchema(Description = "Cari by nama")]
        public string? Nama { get; set; }

        [SwaggerSchema(Description = "Cari by Deleted/Not Deleted")]
        public string? Deleted { get; set; }
    }
}
