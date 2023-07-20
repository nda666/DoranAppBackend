using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dto.SalesDto
{
    
    public class SalesQueryDto
    {
        [SwaggerSchema(Description = "Cari by nama")]
        public string? Name { get; set; }
        [SwaggerSchema(Description = "Cari by SalesTeamlId")]
        public string? SalesTeamlId { get; set; }

        [SwaggerSchema(Description = "Cari by IsManager")]
        public string? IsManager { get; set; }

        [SwaggerSchema(Description = "Cari by ManagerId")]
        public string? ManagerId { get; set; }

        [SwaggerSchema(Description = "Cari by GetOmzetEmail")]
        public string? GetOmzetEmail { get; set; }

        [SwaggerSchema(Description = "Cari by Active")]
        public string? Active { get; set; }

        [SwaggerSchema(Description = "Cari by Deleted/Not Deleted")]
        public string? Deleted { get; set; }
    }
}
