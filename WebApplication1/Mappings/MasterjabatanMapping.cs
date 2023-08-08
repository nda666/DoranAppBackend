using AutoMapper;
using DoranOfficeBackend.Dtos.Masterjabatan;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class MasterjabatanMapping : Profile
    {
        public MasterjabatanMapping()
        {
            CreateMap<SaveMasterjabatanDto, Masterjabatan>();
            CreateMap<Masterjabatan, SaveMasterjabatanDto>();
        }
    }
}
