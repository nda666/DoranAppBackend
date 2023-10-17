
namespace DoranOfficeBackend.Dtos.Stok
{
    public class GetMutasiResultDto {
        public DateTime Tanggal { get; set; }
        public string Keterangan { get; set; }
        public string Oleh { get; set; }
        public int Harga { get; set; }
        public int Jumlah { get; set; }
        public int Saldo { get; set; }
        public int Indexnya { get; set; }
        public int KODEnya { get; set; }
        public int KodeSupplier { get; set; }
        public int KodeBarang { get; set; }
        public string History { get; set; }
        public string Lunas { get; set; }
    }
}
