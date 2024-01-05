using DoranOfficeBackend.Dtos.LokasiKota;

namespace DoranOfficeBackend.Dtos.Masterpelanggan
{
    public class MasterpelangganWithLokasiKotaOptionDto:CommonResultDto
    {
        public string? Npwp { get; set; }
        public LokasiKotaWithLokasiProvinsiDto LokasiKota { get; set; }

    }
}
 