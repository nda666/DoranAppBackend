using AutoMapper;
using DoranOfficeBackend.Dtos.Hkategoribarang;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class HkategoribarangMapping : Profile
    {
        public HkategoribarangMapping()
        {
            CreateMap<SaveHkategoribarangDto, Hkategoribarang>();
        }
    }
}
