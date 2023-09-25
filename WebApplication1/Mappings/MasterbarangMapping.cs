using AutoMapper;
using DoranOfficeBackend.Dtos;
using DoranOfficeBackend.Dtos.Masterbarang;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class MasterbarangMapping : Profile
    {
        public MasterbarangMapping() {
            CreateMap<Masterbarang, MasterbarangOptionDto>();
            CreateMap<Masterbarang, MasterbarangOptionWithTipeDto>();
        }
    }
}