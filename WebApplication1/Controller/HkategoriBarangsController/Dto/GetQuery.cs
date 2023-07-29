using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Controller.HkategoriBarangsController.Dto
{
    
    public class GetQuery
    {
        [SwaggerSchema(Description = "Cari by nama")]
        public string? Name { get; set; }

        [SwaggerSchema(Description = "Cari by Active")]
        public string? Active { get; set; }

        [SwaggerSchema(Description = "Cari by Deleted/Not Deleted")]
        public string? Deleted { get; set; }
    }
}
