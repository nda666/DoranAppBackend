using AutoMapper;
using DoranOfficeBackend.Dtos.Hkelompokbarang;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class HkelompokbarangMapping : Profile
    {
        public HkelompokbarangMapping()
        {
            CreateMap<SaveHkelompokbarangDto, Hkelompokbarang>();
            CreateMap<Hkelompokbarang, SaveHkelompokbarangDto>();
        }
    }
}
