namespace DoranOfficeBackend.Dtos.Stok
{
    public class GetStokMassRequestDto
    {
        public int KodeBarang { get; set; }
        public int[] Kodegudang { get; set; }
    }
}
