using DoranOfficeBackend.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoranOfficeBackend.Models
{
    //public partial class Mastergudang: ITimestamps, ISoftDelete
    public partial class Mastergudang
    {
        //[Column("id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public bool Aktif { get; set; }
        public sbyte? Urut { get; set; }
        public bool Boletransit { get; set; }

        //[Column("created_at")]
        //public DateTime? CreatedAt { get; set; }

        //[Column("updated_at")]
        //public DateTime? UpdatedAt { get; set; }

        //[Column("deleted_at")]
        //public DateTime? DeletedAt { get; set; }
        public virtual ICollection<Htrans> Htrans { get; set; }
        public virtual ICollection<Htransit> Htransit { get; set; }
        public virtual ICollection<Htransit> HtransitTujuan { get; set; }
        public virtual ICollection<Horder> Horder { get; set; }
    }
}
