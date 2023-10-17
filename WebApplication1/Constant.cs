namespace DoranOfficeBackend
{
    public static class Constants
    {
        public const int BESARAN_PPN = 11;
        public const double PEMBAGI_PPN10 = 1.1;
        public const double PEMBAGI_PPN11 = 1.11;

        public const string KODE_BRAND_JETE = "1";

        public const int PERKIRAAN_JUM_SALES = 200;
        public const int BATAS_SIMPAN_BULK_SQL = 10000;

        public const int OFFLINE_PORT = 0;
        public const string OFFLINE_USER = "doran1nasional";
        public const string OFFLINE_PASS = "nOmOr1NaSiOnaL";
        public const string OFFLINE_DB = "data";

        public const int ONLINE_PORT = 0;
        public const string ONLINE_USER = "doran1nasional";
        public const string ONLINE_PASS = "nOmOr1NaSiOnaL";
        public const string ONLINE_DB = "data";

        public const int JUM_FOTO_RANDOM = 28;

        public const int BATAS_BAWAH_TAHUN = 2019;
        public const int BATAS_BAWAH_TAHUN2 = 2014;
        public const int BATAS_ATAS_TAHUN = 2024;
        public const string TAHUN_MINIMAL_TRANSAKSI = "1/1/2022";
        public const string TAHUN_MAKSIMAL_TRANSAKSI = "12/31/2023";
        public const string TAHUN_MINIMAL_TRANSAKSI_2010 = "1/1/2010";
        public const string TAHUN_AWAL_BUKU_BESAR = "11/1/2018";

        public const string TAHUN_AWAL_HITUNG_STOK_PIUTANG = "6/1/2011";

        public const int JUM_ARRAY_DETAIL_TT = 6000;
        public const int JUMALATSIDIKJARI = 5;
        public const int JUM_ARRAY_NORMALKAN_TOKOPEDIA = 500;

        //public static readonly AlatSidikJari[] AlatSidikJariArray = new AlatSidikJari[]
        //{
        //new AlatSidikJari { SerialNumber = "C800V002496", VerificationCode = "7777B6CFF75B3D6", ActivationCode = "6MW38C2EACBEE069E1F5BRWS" },
        //new AlatSidikJari { SerialNumber = "C800V002499", VerificationCode = "68CD7AA6758CBA7", ActivationCode = "VNJ51A02A16541FAEA95F5AE" },
        //new AlatSidikJari { SerialNumber = "C800V002500", VerificationCode = "962382538504499", ActivationCode = "AEHD5110F88CF4E6141EDTLV" },
        //new AlatSidikJari { SerialNumber = "NZ20J02221", VerificationCode = "A25F430B199D7EF", ActivationCode = "HPN6F56704517269DEFF4F66" },
        //new AlatSidikJari { SerialNumber = "PY20J00445", VerificationCode = "15DEC06411E8847", ActivationCode = "4YM48474E1716F98A6CF8DB7" }
        //};

        public const int KODE_TOKO_TOKOPEDIA = 124;
        public const int KODE_TOKO_SHOPEE = 130;

        public const double BONUS_PM_SANDISK = 0.03;

        public const int KURS_UANG_CINA = 2275;

        public const string KODE_PROV_ONLINE = "23";
        public const string KODE_PROV_RETAIL = "25";

        public const int KODESUPIR1 = 34;
        public const int KODESUPIR2 = 69;
        public const int KODESUPIR3 = 187;

        public const int JUMARRAYSALES = 60;
        public const int JUM_DATA_LAPORAN = 200;

        public const int JUMARRAYHINPUTHMASSAL = 120;
        public const int JUMARRAYDINPUTDMASSAL = 30;
        public const int JUMARRAYHINPUTORDERHMASSAL = 120;
        public const int JUMARRAYDINPUTORDERHMASSAL = 30;
        public const int JUMARRAYHINPUTABSENSIHMASSAL = 500;

        public const int PERSEN_KOMISI = 2;
        public const int PERSEN_PROFIT = 15;
        public const int JUMLAHMAXBUKAPROGRAM = 4;

        public const string KODE_PELANGGAN_SETORANTUNAI = "1749";

        public const int KODE_PENGELUARAN_PERSEDIAAN = 268;
        public const int KODE_PENGELUARAN_PENGGAJIAN = 32;
        public const int KODE_PENGELUARAN_AYATSILANGKAS = 269;
        public const int KODE_PENGELUARAN_AYATSILANGBANK = 283;
        public const int KODE_PENGELUARAN_HUTANGLAIN = 301;

        public const int KODE_COA_KAS = 100001;
        public const int KODE_COA_AYATSILANG = 100002;
        public const int KODE_COA_BANKUTAMA = 110002;
        public const int KODE_COA_PIUTANGUSAHA = 120001;
        public const int KODE_COA_HUTANGUSAHA = 300001;
        public const int KODE_COA_PENJUALAN = 500001;
        public const int KODE_COA_PPN_KELUAR = 320004;
        public const int KODE_COA_PACKING_PLASTIK = 600011;
        public const int KODE_COA_DISKON_PENJUALAN = 510002;
        public const int KODE_COA_STOK = 140001;
        public const int KODE_COA_PPN_MASUK = 130004;
        public const int KODE_COA_UANG_MUKA_PEMBELIAN = 160001;
        public const int KODE_COA_HPP = 590001;
        public const int KODE_COA_KOMISISALES = 600001;
        public const int KODE_COA_PIUTANG_KARYAWAN = 125002;
        public const int KODE_COA_TITIPAN_UANGSALES = 350003;
        public const int KODE_COA_PENDAPATAN_LAIN = 800005;
        public const int KODE_COA_BIAYA_GAJI_STAFF = 700001;
        public const int KODE_COA_BAGI_GRATIS = 510005;
        public const int KODE_COA_RETUR_PENJUALAN = 510001;
        public const int KODE_COA_BIAYA_BARANG_RUSAK = 600023;
        public const int KODE_COA_ONGKIR_MASUK = 550005;
        public const int KODE_COA_ONGKIR_KELUAR = 600003;
        public const int KODE_COA_UM_CINA = 160003;
        public const int KODE_COA_HUTANGGAJI = 310001;

        public const string KODE_COA_SUBSIDI_TOKOPEDIA = "800014";
        //public const string KODE_COA_SUBSIDI_TOKOPEDIA = "191001";
        public const string KODE_COA_TITIPAN_UANG_TOKOPEDIA = "350004";
        public const string KODE_COA_FEE_TOKOPEDIA_OfficialStore = "800007";
        public const string KODE_COA_FEE_TOKOPEDIA_PM = "800020";
        public const string KODE_COA_BIAYA_LAIN_TOKOPEDIA = "800015";

        public const string KODE_COA_FEE_SHOPEE = "800009";
        public const string KODE_COA_TITIPAN_UANG_TOKO = "350001";

        public const string KODEH_AYATSILANG = "133405";
        public const string KODEH_HUTANGLAINNYA = "92004";
        public const string KODEH_TITIPAN_UANG_TOKOPEDIA = "1150256";
        public const string KODEH_PEMBULATAN_TOKOPEDIA = "1336669";
        public const string KODEH_TITIPAN_UANG_TOKO = "133404";

        public const string KODE_PENGELUARAN_TITIPAN_UANG_TOKO = "513";

        public const int DENDA_TELAT_ANAKGUDANG = 10000;
        public const int DENDA_TELAT_PENGIRIMAN = 15000;
        public const int DENDA_TELAT_SALES = 20000;
        public const int DENDA_TELAT_KEPALA = 25000;
        public const int DENDA_TELAT_SALES_BRIEFING = 50000;
        public const int DENDA_TIDAK_LAPORAN = 50000;

        public const string KODE_JHONNY = "88";
        public const string KODE_SITI = "9";
        public const string KODE_FIRDA = "96";
        public const string KODE_YANTI = "4";
        public const string KODE_ALFI = "70";
        public const string KODE_DITA = "63";
        public const string KODE_KEPALA_DC = "193";
        public const string KODE_IRMA = "170";

        public const string KODEPELANGGAN_BARANGKURANG = "257";
        public const int LAMA_UDARA = 6;
        public const int LAMA_LAUT = 25;
        public const string KODE_PENYESUAIAN = "70";
        public const string GUDANG_ATAS = "1";
        public const string GUDANG_LT3 = "134";
        public const string GUDANG_JAKARTA = "122";
        public const string GUDANG_SEMARANG = "219";
        public const string GUDANG_BALI = "273";
        public const string GUDANG_BANDUNG = "281";
        public const string GUDANG_DORANCARE = "55";
        public const string GUDANG_ONLINE = "174";
        public const int WARNA_LUNAS = 0x00984e00;
        public const string TAMBAH = "Tambah";
        public const string BROWSE = "Browse";
        public const string UBAH = "Ubah";
        public const string HAPUS = "Hapus";
        public const string DECIMAL_SEPARATOR = ".";
        public const string UANG_SEPARATOR = ",";
        public const string DEFAULT_HISTORY_TRANSAKSI = "4";
        public const int DEFAULT_HISTORY_TRANSAKSI_INT = 4;
        public const string DEFAULT_HISTORY_ORDEROL_MASSAL = "5";

        public const string NAMA_PENGIRIM = "PT. DORAN SUKSES INDONESIA";
        public const string EMAIL_PENGIRIM_PROG = "doranserver2@gmail.com";
        public const string PASS_EMAIL_PENGIRIM_PROG = "yfyqxblncpegqckv";
        //public const string PASS_EMAIL_PENGIRIM_PROG = "akumakannasi";

        public const string EMAIL_JHONNY = "jhonnythio2@gmail.com,jhonnythio@yahoo.com";
        public const string EMAIL_INPUTORDER = "putri.iwana93@gmail.com";
        public const string EMAIL_PEMBELIAN = "pembeliandoran@gmail.com";
        public const string EMAIL_AUDITOR = "sitiptdoran@gmail.com";
        public const string EMAIL_DORANCARE = "dorancare2020@gmail.com";
        public const string EMAIL_KEPALAFINANCE = "yantidoran@gmail.com";
        public const string EMAIL_KEPALAGUDANG = "alfimalis31@gmail.com";
        public const string EMAIL_ORDERCINA = "doranpembeliancina@gmail.com";
    }

}
