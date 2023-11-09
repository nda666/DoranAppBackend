using DoranOfficeBackend.Models;

namespace DoranOfficeBackend.Dtos.Transaksi
{
    public class NotaTransaksiPpnResultDto
    {
        public string Kodenota { get; set; }
        public int Tambahanlainnya { get; set; }
        public decimal Diskon { get; set; }
        public int Kodeh { get; set; }
        public decimal Dpp { get; set; }
        public decimal Ppn { get; set; }
        public decimal Diskonppn { get; set; }
        public DateTime Tanggal { get; set; }
        public DateTime TglPPN { get; set; }
        public string Infopenting { get; set; }
        public DateTime Tgltempo { get; set; }
        public string Tipetempo { get; set; }
        public string Nama { get; set; }
        public decimal Jumlah { get; set; }
        public string Oleh { get; set; }
        public string Namasales { get; set; }
        public string Lokasi { get; set; }
        public List<DetailNotaTransaksiPpnResultDto> Detail { get; set; } // List of DTransDto objects
        public decimal TotalNya { get; set; }
    }

    public class DetailNotaTransaksiPpnResultDto
    {
        public string Namabarang { get; set; }
        public int Pcs { get; set; }
        public int Kodebarang { get; set; }
        public decimal Harganya { get; set; }
        public decimal Hargabelumppn { get; set; }
        public decimal Subtotalbelumppn { get; set; }
        public decimal TotalNya { get; set; }
    }
}
