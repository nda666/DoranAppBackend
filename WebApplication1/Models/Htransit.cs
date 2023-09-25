using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Htransit
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
        public virtual ICollection<Dtransit> Dtransit { get; set; }
        public Penyiaporder? Penyiaporder { get; set; }
        public Masteruser? MasteruserInsert { get; set; }
        public Masteruser? MasteruserUpdate { get; set; }
        public Mastergudang? Mastergudang { get; set; }
        public Mastergudang? MastergudangTujuan { get; set; }
    }
}
