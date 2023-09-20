using AutoMapper;
using DoranOfficeBackend.Dtos;
using DoranOfficeBackend.Dtos.Penyiaporder;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class PenyiaporderMapping:Profile
    {
        public PenyiaporderMapping()
        {
            CreateMap<SavePenyiaporderDto, Penyiaporder>();
            CreateMap<Penyiaporder, CommonResultDto>();
        }
    }
}
