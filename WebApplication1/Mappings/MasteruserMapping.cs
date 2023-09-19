using AutoMapper;
using DoranOfficeBackend.Dtos.Masteruser;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class MasteruserMapping : Profile
    {
        public MasteruserMapping()
        {
            CreateMap<Masteruser, MasteruserOptionDto>();
        }
    }
}
