using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dtos.LokasiProvinsi
{
    
    public class FindLokasiProvinsiDto
    {
        [SwaggerSchema(Description = "Cari by nama")]
        public string? Nama { get; set; }

        [SwaggerSchema(Description = "Cari by aktif")]
        public bool? Aktif { get; set; }
    }
}
