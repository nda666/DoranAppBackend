namespace DoranOfficeBackend.Dtos.Order
{
    public class PrintOrderResultDto
    {
        public PrintHorderDto Horder { get; set; }
        public List<PrintDorderDto> Dorder { get; set; }
        public sbyte PrintOl { get; set; }
        public string? TotalBarangLabel { get; set; }
        public string? JumlahKirimanLabel { get; set; }
    }

    public class PrintHorderDto
    {
        public int KodeH { get; set; }
        public string InfoPenting { get; set; }
        public string Keterangan { get; set; }
        public string Tanggal { get; set; }
        public string Nama { get; set; }
        public string NamaSales { get; set; }
        public string Lokasi { get; set; }
        public string PenyiapOrder { get; set; }
        public string TanggalInput { get; set; }
        public string TanggalCetak { get; set; }
        public string NamaExp { get; set; }
        public string Melalui { get; set; }
    }

    public class PrintDorderDto {
        public string NamaKeterangan { get; set; }
        public string NamaBarang { get; set; }
        public int Pcs { get; set; }
        public string KeteranganBrg { get; set; }
        public int StokAtas { get; set; }
        public int StokBawah { get; set; }
        public int StokSales { get; set; }
    }
}
