
using Swashbuckle.AspNetCore.Annotations;
using _Mastertimsales = DoranOfficeBackend.Models.Mastertimsales;

namespace DoranOfficeBackend.Dtos.Mastertimsales
{
    public class ReturnMastertimsalesDto: _Mastertimsales
    {
        public string? NamaChannel { get; set; }
    }
}
