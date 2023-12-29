using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dtos.LokasiKota
{
    public class SaveLokasiKotaDto
    {
        public string Nama { get; set; }
        public sbyte Provinsi { get; set; }
    }

    public class SetCoaLokasiKota
    {
        public int KodeCoa4 { get; set; }
    }
}
