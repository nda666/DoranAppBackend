using DoranOfficeBackend.Models;
using _Masterbarang = DoranOfficeBackend.Models.Masterbarang;
namespace DoranOfficeBackend.Dtos.Transaksi
{
    public class HtransResultDto : PaginationResultDto
    {
        public ICollection<Htrans> Data {get; set;}
    }


    public class PaginationResultDto
    {
        public int TotalPage { get; set; } = 1;

        public int TotalRow { get; set; } = 1;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
