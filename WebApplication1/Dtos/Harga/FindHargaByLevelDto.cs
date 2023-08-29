using System.ComponentModel.DataAnnotations;

namespace DoranOfficeBackend.Dtos.Harga
{
    public class FindHargaByLevelDto
    {
        [Required]
        public List<int> Kodebarang { get; set; }

        [Required]
        public int Kodepelanggan { get; set; }

        [Required]
        public int Kodelevel { get; set; }
    }

}
