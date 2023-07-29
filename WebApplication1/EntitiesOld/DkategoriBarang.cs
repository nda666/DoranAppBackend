using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DoranOfficeBackend.Entities.Interfaces;

namespace DoranOfficeBackend.Entities
{
    [Table("dkategoribarang")]
    public partial class DkategoriBarang: ITimestamps, ISoftDelete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public Guid? id { get; set; }

        [Column("nama", Order = 1, TypeName = "varchar(100)")]
        public string nama { get; set; }

        [Column("hkategoribarang_id", Order = 2)]
        public Guid hkategoribarangId { get; set; }

        [Column("munculdimasterbarangapps", Order = 3)]
        public bool munculdimasterbarangapps { get; set; }

        [Column("cnp", Order = 4)]
        public bool cnp { get; set; }

        [Column("sn", Order = 5)]
        public bool sn { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("created_at", Order = 6,  TypeName = "timestamp")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at", Order = 7, TypeName = "timestamp")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at", Order = 8, TypeName = "timestamp")]
        public DateTime? DeletedAt { get; set; }

        public virtual List<MasterBarang> MasterBarangs { get; set; }
        public virtual HkategoriBarang? HkategoriBarang { get; set; } = null!;
    }
}
