using AutoMapper;
using DoranOfficeBackend.Dtos;
using DoranOfficeBackend.Dtos.Masterbarang;
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


            CreateMap<Masterpelanggan, CommonResultDto>();
            CreateMap<LokasiKota, CommonResultDto>();
            CreateMap<Sales, CommonResultDto>();
            CreateMap<Mastergudang, CommonResultDto>();
            CreateMap<Dtrans, DtransResult>();
            CreateMap<DtransResult, Dtrans>();
            CreateMap<Htrans, HtransResult>();

            CreateMap<Htrans, Htransarsip>();
            CreateMap<Dtrans, Dtransarsip>();
        }
    }
}
