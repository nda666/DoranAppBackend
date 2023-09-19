using DoranOfficeBackend.Dtos.Masteruser;
using DoranOfficeBackend.Models;
using _Masterbarang = DoranOfficeBackend.Models.Masterbarang;
namespace DoranOfficeBackend.Dtos.Order
{
    public class HorderResult
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
        public bool? Historynya { get; set; }
        public int Kodepelanggan { get; set; }
        public int Kodesales { get; set; }
        public int Kodepenyiap { get; set; }
        public bool Dicetak { get; set; }
        public bool Lunas { get; set; }
        public DateTime Tglcetak { get; set; }
        public int Kodeexp { get; set; }
        public bool Kirimmelalui { get; set; }
        public int Jumlah { get; set; }
        public sbyte StokSales { get; set; }
        public int Ppn { get; set; }
        public bool? Tipetempo { get; set; }
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
        public ICollection<DorderResult> Dorder { get; set; }
        public virtual MasteruserOptionDto? Penyiap { get; set; }
        public virtual MasteruserOptionDto? MasteruserInsert { get; set; }
        public virtual MasteruserOptionDto? MasteruserUpdate { get; set; }
        public virtual CommonResultDto? Masterpelanggan { get; set; }
        public virtual CommonResultDto? Sales { get; set; }
        public virtual CommonResultDto? Ekspedisi { get; set; }
    }

    public class DorderResult
    {
        public int Id { get; set; }
        public int Kodeh { get; set; }
        public short Koded { get; set; }
        public short Kodebarang { get; set; }
        public short Jumlah { get; set; }
        public long Harga { get; set; }
        public string Keterangan { get; set; } = null!;
        public virtual MasterbarangOption? Masterbarang { get; set; }
    }

    public class HorderResultDto : PaginationResultDto
    {
        public ICollection<HorderResult> Data {get; set;}
    }


}
