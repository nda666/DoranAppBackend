using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DoranOfficeBackend.Entities.Interfaces;

namespace DoranOfficeBackend.Entities
{
    [Table("hkategoribarang")]
    public partial class HkategoriBarang: ITimestamps, ISoftDelete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public Guid? id { get; set; }

        [Column("nama", Order = 1, TypeName = "varchar(100)")]
        public string nama { get; set; }

        [Column("aktif", Order = 2)]
        public bool aktif { get; set; }

        [Column("created_at", Order = 3, TypeName = "timestamp")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at", Order = 4, TypeName = "timestamp")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at", Order = 5, TypeName = "timestamp")]
        public DateTime? DeletedAt { get; set; }

        public virtual List<DkategoriBarang>? DkategoriBarang { get; set; } = null!;
    }
}
