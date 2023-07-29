using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hupdate
    {
        public int KodeHupdate { get; set; }
        public int KodeH { get; set; }
        public sbyte InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public string Keterangan { get; set; } = null!;
    }
}
