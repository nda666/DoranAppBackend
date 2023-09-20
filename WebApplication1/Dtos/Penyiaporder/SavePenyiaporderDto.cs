using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dtos.Penyiaporder
{
    public class SavePenyiaporderDto
    {
        ///<summary>Nama hkategoribarang</summary>
        public string Nama { get; set; }
        public bool Aktif { get; set; }

    }
}
