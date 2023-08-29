using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoranOfficeBackend.Models
{
    public partial class Dtrans
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Kodeh { get; set; }
        public short Koded { get; set; }
        public short Kodebarang { get; set; }
        public short Jumlah { get; set; }
        public int Harga { get; set; }
        public int Komisi { get; set; }
        public int Untung { get; set; }
        public sbyte PoinToko { get; set; }
        public bool? KuranginStok { get; set; }
        public sbyte Tukartipe { get; set; }
        public sbyte HargaOk { get; set; }
        public string Nmrsn { get; set; } = null!;
        public virtual Htrans? Htrans { get; set; }
        public virtual Masterbarang? Masterbarang { get; set; }
    }
}
