using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Penandajurnal
    {
        public int Kodeh { get; set; }
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public sbyte Kasmasuk { get; set; }
        public sbyte Kaskeluar { get; set; }
        public sbyte Bank { get; set; }
        public sbyte Jual { get; set; }
        public sbyte Beli { get; set; }
        public sbyte Memopengeluarantambahan { get; set; }
        public sbyte Memokomisi { get; set; }
        public sbyte Memogaji { get; set; }
        public sbyte Baranggratis { get; set; }
        public sbyte Barangretur { get; set; }
        public sbyte OngkirNetral { get; set; }
        public sbyte Ongkirkepelanggan { get; set; }
        public sbyte Lr { get; set; }
        public sbyte Neraca { get; set; }
        public int Namekasmasuk { get; set; }
        public DateTime Timekasmasuk { get; set; }
        public int Namekaskeluar { get; set; }
        public DateTime Timekaskeluar { get; set; }
        public int Namebank { get; set; }
        public DateTime Timebank { get; set; }
        public int Namejual { get; set; }
        public DateTime Timejual { get; set; }
        public int Namebeli { get; set; }
        public DateTime Timebeli { get; set; }
        public int Namememopengeluarantambahan { get; set; }
        public DateTime Timememopengeluarantambahan { get; set; }
        public int Namememokomisi { get; set; }
        public DateTime Timememokomisi { get; set; }
        public int Namememogaji { get; set; }
        public DateTime Timememogaji { get; set; }
        public int Namebaranggratis { get; set; }
        public DateTime Timebaranggratis { get; set; }
        public int Namebarangretur { get; set; }
        public DateTime Timebarangretur { get; set; }
        public int NameOngkirNetral { get; set; }
        public DateTime TimeOngkirNetral { get; set; }
        public int Nameongkirkepelanggan { get; set; }
        public DateTime Timeongkirkepelanggan { get; set; }
        public int NameLr { get; set; }
        public DateTime TimeLr { get; set; }
        public int NameNeraca { get; set; }
        public DateTime TimeNeraca { get; set; }
    }
}
