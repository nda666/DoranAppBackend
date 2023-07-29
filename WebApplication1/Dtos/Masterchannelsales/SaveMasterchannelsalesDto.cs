namespace DoranOfficeBackend.Dtos.Masterchannelsales
{
    public class SaveMasterchannelsalesDto
    {
        [Swashbuckle.AspNetCore.Annotations.SwaggerRequestBody(Description = "Nama master_channel_sales", Required = true)]
        public string Nama { get; set; }

        public bool Aktif { get; set; }
    }
}
