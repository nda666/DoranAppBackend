using DoranOfficeBackend.Dtos.Masterbarang;
using DoranOfficeBackend.Dtos.Masterpelanggan;
using DoranOfficeBackend.Dtos.Masteruser;
using DoranOfficeBackend.Models;
using _Masterbarang = DoranOfficeBackend.Models.Masterbarang;
namespace DoranOfficeBackend.Dtos.Transit
{

    public class HtransitResultDto : PaginationResultDto
    {
        public ICollection<HtransitResult> Data { get; set; }
    }

    public class HtransitResult
    {
        public int KodeT { get; set; }
        public DateTime? TglTrans { get; set; }
        public int? KodeGudangTujuan { get; set; }
        public string? Keterangan { get; set; }
        public int? InsertName { get; set; }
        public DateTime? InsertTime { get; set; }
        public int? UpdateName { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string? HistoryNya { get; set; }
        public int? Kodegudang { get; set; }
        public sbyte? Kodepenyiap { get; set; }
        /// <summary>
        /// 0=Belum,1=Sudah
        /// </summary>
        public sbyte? Export { get; set; }
        public int? Kodeonline { get; set; }

        public virtual ICollection<DtransitResult> Dtransit { get; set; }
        public CommonResultDto? Penyiaporder { get; set; }
        public MasteruserOptionDto? MasteruserInsert { get; set; }
        public MasteruserOptionDto? MasteruserUpdate { get; set; }
        public CommonResultDto? Mastergudang { get; set; }
        public CommonResultDto? MastergudangTujuan { get; set; }
    }

    public class DtransitResult
    {
        public int Id { get; set; }
        public int Kodet { get; set; }
        public short Koded { get; set; }
        public short Kodebarang { get; set; }
        public short Jumlah { get; set; }
        public bool Sudahdicek { get; set; }
        public string Namapenerima { get; set; } = null!;
        public string NmrSn { get; set; } = null!;
        public virtual MasterbarangOptionWithTipeDto? Masterbarang { get; set; }
    }

}
