using AutoMapper;
using DoranOfficeBackend.Dtos;
using DoranOfficeBackend.Dtos.LokasiProvinsi;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class LokasiProvinsiMapping : Profile
    {
        public LokasiProvinsiMapping()
        {
            CreateMap<LokasiProvinsi, CommonResultDto>();
            CreateMap<SaveLokasiProvinsiDto, LokasiProvinsi>();
        }
    }
}
