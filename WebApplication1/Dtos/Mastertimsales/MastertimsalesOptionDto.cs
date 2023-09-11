

using DoranOfficeBackend.Dtos.Sales;

namespace DoranOfficeBackend.Dtos.Mastertimsales
{
    public class MastertimsalesOptionDto

    {
        public sbyte Kode { get; set; }
        public string Nama { get; set; }

        public int Kodechannel { get; set; }

        public List<SalesOptionDto> Sales { get; set; } = new List<SalesOptionDto>();
    }
}
