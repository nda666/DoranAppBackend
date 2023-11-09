using AutoMapper;
using DoranOfficeBackend.Dtos.Mastersupplier;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class MastersupplierMapping : Profile
    {
        public MastersupplierMapping()
        {
            CreateMap<SaveMastersupplierDto, Mastersupplier>();
            CreateMap<Mastersupplier, SaveMastersupplierDto>();
        }
    }
}
