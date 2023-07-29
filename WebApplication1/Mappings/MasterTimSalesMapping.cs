using DoranOfficeBackend.Dtos.Mastertimsales;
using DoranOfficeBackend.Models;
using AutoMapper;
namespace DoranOfficeBackend.Mappings
{
    public class MasterTimSalesMapping : Profile
    {
        public MasterTimSalesMapping() {
            CreateMap<SaveMastertimsalesDto, Mastertimsales>();
            CreateMap<Mastertimsales, SaveMastertimsalesDto>();
        }
    }
}
