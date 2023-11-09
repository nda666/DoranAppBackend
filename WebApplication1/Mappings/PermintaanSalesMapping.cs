using AutoMapper;
using DoranOfficeBackend.Dtos.Order;
using DoranOfficeBackend.Dtos.PermintaanSales;
using DoranOfficeBackend.Models;
using DoranOfficeBackend.PermintaanSales.Order;

namespace DoranOfficeBackend.Mappings
{
  
    public class PermintaanSalesMapping : Profile
    {
        public PermintaanSalesMapping()
        {
            CreateMap<Horder, PermintaanSalesResult>();
            CreateMap<SavePermintaanSalesDto, Horder>();
            CreateMap<InsertDetailPermintaanSalesDto, Dorder>();
        }
    }
}
