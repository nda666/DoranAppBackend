using AutoMapper;
using DoranOfficeBackend.Dtos;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class LokasiKotaMapping:Profile
    {
        public LokasiKotaMapping()
        {
            CreateMap<LokasiKota, CommonResultDto>();
        }
    }
}
