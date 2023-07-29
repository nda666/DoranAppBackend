using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Dbukubesar
    {
        public int Kodetgl { get; set; }
        public string Kodestring { get; set; } = null!;
        public DateTime Tanggal { get; set; }
        public int Koded { get; set; }
        public int Coa4debit { get; set; }
        public int Coa4kredit { get; set; }
        public string Keterangan { get; set; } = null!;
        public long Jumlah { get; set; }
        public int Urut { get; set; }
        /// <summary>
        /// 0=normal,1=setoran,2=jurnalmemo,3=jurnalmemokomisi,4=jurnalmemoinsertbiasa,5=jpenjualan,6=jurnalmemopembelianCOD,7=jpembelian,8=hpp,9=jmemogaji,10=LapRLSaldoLaba
        /// </summary>
        public sbyte Tipe { get; set; }
        public sbyte Posted { get; set; }
        public int Insertname { get; set; }
        public DateTime Inserttime { get; set; }
    }
}
