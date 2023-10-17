using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Horder
    {
        public int Kodeh { get; set; }
        public DateTime Tglorder { get; set; }
        public string Keterangan { get; set; } = null!;
        public int Insertname { get; set; }
        public DateTime Inserttime { get; set; }
        public int Updatename { get; set; }
        public DateTime Updatetime { get; set; }
        /// <summary>
        /// 5=BelumdicekOL
        /// </summary>
        public sbyte? Historynya { get; set; }
        public int Kodepelanggan { get; set; }
        public int Kodegudang { get; set; }
        public int Kodesales { get; set; }
        public sbyte Kodepenyiap { get; set; }
        public bool Dicetak { get; set; }
        public bool Lunas { get; set; }
        public DateTime Tglcetak { get; set; }
        public int Kodeexp { get; set; }
        public sbyte Kirimmelalui { get; set; }
        public int Jumlah { get; set; }
        public sbyte StokSales { get; set; }
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
        /// <summary>
        /// UNTUK UPDATE NMR HP
        /// </summary>
        public sbyte Sudahupdatephone { get; set; }
        public Mastergudang? Mastergudang { get; set; }
        public Masterpelanggan? Masterpelanggan { get; set; }
        public ICollection<Dorder> Dorder { get; set; }
        public Masteruser? MasteruserInsert { get; set; }
        public Masteruser? MasteruserUpdate { get; set; }
        public Sales? Sales { get; set; }
        public Penyiaporder? Penyiaporder { get; set; }
        public Masterpengeluaran? Ekspedisi { get; set; }
    }
}
