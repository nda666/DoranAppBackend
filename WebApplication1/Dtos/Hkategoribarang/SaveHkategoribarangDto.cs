using Swashbuckle.AspNetCore.Annotations;

namespace DoranOfficeBackend.Dtos.HkategoriBarang
{
    public class SaveHkategoribarangDto
    {
        ///<summary>Nama hkategoribarang</summary>
        public string Nama { get; set; }
        public bool Perlusetharga { get; set; }
        public bool Cektahunan { get; set; }
        public bool Hargakhusus { get; set; }
        public bool Aktif { get; set; }
    }
}
