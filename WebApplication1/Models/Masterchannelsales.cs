using DoranOfficeBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoranOfficeBackend.Models
{
    //public partial class Masterchannelsales: ITimestamps, ISoftDelete
    public partial class Masterchannelsales
    {
        //[Column("id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;

        [Column("aktif")]
        public bool Aktif { get; set; }

        //[Column("created_at")]
        //public DateTime? CreatedAt { get; set; }

        //[Column("updated_at")]
        //public DateTime? UpdatedAt { get; set; }

        //[Column("deleted_at")]
        //public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Mastertimsales> Mastertimsales { get; set; }
    }
}
