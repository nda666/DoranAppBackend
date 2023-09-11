using DoranOfficeBackend.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoranOfficeBackend.Models
{
    //public partial class Hkategoribarang : ITimestamps, ISoftDelete
    public partial class Hkategoribarang
    {
        //[Column("id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kodeh { get; set; }
        public string Nama { get; set; } = null!;
        public bool Aktif { get; set; }
        public bool Perlusetharga { get; set; }
        public bool Cektahunan { get; set; }
        public bool Hargakhusus { get; set; }

        //[Column("created_at")]
        //public DateTime? CreatedAt { get; set; }

        //[Column("updated_at")]
        //public DateTime? UpdatedAt { get; set; }

        //[Column("deleted_at")]
        //public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Dkategoribarang> Dkategoribarang { get; set; }
    }
}
