namespace DoranOfficeBackend.Dtos.Order
{
    public class DetailOrder
    {
        public short Kodebarang { get; set; }
        public short Jumlah { get; set; }
        public int Harga { get; set; }
        public string Keterangan { get; set; } = null!;
    }
    public class SaveOrderDto
    {
        public DateTime Tglorder { get; set; }
        public string Keterangan { get; set; } = null!;
        public int Kodepelanggan { get; set; }
        public int Kodesales { get; set; }
        public int Kodeexp { get; set; }

        /// <summary>
        /// 0=Belum Diisi;
        /// 1=Darat;
        /// 2=Udara;
        /// 3=Laut;
        /// </summary>
        public sbyte Kirimmelalui { get; set; }
        public int Ppn { get; set; }
        public sbyte? Tipetempo { get; set; }
        public DateTime Tgltempo { get; set; }
        public string Infopenting { get; set; } = null!;
        public string NoSeriOnline { get; set; } = null!;
        public string Barcodeonline { get; set; } = null!;
        public string NamaCust { get; set; } = null!;
        public string NmrHp { get; set; } = null!;
        public int Kodeonline { get; set; }
        public int Kodeorderapps { get; set; }
        public List<DetailOrder> Details { get; set; }
    }
}
