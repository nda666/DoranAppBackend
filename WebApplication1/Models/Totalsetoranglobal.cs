using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Totalsetoranglobal
    {
        public int Kode { get; set; }
        public DateTime Tanggal { get; set; }
        public int Jumlah { get; set; }
        public int Jumlahakhir { get; set; }
        public bool Setor { get; set; }
        public sbyte InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public sbyte Penerima { get; set; }
        public DateTime TglTerima { get; set; }
        public DateTime Tglsetor { get; set; }
        public int Kodett { get; set; }
    }
}
