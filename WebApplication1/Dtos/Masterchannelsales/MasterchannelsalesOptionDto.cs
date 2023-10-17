using DoranOfficeBackend.Dtos.Mastertimsales;
using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dtos.Masterchannelsales
{
    public class MasterchannelsalesOptionDto
    {
        public int? Kode { get; set; }
        public string Nama { get; set; }

        public ICollection<MastertimsalesOptionDto> Mastertimsales { get; set; } = new List<MastertimsalesOptionDto>();
    }
}
