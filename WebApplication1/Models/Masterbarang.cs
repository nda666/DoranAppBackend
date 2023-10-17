using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Masterbarang
    {
        public short BrgKode { get; set; }
        public string BrgNama { get; set; } = null!;
        public bool BrgAktif { get; set; }
        public bool InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public bool UpdateName { get; set; }
        public DateTime UpdateTime { get; set; }
        public sbyte BrgHabis { get; set; }
        public int Modal { get; set; }
        public int Hargatoko { get; set; }
        public int HargaSrp { get; set; }
        public int MinStokHabis { get; set; }
        public int Maksstok { get; set; }
        public sbyte PoinToko { get; set; }
        public int Supplierkode { get; set; }
        public sbyte Tipebarang { get; set; }
        public int Hargaol { get; set; }
        public string Namaol { get; set; } = null!;
        public bool Brgspesial { get; set; }
        public sbyte Komisi { get; set; }
        public int KategoriBrg { get; set; }
        public sbyte Favorit { get; set; }
        public sbyte Groupbaranghabis { get; set; }
        public sbyte Diskontinu { get; set; }
        /// <summary>
        /// 0=tidakada,1=disiapkan,2=dikirim
        /// </summary>
        public sbyte StatusKirimanCina { get; set; }
        public string KetKirimanCina { get; set; } = null!;
        public sbyte Simpanmemostok { get; set; }
        public sbyte SetHarga { get; set; }
        /// <summary>
        /// Keperluan Apps PastiSukses untuk cek apakah brg ini perlu diorder toko atau belum. 1=Perlu. 0=TidakPerlu.
        /// </summary>
        public sbyte Kpikelengkapantoko { get; set; }
        public bool JurnalBiaya { get; set; }

        public virtual ICollection<Dtrans> Dtrans { get; set; }
        public virtual ICollection<Dorder> Dorder { get; set; }
        public virtual ICollection<Dtransit> Dtransit { get; set; }

        public virtual Dkategoribarang? Dkategoribarang { get; set; }

        public Mastertipebarang? Mastertipebarang { get; set; }
    }
}
