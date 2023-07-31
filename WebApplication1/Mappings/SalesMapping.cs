using AutoMapper;
using DoranOfficeBackend.Dtos.Sales;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class SalesMapping : Profile
    {
        public SalesMapping()
        {
            CreateMap<SaveSalesDto, Sales>();
            CreateMap<Sales, SaveSalesDto>();
            CreateMap<Sales, SalesDto>()
                .ForMember(dest => dest.NamaManager, opt => opt.MapFrom(sales => sales.SalesManager.Nama ?? ""))
                .ForMember(dest => dest.NamaTim, opt => opt.MapFrom(sales => sales.Mastertimsales.Nama ?? ""))
                ;
        }
    }
}
