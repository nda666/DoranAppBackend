using AutoMapper;
using DoranOfficeBackend.Dtos.HkategoriBarang;
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
