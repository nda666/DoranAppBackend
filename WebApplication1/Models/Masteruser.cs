
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoranOfficeBackend.Models
{
    //public partial class Masteruser : ITimestamps, ISoftDelete
    public partial class Masteruser
    {

        //[Key]
        //[Column("id")]
        //public Guid Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kodeku { get; set; }
        public string Usernameku { get; set; } = null!;
        public string Passwordku { get; set; } = null!;
        public string Akses { get; set; } = null!;
        public string? Sidikjari { get; set; } = null!;
        public bool? Aktif { get; set; }
        public int Kodesales { get; set; }

        //[Column("created_at")]
        //public DateTime? CreatedAt { get; set; }

        //[Column("updated_at")]
        //public DateTime? UpdatedAt { get; set; }

        //[Column("deleted_at")]
        //public DateTime? DeletedAt { get; set; }

        public Sales? Sales { get; set; }

        public virtual ICollection<Horder> HorderUserinsert { get; set; }
        public virtual ICollection<Horder> HorderUserupdate { get; set; }
        public virtual ICollection<Htransit> HtransitUserinsert { get; set; }
        public virtual ICollection<Htransit> HtransitUserupdate { get; set; }
    }
}
