using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dtos.HkategoriBarang
{
    public class SaveHkategoribarangDto
    {
        [SwaggerSchema(Description = "Nama")]
        public string Nama { get; set; }
        public bool Perlusetharga { get; set; }
        public bool Cektahunan { get; set; }
        public bool Hargakhusus { get; set; }
        public bool Aktif { get; set; }
    }
}
