namespace DoranOfficeBackend.Dtos.Transit
{
    public class DetailTransit
    {
        public short Kodebarang { get; set; }
        public short Jumlah { get; set; }
        public int Harga { get; set; }
        public string Nmrsn { get; set; } = null!;
    }
    public class SaveTransitDto
    {
        public DateTime TglTrans { get; set; }
        public int KodePelanggan { get; set; }
        public int Jumlah { get; set; }
        public int Jumlahbarangbiaya { get; set; }
        public int TambahanLainnya { get; set; }
        public int Dpp { get; set; }
        public int Ppn { get; set; }
        public int Diskon { get; set; }
        public string Keterangan { get; set; } = null!;
        public sbyte KodeSales { get; set; }
        public int Kodegudang { get; set; }
      
        public short SalesPenagih { get; set; }
        public bool StatusNota { get; set; }
        public string Retur { get; set; } = null!;
        public bool Stoknota { get; set; }
        public string? NoSeriOnline { get; set; } = null!;
        public string? Barcodeonline { get; set; } = null!;
        public sbyte? Tipetempo { get; set; }
        public DateTime? Tgltempo { get; set; }
        public string? Infopenting { get; set; } = null!;
        public int? Kodeonline { get; set; }
        public string? NamaCust { get; set; } = null!;
        public string? NmrHp { get; set; } = null!;
        public List<DetailTransit> Details { get; set; }
    }
}
