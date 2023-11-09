namespace DoranOfficeBackend.Dtos.Transaksi
{
    public class DetailTransaksi
    {
        public short Kodebarang { get; set; }
        public short Jumlah { get; set; }
        public int Harga { get; set; }
        public string Nmrsn { get; set; } = null!;
    }

    public class UpdateTransaksiDto: SaveTransaksiDto
    {
        public bool HanyaGantiHarga { get; set; } = false;
        public bool CancelOrder { get; set; } = false;
    }
    public class SaveTransaksiDto
    {
        public bool? Force { get; set; } = false;
        public DateTime TglTrans { get; set; }
        public int KodePelanggan { get; set; }
        public int Jumlah { get; set; }
        public int Jumlahbarangbiaya { get; set; }
        public int TambahanLainnya { get; set; }

        /// <summary>
        /// 0=TIDAK_TERBIT. 1=TERBIT_FAKTUR_PPN
        /// </summary>
        public bool Terbitfakturppn { get; set; }
        public int Dpp { get; set; }
        public int Ppn { get; set; }
        public int Diskon { get; set; }
        public string Keterangan { get; set; } = null!;
        public int KodeSales { get; set; }
        public int Kodegudang { get; set; }
        public short SalesPenagih { get; set; }
        public bool StatusNota { get; set; }
        public string Retur { get; set; } = null!;
        public bool Stoknota { get; set; }
        public string? NoSeriOnline { get; set; } = "";
        public string? Barcodeonline { get; set; } = "";
        public sbyte? Tipetempo { get; set; }
        public DateTime? Tgltempo { get; set; }
        public string? Infopenting { get; set; } = "";
        public int? Kodeonline { get; set; }
        public string? NamaCust { get; set; } = "";
        public string? NmrHp { get; set; } = "";
        public int? NoOrder { get; set; } = 0;
        public List<DetailTransaksi> Details { get; set; }
    }
}
