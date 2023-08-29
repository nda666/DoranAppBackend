using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dtos.Sethargalevel
{
    public class SaveSethargalevelDto
    {
        ///<summary>Nama hkategoribarang</summary>
        public string Nama { get; set; } = null!;
        public float AcuanTambah { get; set; }
        public float AcuanPotong { get; set; }
        public int Modal { get; set; }
        public bool Online { get; set; }
        public sbyte Urutan { get; set; }
    }
}
