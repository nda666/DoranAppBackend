using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Tagihan
    {
        public int Kode { get; set; }
        public int Kodeh { get; set; }
        public DateTime TglAngsur { get; set; }
        public long Jumlah { get; set; }
        public bool InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        /// <summary>
        /// 3 = udaDiCek, 2 = udaDiSetor, 1 0 = belum
        /// </summary>
        public bool UdaDiSetor { get; set; }
        /// <summary>
        /// 0 = tunai, 1 = transfer
        /// </summary>
        public bool Transfer { get; set; }
        public bool Penagih { get; set; }
        public int KodeTotalSetoran { get; set; }
        public int Kodett { get; set; }
        public string Keterangan { get; set; } = null!;
        public int Kodecoa4 { get; set; }
        public int Kodehlunasinmassal { get; set; }
        /// <summary>
        /// Dihitung dalam detail transfer atau tidak
        /// </summary>
        public sbyte Dihitung { get; set; }
        /// <summary>
        /// Kode jenis bayar dari Market Place
        /// </summary>
        public int Kodetipeonline { get; set; }
        /// <summary>
        /// Keperluan Online : Sudah diperiksa valid atau belum
        /// </summary>
        public sbyte Periksa { get; set; }
        public sbyte Tessubsiditkpd { get; set; }
    }
}
