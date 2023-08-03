using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dtos.HkategoriBarang
{
    
    public class FindHkategoribarangDto
    {
        [SwaggerSchema(Description = "Cari by nama")]
        public string? Nama { get; set; }

        [SwaggerSchema(Description = "Cari by aktif")]
        public bool? Aktif { get; set; }

        [SwaggerSchema(Description = "Cari by Deleted/Not Deleted")]
        public bool? Deleted { get; set; }
    }
}
