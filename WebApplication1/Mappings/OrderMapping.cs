using AutoMapper;
using DoranOfficeBackend.Dtos;
using DoranOfficeBackend.Dtos.Masteruser;
using DoranOfficeBackend.Dtos.Order;
using DoranOfficeBackend.Dtos.Transaksi;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class TotalOrderResolver : IValueResolver<SaveOrderDto, Horder, int>
    {
        public int Resolve(SaveOrderDto source, Horder destination, int dataType, ResolutionContext context)
        {
            return source.Details?.Sum(x => x.Harga * x.Jumlah) ?? 0;
        }
    }
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<DetailOrder, Dorder>();
            CreateMap<SaveOrderHeaderDto, Horder>();
            CreateMap<SaveOrderDto, Horder>()
                .ForMember(dest => dest.Jumlah, opt => opt.MapFrom<TotalOrderResolver>());
         
            CreateMap<Dorder, DorderResult>();
            CreateMap<DorderResult, Dorder>();
            CreateMap<Horder, HorderResult>();
        }
    }
}
