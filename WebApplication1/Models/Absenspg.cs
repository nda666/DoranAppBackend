using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Absenspg
    {
        public int Id { get; set; }
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public int KodePegawai { get; set; }
        public int Absen { get; set; }
        public int Jumtelat { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
