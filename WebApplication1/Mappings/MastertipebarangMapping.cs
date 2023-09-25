using AutoMapper;
using DoranOfficeBackend.Dtos;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class MastertipebarangMapping : Profile
    {
        public MastertipebarangMapping() {
            CreateMap<Mastertipebarang, CommonResultDto>();
        }
    }
}
