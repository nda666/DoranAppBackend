using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoranOfficeBackend.Models
{
    public partial class Masterpegawai
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public int Kodejabatan { get; set; }
        public int Kodedivisi { get; set; }
        public string Pass { get; set; } = null!;
        public string Ktp { get; set; } = null!;
        public string Npwp { get; set; } = null!;
        public DateTime Tgllahir { get; set; }
        public DateTime Tgljoin { get; set; }
        public sbyte Aktif { get; set; }
        public string Alamat { get; set; } = null!;
        public string Telp { get; set; } = null!;
        public string Jabatan { get; set; } = null!;
        public sbyte Akses { get; set; }
        public bool Pengiriman { get; set; }
        public sbyte Grupnilai { get; set; }
        public string Rek { get; set; } = null!;
        public string Sidikjari { get; set; } = null!;
        public sbyte Kodejamkerja { get; set; }
        public string Email { get; set; } = null!;
        public int Grupgaji { get; set; }
        public int Bpjsbyperush { get; set; }
        public int Bpjsbysendiri { get; set; }
        public int Bpjstk { get; set; }
        public int Kodeatasan { get; set; }
        public sbyte Laporan { get; set; }
        public sbyte KodeAgama { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
        public virtual Masterdivisi? Masterdivisi { get; set; }

        public virtual Masterjabatan? Masterjabatan { get; set; }
    }
}
