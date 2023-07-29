using DoranOfficeBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoranOfficeBackend.Models
{
    public partial class Mastertimsales: ITimestamps, ISoftDelete
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public sbyte Kode { get; set; }
        public string Nama { get; set; } = null!;
        public long Targetjete { get; set; }
        public long Targetomzet { get; set; }
        public bool Tampiltahunlalu { get; set; }
        public bool Aktif { get; set; }

        public bool SyaratKomisi { get; set; }
        public int Kodechannel { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public virtual  Masterchannelsales? Masterchannelsales { get; set; }
    }
}
