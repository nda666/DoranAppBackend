using DoranOfficeBackend.Dtos;
using DoranOfficeBackend.Dtos.Mastergudang;
using DoranOfficeBackend.Dtos.Masterpelanggan;
using DoranOfficeBackend.Dtos.Masteruser;
using DoranOfficeBackend.Dtos.Order;
namespace DoranOfficeBackend.PermintaanSales.Order
{
    public class PermintaanSalesResultDto : PaginationResultDto
    {
        public ICollection<PermintaanSalesResult> Data { get; set; }
    }

    public class PermintaanSalesResult
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
        public int Kodepenyiap { get; set; }
        public bool Dicetak { get; set; }
        public bool Lunas { get; set; }
        public DateTime Tglcetak { get; set; }
        public int Jumlah { get; set; }
        public sbyte StokSales { get; set; }
        public string Infopenting { get; set; } = null!;
        /// <summary>
        /// UNTUK UPDATE NMR HP
        /// </summary>
        public ICollection<DorderResult> Dorder { get; set; }
        public virtual CommonResultDto? Penyiaporder { get; set; }
        public virtual MastergudangOptionDto? Mastergudang { get; set; }
        public virtual MastergudangOptionDto? MastergudangTujuan { get; set; }
        public virtual MasteruserOptionDto? MasteruserInsert { get; set; }
        public virtual MasteruserOptionDto? MasteruserUpdate { get; set; } = null;
        public virtual CommonResultDto? Sales { get; set; }
    }


}
