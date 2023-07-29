using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Barangstokterkait
    {
        public int Id { get; set; }
        public int Kode { get; set; }
        public int Kodebarang1 { get; set; }
        public int Stok1 { get; set; }
        public int Kodebarang2 { get; set; }
        public int Stok2 { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
