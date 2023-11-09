using DoranOfficeBackend.Dtos.LokasiKota;

namespace DoranOfficeBackend.Dtos.Masterpelanggan
{
    public class MasterpelangganWithLokasiKotaOptionDto:CommonResultDto
    {
        public LokasiKotaWithLokasiProvinsiDto LokasiKota { get; set; }

    }
}
