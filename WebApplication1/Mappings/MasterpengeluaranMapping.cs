using AutoMapper;
using DoranOfficeBackend.Dtos;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class MasterpengeluaranMapping:Profile
    {
        public MasterpengeluaranMapping()
        {
            CreateMap<Masterpengeluaran,CommonResultDto>();
        }
    }
}
