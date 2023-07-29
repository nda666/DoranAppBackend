using DoranOfficeBackend.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoranOfficeBackend.Entities
{
    [Table("masterbarang")]
    public partial class MasterBarang : ITimestamps, ISoftDelete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 1)]
        public Guid? id { get; set; }

        [Column("brgNama", Order = 2, TypeName = "varchar(100)")]
        public string brgNama { get; set; }

        [Column("brgAktif", Order = 3)]
        public bool brgAktif { get; set; }

        [Column("brgHabis", Order = 4)]
        public int brgHabis { get; set; }

        [Column("modal", Order = 5)]
        public int modal { get; set; }

        [Column("hargatoko", Order = 6)]
        public int hargatoko { get; set; }

        [Column("hargaSRP", Order = 7)]
        public int hargaSRP { get; set; }

        [Column("minStokHabis", Order = 8)]
        public int minStokHabis { get; set; }

        [Column("maksstok", Order = 9)]
        public int maksstok { get; set; }

        [Column("poinToko", Order = 10)]
        public int poinToko { get; set; }

        [Column("supplierkode", Order = 11)]
        public int supplierkode { get; set; }

        [Column("tipebarang", Order = 12)]
        public int tipebarang { get; set; }

        [Column("hargaol", Order = 13)]
        public int hargaol { get; set; }

        [Column("namaol", Order = 14)]
        public string namaol { get; set; }

        [Column("brgspesial", Order = 15)]
        public int brgspesial { get; set; }

        [Column("komisi", Order = 16)]
        public int komisi { get; set; }

        [Column("dkategoribarang_id", Order = 17)]
        public Guid dkategoribarangId { get; set; }

        [Column("favorit", Order = 18)]
        public bool favorit { get; set; }

        [Column("groupbaranghabis", Order = 19)]
        public int groupbaranghabis { get; set; }

        [Column("diskontinu", Order = 20)]
        public bool diskontinu { get; set; }

        [Column("statusKirimanCina", Order = 21)]
        public int statusKirimanCina { get; set; }

        [Column("ketKirimanCina", Order = 22)]
        public string ketKirimanCina { get; set; }

        [Column("insertName", Order = 23)]
        public int insertName { get; set; }

        [Column("updateName", Order = 24)]
        public int updateName { get; set; }

        [Column("created_at", Order = 25, TypeName = "timestamp")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at", Order = 26, TypeName = "timestamp")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at", Order = 27, TypeName = "timestamp")]
        public DateTime? DeletedAt { get; set; }

        public virtual DkategoriBarang? DkategoriBarang { get; set; } = null!;
    }
}
