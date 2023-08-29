using AutoMapper;
using DoranOfficeBackend.Dtos.Sethargalevel;
using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Mappings
{
    public class SethargalevelMapping : Profile
    {
        public SethargalevelMapping()
        {
            CreateMap<SaveSethargalevelDto, Sethargalevel>();
        }
    }
}
