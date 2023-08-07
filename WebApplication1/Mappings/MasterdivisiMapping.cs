using AutoMapper;
using DoranOfficeBackend.Dtos.Masterdivisi;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class MasterdivisiMapping : Profile
    {
        public MasterdivisiMapping()
        {
            CreateMap<SaveMasterdivisiDto, Masterdivisi>();
            CreateMap<Masterdivisi, SaveMasterdivisiDto>();
        }
    }
}
