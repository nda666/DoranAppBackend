using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dto.SalesTeamDto
{
    [SwaggerSchema(Required = new[] { "Description" })]
    public class SalesTeamQueryDto
    {
        [SwaggerSchema(Description = "Cari by nama")]
        public string? Name { get; set; }

        public string? Active { get; set; }

        public string? SalesChannelId { get; set; }

        public string? Deleted { get; set; }
    }
}
