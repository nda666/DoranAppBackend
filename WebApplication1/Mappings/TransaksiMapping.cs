using AutoMapper;
using DoranOfficeBackend.Dtos.Transaksi;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class TotalResolver : IValueResolver<SaveTransaksiDto, Htrans, long>
    {
        public long Resolve(SaveTransaksiDto source, Htrans destination, long dataType, ResolutionContext context)
        {
            return source.Details?.Sum(x => x.Harga * x.Jumlah) ?? 0;
        }
    }
    public class TransaksiMapping : Profile
    {
        public TransaksiMapping()
        {
            CreateMap<SaveTransaksiDto, Htrans>()
                .ForMember(dest => dest.Jumlah, opt => opt.MapFrom<TotalResolver>());
            CreateMap<DetailTransaksi, Dtrans>();
        }
    }
}
