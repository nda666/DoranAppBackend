using AutoMapper;
using DoranOfficeBackend.Dtos;
using DoranOfficeBackend.Dtos.Transit;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
  
    public class TransitMapping : Profile
    {
        public TransitMapping()
        {
            CreateMap<DetailTransit, Dtransit>();
            CreateMap<Dtransit, DtransitResult>();
            CreateMap<DtransitResult, Dtransit>();

            CreateMap<SaveHeaderTransitDto, Htransit>();
            CreateMap<Htransit, HtransitResult>();
        }
    }
}
