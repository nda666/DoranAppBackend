﻿using DoranOfficeBackend.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoranOfficeBackend.Models
{
    //public partial class Masterdivisi : ITimestamps, ISoftDelete
    public partial class Masterdivisi 
    {
        //[Column("id")]
        //public Guid Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;

        //[Column("created_at")]
        //public DateTime? CreatedAt { get; set; }

        //[Column("updated_at")]
        //public DateTime? UpdatedAt { get; set; }

        //[Column("deleted_at")]
        //public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Masterpegawai>? Masterpegawais { get; set; }
    }
}
