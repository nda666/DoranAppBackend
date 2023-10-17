using AutoMapper;
using DoranOfficeBackend.Dtos.Mastergudang;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class MastergudangMapping : Profile
    {
        public MastergudangMapping()
        {
            CreateMap<SaveMastergudangDto, Mastergudang>();
            CreateMap<Mastergudang, SaveMastergudangDto>();
            CreateMap<Mastergudang, MastergudangOptionDto>();
        }
    }
}
