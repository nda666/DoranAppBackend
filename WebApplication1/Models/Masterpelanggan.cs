using System;
using System.Collections.Generic;

namespace DoranOfficeBackend.Models
{
    public partial class Masterpelanggan
    {
        public int Kode { get; set; }
        public string Nama { get; set; } = null!;
        public string Namaformal { get; set; } = null!;
        public string Lokasi { get; set; } = null!;
        public bool Aktif { get; set; }
        public int Kodelevel { get; set; }
        public sbyte InsertName { get; set; }
        public DateTime InsertTime { get; set; }
        public sbyte UpdateName { get; set; }
        public DateTime UpdateTime { get; set; }
        public sbyte KursKomisi { get; set; }
        public int BatasOmzet { get; set; }
        public string Panggilan { get; set; } = null!;
        public bool? TargetAdmin { get; set; }
        public DateTime TglLahir { get; set; }
        public string Email { get; set; } = null!;
        public string NamaPemilik { get; set; } = null!;
        public int Kota { get; set; }
        public sbyte Provinsi { get; set; }
        public string Tokoalamatlengkap { get; set; } = null!;
        public string Tokoalamatkirim { get; set; } = null!;
        public int Tokoexp { get; set; }
        public sbyte Kirimmelalui { get; set; }
        public string Tokotelp { get; set; } = null!;
        public string? Tokohp { get; set; }
        public string Tokopinbbm { get; set; } = null!;
        public bool Jenisusaha { get; set; }
        public DateTime Tglberdiri { get; set; }
        public bool Statustempatusaha { get; set; }
        public DateTime Sewa1 { get; set; }
        public DateTime Sewa2 { get; set; }
        public string? Pemilikalamat { get; set; }
        public string Pemiliktelp { get; set; } = null!;
        public string Pemilikhp { get; set; } = null!;
        public string Pemilikpinbbm { get; set; } = null!;
        public string Cpnama1 { get; set; } = null!;
        public string Cpemail1 { get; set; } = null!;
        public string Cphp1 { get; set; } = null!;
        public string Cpjabatan1 { get; set; } = null!;
        public string Cpnama2 { get; set; } = null!;
        public string Cpemail2 { get; set; } = null!;
        public string Cphp2 { get; set; } = null!;
        public string Cpjabatan2 { get; set; } = null!;
        public string Cpnama3 { get; set; } = null!;
        public string Cpemail3 { get; set; } = null!;
        public string? Cphp3 { get; set; }
        public string Cpjabatan3 { get; set; } = null!;
        public bool Tipetrans { get; set; }
        public bool Tipepembayaran { get; set; }
        public string Lamakredit { get; set; } = null!;
        public int Jumlahlimit { get; set; }
        public string Adminnama { get; set; } = null!;
        public string Adminhp { get; set; } = null!;
        public string Adminpinbbm { get; set; } = null!;
        public string Caranagih { get; set; } = null!;
        public bool Punyaform { get; set; }
        public bool Punyapinbbm { get; set; }
        public bool Showultah { get; set; }
        public sbyte Kodeareapengiriman { get; set; }
        public int Salespemilik { get; set; }
        public string Npwp { get; set; } = null!;
        public string Fototoko { get; set; } = null!;
        public string Fotoktp { get; set; } = null!;
        public string Fotoform { get; set; } = null!;
        public int Kodecoa4 { get; set; }
        /// <summary>
        /// 0=Masterpelanggan, 1=AKun Pelengkap buat jurnal
        /// </summary>
        public sbyte Tipeakun { get; set; }
        public sbyte Urutpelanggan { get; set; }
        /// <summary>
        /// 0=tidak,1=ppn
        /// </summary>
        public sbyte DefaultPpn { get; set; }
        public sbyte Kodeleveltokopedia { get; set; }
        public string Linktoko { get; set; } = null!;
        public int Kodegroup { get; set; }
        public float Potongan { get; set; }
        /// <summary>
        /// UNTUK KODE LEVEL HARGA ONLINE
        /// </summary>
        public int Kodelevelharga { get; set; }
        public sbyte KodelevelhargaJete { get; set; }

        public virtual LokasiKota? LokasiKota { get; set; }

        public virtual ICollection<Htrans>? Htrans { get; set; }

        public virtual ICollection<Horder>? Horder { get; set; }
    }
}
