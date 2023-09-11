using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoranOfficeBackend.Models
{
    public partial class Dkategoribarang
    {
        [Key]
        public int Koded { get; set; }
        public string Nama { get; set; } = null!;
        public int Kodeh { get; set; }
        public sbyte Munculdimasterbarangapps { get; set; }
        public sbyte Cnp { get; set; }
        public bool Sn { get; set; }
        public sbyte Perlusetharga { get; set; }
        public virtual ICollection<Masterbarang> Masterbarang { get; set; }

        public virtual Hkategoribarang? Hkategoribarang { get; set; }
    }
}
