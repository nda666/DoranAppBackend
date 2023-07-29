using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Hdetailbayar
    {
        public int Kode { get; set; }
        public int Kodehbayar { get; set; }
        public int Kodesupplier { get; set; }
        public int Jumlah { get; set; }
        public sbyte InsertName { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
