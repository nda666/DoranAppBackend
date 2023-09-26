namespace DoranOfficeBackend.Dtos.Transit
{
    /**
     * public class FindTransitDto
     */
    public class FindTransitDto : PaginationDto
    {
        public int? KodeT { get; set; }
        public int? Kodegudang { get; set; }
        public int? KodeGudangTujuan { get; set; }
        public string? NamaGudangTujuan { get; set; }
        public int? Kodepenyiap {  get; set; }
        public string? Historinya { get; set; }
        public DateTime? MinDate { get; set;}
        public DateTime? MaxDate { get; set; }
    }

}
