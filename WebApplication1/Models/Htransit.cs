using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Htransit
    {
        public int KodeT { get; set; }
        public DateTime? TglTrans { get; set; }
        public short? KodeGudangTujuan { get; set; }
        public string? Keterangan { get; set; }
        public sbyte? InsertName { get; set; }
        public DateTime? InsertTime { get; set; }
        public sbyte? UpdateName { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string? HistoryNya { get; set; }
        public int? Kodegudang { get; set; }
        public sbyte? Kodepenyiap { get; set; }
        /// <summary>
        /// 0=Belum,1=Sudah
        /// </summary>
        public sbyte? Export { get; set; }
        public int? Kodeonline { get; set; }
    }
}
