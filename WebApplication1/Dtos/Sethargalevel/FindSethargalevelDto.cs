using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dtos.Sethargalevel
{
    
    public class FindSethargalevelDto
    {
        public string? Nama { get; set; } = null!;
        public float? AcuanTambah { get; set; }
        public float? AcuanPotong { get; set; }
        public int? Modal { get; set; }
        public bool? Online { get; set; }
    }
}
