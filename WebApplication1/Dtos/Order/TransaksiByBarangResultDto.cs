namespace DoranOfficeBackend.Dtos.Transaksi
{
    public class TransaksiByBarangResultDto
    {
        public short Kode { get; set; }
        public string Nama { get; set; }
        public long Jumlah { get; set; }
        public long SumTotal { get; set; }
    }
}
