using AutoMapper;
using DoranOfficeBackend.Dtos.Masterpelanggan;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class MasterpelangganMapping:Profile
    {
        public MasterpelangganMapping()
        {
            CreateMap<Masterpelanggan, MasterpelangganWithLokasiKotaOptionDto>();
        }
    }
}
