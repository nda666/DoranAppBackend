namespace DoranOfficeBackend.Dtos
{
    public class PaginationDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }



    public class PaginationResultDto
    {
        public long TotalPage { get; set; } = 1;

        public long TotalRow { get; set; } = 1;
        public long Page { get; set; } = 1;
        public long PageSize { get; set; } = 20;
    }
}
