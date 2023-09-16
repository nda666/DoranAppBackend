namespace DoranOfficeBackend.Dtos.Transaksi
{
    public class TransaksiBySalesResultDto
    {
        public short Kode { get; set; }
        public string Nama { get; set; }
        public long SumTotal { get; set; }
        public float Persen { get; set; }
    }
}
