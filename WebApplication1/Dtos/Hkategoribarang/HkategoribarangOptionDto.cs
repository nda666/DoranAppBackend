
using DoranOfficeBackend.Dtos.Dkategoribarang;
using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dtos.Hkategoribarang
{
    public class HkategoribarangOptionDto
    {
        public int? Kodeh { get; set; }
        public string? Nama { get; set; }

        public List<DkategoribarangOptionDto> Dkategoribarang { get; set; }

    }
}
