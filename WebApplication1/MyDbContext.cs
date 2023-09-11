using Microsoft.EntityFrameworkCore;
using DoranOfficeBackend.Models;
using DoranOfficeBackend.Interfaces;
using DoranOfficeBackend.Interceptors;
using System.Linq.Expressions;

namespace DoranOfficeBackend
{
    public partial class MyDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        private static readonly TimestampInterceptor timestampInterceptor
        = new TimestampInterceptor();

        private static readonly SoftDeleteInterceptor softDeleteInterceptor
       = new SoftDeleteInterceptor();

     
        public MyDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }


        public MyDbContext(DbContextOptions options, bool IsMigration)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        {
            if (!optionsBuilder.IsConfigured) { 
                var mysqlConn = this._configuration.GetConnectionString("DefaultConnection");
                optionsBuilder
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))   
                    .UseMySQL(mysqlConn, opts => opts.CommandTimeout(180));
        }
            optionsBuilder
                .AddInterceptors(
                timestampInterceptor,
                softDeleteInterceptor
                );
        }

        public virtual DbSet<Absenspg> Absenspgs { get; set; } = null!;
        public virtual DbSet<Adaaktifita> Adaaktifitas { get; set; } = null!;
        public virtual DbSet<Alamattambahanpelanggan> Alamattambahanpelanggans { get; set; } = null!;
        public virtual DbSet<Barangmasuk> Barangmasuks { get; set; } = null!;
        public virtual DbSet<Barangsn> Barangsns { get; set; } = null!;
        public virtual DbSet<Barangstokterkait> Barangstokterkaits { get; set; } = null!;
        public virtual DbSet<Bathippo> Bathippos { get; set; } = null!;
        public virtual DbSet<Cekpotonganonline> Cekpotonganonlines { get; set; } = null!;
        public virtual DbSet<Cekstok> Cekstoks { get; set; } = null!;
        public virtual DbSet<Cekstok2> Cekstok2s { get; set; } = null!;
        public virtual DbSet<Coa1> Coa1s { get; set; } = null!;
        public virtual DbSet<Coa2> Coa2s { get; set; } = null!;
        public virtual DbSet<Coa3> Coa3s { get; set; } = null!;
        public virtual DbSet<Coa4> Coa4s { get; set; } = null!;
        public virtual DbSet<Daftarbaranghabi> Daftarbaranghabis { get; set; } = null!;
        public virtual DbSet<Daftarbc> Daftarbcs { get; set; } = null!;
        public virtual DbSet<Daftarkomplain> Daftarkomplains { get; set; } = null!;
        public virtual DbSet<Daftarpujian> Daftarpujians { get; set; } = null!;
        public virtual DbSet<Datagrupnilai> Datagrupnilais { get; set; } = null!;
        public virtual DbSet<Datanilaipegawai> Datanilaipegawais { get; set; } = null!;
        public virtual DbSet<Dbawatagihan> Dbawatagihans { get; set; } = null!;
        public virtual DbSet<Dbelicina> Dbelicinas { get; set; } = null!;
        public virtual DbSet<Dbonusjete> Dbonusjetes { get; set; } = null!;
        public virtual DbSet<Dbrgmasukretur> Dbrgmasukreturs { get; set; } = null!;
        public virtual DbSet<Dbukubesar> Dbukubesars { get; set; } = null!;
        public virtual DbSet<Dcekharga> Dcekhargas { get; set; } = null!;
        public virtual DbSet<Dgajipegawai> Dgajipegawais { get; set; } = null!;
        public virtual DbSet<Dgrouppelanggan> Dgrouppelanggans { get; set; } = null!;
        public virtual DbSet<Dkategoribarang> Dkategoribarangs { get; set; } = null!;
        public virtual DbSet<Dkirimretur> Dkirimreturs { get; set; } = null!;
        public virtual DbSet<Dkomisidetail> Dkomisidetails { get; set; } = null!;
        public virtual DbSet<Dkomisiomzet> Dkomisiomzets { get; set; } = null!;
        public virtual DbSet<Dkomisitargetomzet> Dkomisitargetomzets { get; set; } = null!;
        public virtual DbSet<Dlevelgaji> Dlevelgajis { get; set; } = null!;
        public virtual DbSet<Dnilaipegawai> Dnilaipegawais { get; set; } = null!;
        public virtual DbSet<Dorder> Dorders { get; set; } = null!;
        public virtual DbSet<Dordercina> Dordercinas { get; set; } = null!;
        public virtual DbSet<Dpenggantikirimretur> Dpenggantikirimreturs { get; set; } = null!;
        public virtual DbSet<Dpenyesuaian> Dpenyesuaians { get; set; } = null!;
        public virtual DbSet<Dpoinaward> Dpoinawards { get; set; } = null!;
        public virtual DbSet<Dpphtambahan> Dpphtambahans { get; set; } = null!;
        public virtual DbSet<Dproduktahunan> Dproduktahunans { get; set; } = null!;
        public virtual DbSet<Dpromo> Dpromos { get; set; } = null!;
        public virtual DbSet<Dpromopoin> Dpromopoins { get; set; } = null!;
        public virtual DbSet<Drefund> Drefunds { get; set; } = null!;
        public virtual DbSet<Dresipengiriman> Dresipengirimen { get; set; } = null!;
        public virtual DbSet<Dresipengirimankepelanggan> Dresipengirimankepelanggans { get; set; } = null!;
        public virtual DbSet<Dtargetomzettokopc> Dtargetomzettokopcs { get; set; } = null!;
        public virtual DbSet<Dtrans> Dtrans { get; set; } = null!;
        public virtual DbSet<Dtransit> Dtransits { get; set; } = null!;
        public virtual DbSet<Dupdate> Dupdates { get; set; } = null!;
        public virtual DbSet<Emailpromohippo> Emailpromohippos { get; set; } = null!;
        public virtual DbSet<Glassperwilayah> Glassperwilayahs { get; set; } = null!;
        public virtual DbSet<Groupbaranghabi> Groupbaranghabis { get; set; } = null!;
        public virtual DbSet<Hargasandisk> Hargasandisks { get; set; } = null!;
        public virtual DbSet<Hbawatagihan> Hbawatagihans { get; set; } = null!;
        public virtual DbSet<Hbayarpotongan> Hbayarpotongans { get; set; } = null!;
        public virtual DbSet<Hbayarsupplier> Hbayarsuppliers { get; set; } = null!;
        public virtual DbSet<Hbeli> Hbelis { get; set; } = null!;
        public virtual DbSet<Hbelicina> Hbelicinas { get; set; } = null!;
        public virtual DbSet<Hbonusjete> Hbonusjetes { get; set; } = null!;
        public virtual DbSet<Hbrgmasukretur> Hbrgmasukreturs { get; set; } = null!;
        public virtual DbSet<Hcekharga> Hcekhargas { get; set; } = null!;
        public virtual DbSet<Hdetailbayar> Hdetailbayars { get; set; } = null!;
        public virtual DbSet<Hgajipegawai> Hgajipegawais { get; set; } = null!;
        public virtual DbSet<Hgrouppelanggan> Hgrouppelanggans { get; set; } = null!;
        public virtual DbSet<Historyka> Historykas { get; set; } = null!;
        public virtual DbSet<Historylimit> Historylimits { get; set; } = null!;
        public virtual DbSet<Hjamkerja> Hjamkerjas { get; set; } = null!;
        public virtual DbSet<Hkategoribarang> Hkategoribarangs { get; set; } = null!;
        public virtual DbSet<Hkelompokbarang> Hkelompokbarang { get; set; } = null!;
        public virtual DbSet<Hkirimretur> Hkirimreturs { get; set; } = null!;
        public virtual DbSet<Hkomisi> Hkomisis { get; set; } = null!;
        public virtual DbSet<Hlevelgaji> Hlevelgajis { get; set; } = null!;
        public virtual DbSet<Hlunasinmassal> Hlunasinmassals { get; set; } = null!;
        public virtual DbSet<Hnilaipegawai> Hnilaipegawais { get; set; } = null!;
        public virtual DbSet<Hongkircina> Hongkircinas { get; set; } = null!;
        public virtual DbSet<Horder> Horders { get; set; } = null!;
        public virtual DbSet<Hordercina> Hordercinas { get; set; } = null!;
        public virtual DbSet<Hpakaiinventari> Hpakaiinventaris { get; set; } = null!;
        public virtual DbSet<Hpenggantikirimretur> Hpenggantikirimreturs { get; set; } = null!;
        public virtual DbSet<Hpengiriman> Hpengirimen { get; set; } = null!;
        public virtual DbSet<Hpenyesuaian> Hpenyesuaians { get; set; } = null!;
        public virtual DbSet<Hpoinaward> Hpoinawards { get; set; } = null!;
        public virtual DbSet<Hppntambahan> Hppntambahans { get; set; } = null!;
        public virtual DbSet<Hproduktahunan> Hproduktahunans { get; set; } = null!;
        public virtual DbSet<Hpromo> Hpromos { get; set; } = null!;
        public virtual DbSet<Hrefund> Hrefunds { get; set; } = null!;
        public virtual DbSet<Hsidikjari> Hsidikjaris { get; set; } = null!;
        public virtual DbSet<Htrans> Htrans { get; set; } = null!;
        public virtual DbSet<Htransit> Htransits { get; set; } = null!;
        public virtual DbSet<Htuga> Htugas { get; set; } = null!;
        public virtual DbSet<Hupdate> Hupdates { get; set; } = null!;
        public virtual DbSet<Hwunderlist> Hwunderlists { get; set; } = null!;
        public virtual DbSet<Idolshop> Idolshops { get; set; } = null!;
        public virtual DbSet<Jadwalluarkotum> Jadwalluarkota { get; set; } = null!;
        public virtual DbSet<Jenisidolshop> Jenisidolshops { get; set; } = null!;
        public virtual DbSet<JobsFailed> JobsFaileds { get; set; } = null!;
        public virtual DbSet<JobsRunning> JobsRunnings { get; set; } = null!;
        public virtual DbSet<Kaizen> Kaizens { get; set; } = null!;
        public virtual DbSet<Komponenprestasi> Komponenprestasis { get; set; } = null!;
        public virtual DbSet<Laporanakuntansi> Laporanakuntansis { get; set; } = null!;
        public virtual DbSet<Laporanharian> Laporanharians { get; set; } = null!;
        public virtual DbSet<LogUpdatePhone> LogUpdatePhones { get; set; } = null!;
        public virtual DbSet<Logfile> Logfiles { get; set; } = null!;
        public virtual DbSet<Logfileserver> Logfileservers { get; set; } = null!;
        public virtual DbSet<LokasiKota> LokasiKota { get; set; } = null!;
        public virtual DbSet<LokasiProvinsi> LokasiProvinsi { get; set; } = null!;
        public virtual DbSet<Manageriallaporan> Manageriallaporans { get; set; } = null!;
        public virtual DbSet<MasterPelangganGabungan> MasterPelangganGabungans { get; set; } = null!;
        public virtual DbSet<Masteragama> Masteragamas { get; set; } = null!;
        public virtual DbSet<Masterbank> Masterbanks { get; set; } = null!;
        public virtual DbSet<Masterbarang> Masterbarang { get; set; } = null!;
        public virtual DbSet<Mastercatatan> Mastercatatans { get; set; } = null!;
        public virtual DbSet<Masterchannelsales> Masterchannelsales { get; set; } = null!;
        public virtual DbSet<Mastercicilan> Mastercicilans { get; set; } = null!;
        public virtual DbSet<Masterdivisi> Masterdivisi { get; set; } = null!;
        public virtual DbSet<Mastergrupnilai> Mastergrupnilais { get; set; } = null!;
        public virtual DbSet<Mastergudang> Mastergudang { get; set; } = null!;
        public virtual DbSet<Masterharilibur> Masterhariliburs { get; set; } = null!;
        public virtual DbSet<Masterinventari> Masterinventaris { get; set; } = null!;
        public virtual DbSet<Masterjabatan> Masterjabatan { get; set; } = null!;
        public virtual DbSet<Masterjenisinventari> Masterjenisinventaris { get; set; } = null!;
        public virtual DbSet<Masterlevelpelanggan> Masterlevelpelanggans { get; set; } = null!;
        public virtual DbSet<Masterleveltokopedium> Masterleveltokopedia { get; set; } = null!;
        public virtual DbSet<Masternilai> Masternilais { get; set; } = null!;
        public virtual DbSet<Masterpegawai> Masterpegawais { get; set; } = null!;
        public virtual DbSet<Masterpelanggan> Masterpelanggan { get; set; } = null!;
        public virtual DbSet<Masterpemasukan> Masterpemasukans { get; set; } = null!;
        public virtual DbSet<Masterpengeluaran> Masterpengeluaran { get; set; } = null!;
        public virtual DbSet<Masterpoinaward> Masterpoinawards { get; set; } = null!;
        public virtual DbSet<Mastersupplier> Mastersuppliers { get; set; } = null!;
        public virtual DbSet<Mastersuppliercina> Mastersuppliercinas { get; set; } = null!;
        public virtual DbSet<Mastertarget> Mastertargets { get; set; } = null!;
        public virtual DbSet<Mastertargettahunan> Mastertargettahunans { get; set; } = null!;
        public virtual DbSet<Mastertimsales> Mastertimsales { get; set; } = null!;
        public virtual DbSet<Mastertipebarang> Mastertipebarangs { get; set; } = null!;
        public virtual DbSet<Mastertipeinventari> Mastertipeinventaris { get; set; } = null!;
        public virtual DbSet<Mastertipetuga> Mastertipetugas { get; set; } = null!;
        public virtual DbSet<Mastertuga> Mastertugas { get; set; } = null!;
        public virtual DbSet<Masteruser> Masterusers { get; set; } = null!;
        public virtual DbSet<Masteruserretur> Masteruserreturs { get; set; } = null!;
        public virtual DbSet<Memostok> Memostoks { get; set; } = null!;
        public virtual DbSet<Penandajurnal> Penandajurnals { get; set; } = null!;
        public virtual DbSet<Penyiaporder> Penyiaporders { get; set; } = null!;
        public virtual DbSet<Potonganbarangkurang> Potonganbarangkurangs { get; set; } = null!;
        public virtual DbSet<Profileperush> Profileperushes { get; set; } = null!;
        public virtual DbSet<Rumushargaonline> Rumushargaonlines { get; set; } = null!;
        public virtual DbSet<Sales> Sales { get; set; } = null!;
        public virtual DbSet<Sethargajual> Sethargajual { get; set; } = null!;
        public virtual DbSet<Sethargalevel> Sethargalevel { get; set; } = null!;
        public virtual DbSet<Sethargatoko> Sethargatokos { get; set; } = null!;
        public virtual DbSet<Simpanbonusjete> Simpanbonusjetes { get; set; } = null!;
        public virtual DbSet<Simpandendalainnya> Simpandendalainnyas { get; set; } = null!;
        public virtual DbSet<Simpandendum> Simpandenda { get; set; } = null!;
        public virtual DbSet<Syaratbonusjete> Syaratbonusjetes { get; set; } = null!;
        public virtual DbSet<Syaratkomisi> Syaratkomisis { get; set; } = null!;
        public virtual DbSet<Syarattargetarea> Syarattargetareas { get; set; } = null!;
        public virtual DbSet<Tagihan> Tagihans { get; set; } = null!;
        public virtual DbSet<Tagihansupplier> Tagihansuppliers { get; set; } = null!;
        public virtual DbSet<Tagihanvirtual> Tagihanvirtuals { get; set; } = null!;
        public virtual DbSet<Targetomzettoko> Targetomzettokos { get; set; } = null!;
        public virtual DbSet<Targetomzettokojete> Targetomzettokojetes { get; set; } = null!;
        public virtual DbSet<Targetomzettokopc> Targetomzettokopcs { get; set; } = null!;
        public virtual DbSet<Totalsetoran> Totalsetorans { get; set; } = null!;
        public virtual DbSet<Totalsetoranglobal> Totalsetoranglobals { get; set; } = null!;
        public virtual DbSet<Transaksipemasukan> Transaksipemasukans { get; set; } = null!;
        public virtual DbSet<Transaksipengeluaran> Transaksipengeluarans { get; set; } = null!;
        public virtual DbSet<Ttkeluar> Ttkeluars { get; set; } = null!;
        public virtual DbSet<Ttmasuk> Ttmasuks { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Absenspg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("absenspg");

                entity.Property(e => e.Absen)
                    .HasColumnType("int(11)")
                    .HasColumnName("absen");

                entity.Property(e => e.Bulan)
                    .HasColumnType("int(11)")
                    .HasColumnName("bulan");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Jumtelat)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumtelat");

                entity.Property(e => e.KodePegawai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodePegawai");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Adaaktifita>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("adaaktifitas");

                entity.Property(e => e.Ada)
                    .HasMaxLength(1)
                    .HasColumnName("ada")
                    .HasDefaultValueSql("'''0'''")
                    .IsFixedLength();

                entity.Property(e => e.Adaorderan).HasColumnName("adaorderan");
            });

            modelBuilder.Entity<Alamattambahanpelanggan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("alamattambahanpelanggan");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(250)
                    .HasColumnName("alamat")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kirimmelalui)
                    .HasColumnType("int(11)")
                    .HasColumnName("kirimmelalui");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Kodepelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepelanggan");

                entity.Property(e => e.Lokasi)
                    .HasColumnType("int(11)")
                    .HasColumnName("lokasi");

                entity.Property(e => e.Tokoexp)
                    .HasColumnType("int(11)")
                    .HasColumnName("tokoexp");
            });

            modelBuilder.Entity<Barangmasuk>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("barangmasuk");

                entity.HasComment("Buat Detail Barang Masuk");

                entity.Property(e => e.Harga)
                    .HasColumnType("int(11)")
                    .HasColumnName("harga");

                entity.Property(e => e.HistoryNya)
                    .HasMaxLength(1)
                    .HasColumnName("historyNya")
                    .HasDefaultValueSql("'''4'''");

                entity.Property(e => e.InsertName).HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.JumSn)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumSN");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(150)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.KodeBarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeBarang");

                entity.Property(e => e.KodeSupplier)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kodeSupplier");

                entity.Property(e => e.Kodegudang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodegudang")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.TglMasuk)
                    .HasColumnType("date")
                    .HasColumnName("tglMasuk")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.UpdateName).HasColumnName("updateName");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Barangsn>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("barangsn");

                entity.Property(e => e.Insertnamebeli)
                    .HasColumnType("int(11)")
                    .HasColumnName("insertnamebeli");

                entity.Property(e => e.Insertnamejual)
                    .HasColumnType("int(11)")
                    .HasColumnName("insertnamejual");

                entity.Property(e => e.Insertnametransit)
                    .HasColumnType("int(11)")
                    .HasColumnName("insertnametransit");

                entity.Property(e => e.Inserttimebeli)
                    .HasColumnType("datetime")
                    .HasColumnName("inserttimebeli")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Inserttimejual)
                    .HasColumnType("datetime")
                    .HasColumnName("inserttimejual")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Inserttimetransit)
                    .HasColumnType("datetime")
                    .HasColumnName("inserttimetransit")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Kodedbeli)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodedbeli");

                entity.Property(e => e.Kodedjual)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodedjual");

                entity.Property(e => e.Kodegudang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodegudang");

                entity.Property(e => e.Kodehbeli)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehbeli");

                entity.Property(e => e.Kodehjual)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehjual");

                entity.Property(e => e.NmrSn)
                    .HasMaxLength(25)
                    .HasColumnName("nmrSN")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status")
                    .HasComment("0=stok,1=terjual");
            });

            modelBuilder.Entity<Barangstokterkait>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("barangstokterkait");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Kodebarang1)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang1");

                entity.Property(e => e.Kodebarang2)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang2");

                entity.Property(e => e.Stok1)
                    .HasColumnType("int(11)")
                    .HasColumnName("stok1");

                entity.Property(e => e.Stok2)
                    .HasColumnType("int(11)")
                    .HasColumnName("stok2");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Bathippo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bathippo");

                entity.Property(e => e.BonusTerendah)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonusTerendah");

                entity.Property(e => e.BonusTertinggi)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonusTertinggi");

                entity.Property(e => e.BrgKode)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("brgKode");

                entity.Property(e => e.HargaTerendah)
                    .HasColumnType("int(11)")
                    .HasColumnName("hargaTerendah");

                entity.Property(e => e.HargaTertinggi)
                    .HasColumnType("int(11)")
                    .HasColumnName("hargaTertinggi");

                entity.Property(e => e.Kode)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kode");
            });

            modelBuilder.Entity<Cekpotonganonline>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cekpotonganonline");

                entity.Property(e => e.Bulan)
                    .HasColumnType("int(11)")
                    .HasColumnName("bulan");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Kodepelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepelanggan");

                entity.Property(e => e.Periksa)
                    .HasColumnType("int(11)")
                    .HasColumnName("periksa")
                    .HasComment("0=belum 1=sudah");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");
            });

            modelBuilder.Entity<Cekstok>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cekstok");

                entity.Property(e => e.Nama)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("nama");

                entity.Property(e => e.Urutan)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("urutan");
            });

            modelBuilder.Entity<Cekstok2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cekstok2");

                entity.Property(e => e.Nama)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("nama");

                entity.Property(e => e.Urutan)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("urutan");
            });

            modelBuilder.Entity<Coa1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("coa1");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Nr)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("nr");

                entity.Property(e => e.Tipe)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tipe");
            });

            modelBuilder.Entity<Coa2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("coa2");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Kodecoa1)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa1");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.Nr)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("nr");

                entity.Property(e => e.Tipe)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tipe");
            });

            modelBuilder.Entity<Coa3>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("coa3");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Kodecoa1)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa1");

                entity.Property(e => e.Kodecoa2)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa2");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.Nr)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("nr");

                entity.Property(e => e.Tipe)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tipe")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Coa4>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("coa4");

                entity.Property(e => e.Golongan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("golongan")
                    .HasComment("0=Belum, 1=Kas");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Kodecoa1)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa1");

                entity.Property(e => e.Kodecoa2)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa2");

                entity.Property(e => e.Kodecoa3)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa3");

                entity.Property(e => e.KodehTrans)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehTrans");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Nr)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("nr")
                    .HasComment("0=Neraca,1=RL");

                entity.Property(e => e.Prefix)
                    .HasMaxLength(2)
                    .HasColumnName("prefix")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Tipe)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tipe")
                    .HasComment("1=Debit,2=Kredit");
            });

            modelBuilder.Entity<Daftarbaranghabi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("daftarbaranghabis");

                entity.Property(e => e.Favorit)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("favorit");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Kodegrupbaranghabis)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodegrupbaranghabis");

                entity.Property(e => e.Kodegudang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodegudang");

                entity.Property(e => e.Maxstok)
                    .HasColumnType("int(11)")
                    .HasColumnName("maxstok");

                entity.Property(e => e.Minstok)
                    .HasColumnType("int(11)")
                    .HasColumnName("minstok");
            });

            modelBuilder.Entity<Daftarbc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("daftarbc");

                entity.Property(e => e.Isi)
                    .HasMaxLength(100)
                    .HasColumnName("isi")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.Judul)
                    .HasMaxLength(255)
                    .HasColumnName("judul")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode");
            });

            modelBuilder.Entity<Daftarkomplain>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("daftarkomplain");

                entity.Property(e => e.Daridivisi)
                    .HasMaxLength(50)
                    .HasColumnName("daridivisi")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.Jawaban)
                    .HasMaxLength(2000)
                    .HasColumnName("jawaban")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.Kepadadivisi)
                    .HasMaxLength(50)
                    .HasColumnName("kepadadivisi")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Komplain)
                    .HasMaxLength(1000)
                    .HasColumnName("komplain")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.Statusdrpenerima)
                    .HasColumnType("int(1)")
                    .HasColumnName("statusdrpenerima");

                entity.Property(e => e.Statusdrpengirim)
                    .HasColumnType("int(1)")
                    .HasColumnName("statusdrpengirim");

                entity.Property(e => e.Tgl)
                    .HasColumnType("date")
                    .HasColumnName("tgl")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<Daftarpujian>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("daftarpujian");

                entity.Property(e => e.Bulan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bulan");

                entity.Property(e => e.Dari)
                    .HasColumnType("int(11)")
                    .HasColumnName("dari");

                entity.Property(e => e.Dibaca)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("dibaca")
                    .HasComment("0 blm dibaca. 1 uda dibaca");

                entity.Property(e => e.Hari)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("hari");

                entity.Property(e => e.Isi)
                    .HasMaxLength(500)
                    .HasColumnName("isi")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kepada)
                    .HasColumnType("int(11)")
                    .HasColumnName("kepada");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Prioritas)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("prioritas");

                entity.Property(e => e.Tahun)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("tahun");
            });

            modelBuilder.Entity<Datagrupnilai>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("datagrupnilai");

                entity.Property(e => e.Bobot)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bobot");

                entity.Property(e => e.Kodegrup)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodegrup");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Nama)
                    .HasMaxLength(60)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''''''''''");
            });

            modelBuilder.Entity<Datanilaipegawai>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("datanilaipegawai");

                entity.Property(e => e.KodeNilai)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodeNilai");

                entity.Property(e => e.KodePeg)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodePeg");
            });

            modelBuilder.Entity<Dbawatagihan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dbawatagihan");

                entity.Property(e => e.KodeH)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeH");

                entity.Property(e => e.KodeHtrans)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeHTrans");

                entity.Property(e => e.KodePelanggan)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kodePelanggan");

                entity.Property(e => e.StatusNota).HasColumnName("statusNota");
            });

            modelBuilder.Entity<Dbelicina>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dbelicina");

                entity.Property(e => e.Harga).HasColumnName("harga");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Koded)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");
            });

            modelBuilder.Entity<Dbonusjete>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dbonusjete");

                entity.Property(e => e.Carahitung).HasColumnName("carahitung");

                entity.Property(e => e.Hrgmin)
                    .HasColumnType("int(11)")
                    .HasColumnName("hrgmin");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Koded)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Namasinonim)
                    .HasMaxLength(150)
                    .HasColumnName("namasinonim")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Dbrgmasukretur>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dbrgmasukretur");

                entity.Property(e => e.AdaPacking).HasColumnName("adaPacking");

                entity.Property(e => e.Harga)
                    .HasColumnType("int(11)")
                    .HasColumnName("harga");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.KetMasuk)
                    .HasMaxLength(40)
                    .HasColumnName("ketMasuk")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(20)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.KodeD)
                    .HasColumnType("smallint(2)")
                    .HasColumnName("kodeD");

                entity.Property(e => e.KodeH)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeH");

                entity.Property(e => e.KodeHpengganti)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeHPengganti");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.KodedPengganti)
                    .HasColumnType("smallint(2)")
                    .HasColumnName("kodedPengganti");

                entity.Property(e => e.NmrSn)
                    .HasMaxLength(20)
                    .HasColumnName("nmrSN")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.TglGantiStok)
                    .HasColumnType("date")
                    .HasColumnName("tglGantiStok")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tglterakhirbeli)
                    .HasColumnType("date")
                    .HasColumnName("tglterakhirbeli")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<Dbukubesar>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dbukubesar");

                entity.Property(e => e.Coa4debit)
                    .HasColumnType("int(11)")
                    .HasColumnName("coa4debit");

                entity.Property(e => e.Coa4kredit)
                    .HasColumnType("int(11)")
                    .HasColumnName("coa4kredit");

                entity.Property(e => e.Insertname)
                    .HasColumnType("int(11)")
                    .HasColumnName("insertname");

                entity.Property(e => e.Inserttime)
                    .HasColumnType("datetime")
                    .HasColumnName("inserttime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(300)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Koded)
                    .HasColumnType("int(11)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodestring)
                    .HasMaxLength(10)
                    .HasColumnName("kodestring")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodetgl)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodetgl");

                entity.Property(e => e.Posted)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("posted")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("date")
                    .HasColumnName("tanggal")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tipe)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tipe")
                    .HasComment("0=normal,1=setoran,2=jurnalmemo,3=jurnalmemokomisi,4=jurnalmemoinsertbiasa,5=jpenjualan,6=jurnalmemopembelianCOD,7=jpembelian,8=hpp,9=jmemogaji,10=LapRLSaldoLaba");

                entity.Property(e => e.Urut)
                    .HasColumnType("int(11)")
                    .HasColumnName("urut");
            });

            modelBuilder.Entity<Dcekharga>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dcekharga");

                entity.Property(e => e.Harga)
                    .HasColumnType("int(11)")
                    .HasColumnName("harga");

                entity.Property(e => e.Kodebrg)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebrg");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Namasinonim)
                    .HasMaxLength(100)
                    .HasColumnName("namasinonim");
            });

            modelBuilder.Entity<Dgajipegawai>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dgajipegawai");

                entity.Property(e => e.Jenis)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jenis")
                    .HasComment("0:tambahan,1:barangkurang,2:uangkurang,3:denda,4:tagihan,5:cicilan,6:fix,7:kata2");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(100)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Koded)
                    .HasColumnType("int(11)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodehtrans)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehtrans");

                entity.Property(e => e.Periksa)
                    .HasColumnType("int(11)")
                    .HasColumnName("periksa");

                entity.Property(e => e.Tipe)
                    .HasColumnName("tipe")
                    .HasComment("1:detail, 2:total,3:fullheader");

                entity.Property(e => e.Urutan)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("urutan");
            });

            modelBuilder.Entity<Dgrouppelanggan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dgrouppelanggan");

                entity.Property(e => e.Hp)
                    .HasMaxLength(200)
                    .HasColumnName("hp")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Koded)
                    .HasColumnType("int(11)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Nama)
                    .HasMaxLength(200)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Dkategoribarang>(entity =>
            {
                entity.HasKey(e => e.Koded);

                entity.ToTable("dkategoribarang");

                entity.Property(e => e.Cnp)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("cnp");

                entity.Property(e => e.Koded)
                    .HasColumnType("int(11)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Munculdimasterbarangapps)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("munculdimasterbarangapps")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nama)
                    .HasMaxLength(30)
                    .HasColumnName("nama");

                entity.Property(e => e.Perlusetharga)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("perlusetharga")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Sn)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("sn");
            });

            modelBuilder.Entity<Dkirimretur>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dkirimretur");

                entity.Property(e => e.Harga).HasColumnName("harga");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(100)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Koded)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Lunas)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("lunas")
                    .HasComment("0=belum,1=sedang,2=lunas,3=potnota");
            });

            modelBuilder.Entity<Dkomisidetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dkomisidetail");

                entity.Property(e => e.Jenis)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jenis")
                    .HasComment("0:biasa,1:gapok,2:bonusarea,3:barangkurang,4:uangkurang,5:barangspesial,6:denda,7:komisi,8:bonusjete,9:tagihan,10:cicilan,11:titipanuangsales");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Koded)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodehtrans)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehtrans");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Periksa)
                    .HasColumnType("int(11)")
                    .HasColumnName("periksa");

                entity.Property(e => e.Persen)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("persen");

                entity.Property(e => e.Urut)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("urut");
            });

            modelBuilder.Entity<Dkomisiomzet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dkomisiomzet");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Koded)
                    .HasColumnType("int(11)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");
            });

            modelBuilder.Entity<Dkomisitargetomzet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dkomisitargetomzet");

                entity.Property(e => e.Bonus)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonus");

                entity.Property(e => e.Koded)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");

                entity.Property(e => e.Omzet)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("omzet");

                entity.Property(e => e.Target)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("target");
            });

            modelBuilder.Entity<Dlevelgaji>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dlevelgaji");

                entity.Property(e => e.Efekabsensi)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("efekabsensi");

                entity.Property(e => e.Jumlah).HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(100)
                    .HasColumnName("keterangan");

                entity.Property(e => e.Koded)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Maks)
                    .HasColumnType("int(11)")
                    .HasColumnName("maks");

                entity.Property(e => e.Tindakan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tindakan")
                    .HasComment("0=Total,1=Satuan Absensi,2=Bonus Kehadiran,3=Bonus Tidak Telat,4=Bonus Omzet,5=Insentif");

                entity.Property(e => e.Urut)
                    .HasColumnType("int(11)")
                    .HasColumnName("urut");
            });

            modelBuilder.Entity<Dnilaipegawai>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dnilaipegawai");

                entity.Property(e => e.Bobot)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("bobot");

                entity.Property(e => e.Jumlah).HasColumnName("jumlah");

                entity.Property(e => e.KodeNilai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeNilai");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");
            });

            modelBuilder.Entity<Dorder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dorder");

                entity.Property(e => e.Disiapkan)
                    .HasColumnName("disiapkan")
                    .HasComment("0=belum, 1=disiapkan, 2=beres");

                entity.Property(e => e.Harga)
                    .HasColumnType("int(11)")
                    .HasColumnName("harga");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Jumlahdikirim)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlahdikirim");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(300)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Keterangancancel)
                    .HasMaxLength(50)
                    .HasColumnName("keterangancancel")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Koded)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("koded");

                entity.Property(e => e.KodedTrans)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodedTrans");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.KodehTrans)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehTrans");

                entity.Property(e => e.Komisi)
                    .HasColumnType("int(11)")
                    .HasColumnName("komisi");

                entity.Property(e => e.Lunas)
                    .HasColumnName("lunas")
                    .HasComment("0:belum. 1: kurang, 2: lunas. 3:cancel, 4:menyusul, 5:berespaksa");

                entity.Property(e => e.Sisa)
                    .HasColumnType("int(11)")
                    .HasColumnName("sisa");
            });

            modelBuilder.Entity<Dordercina>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dordercina");

                entity.Property(e => e.Bukumanualberes)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bukumanualberes");

                entity.Property(e => e.Harga).HasColumnName("harga");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Koded)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Packingberes)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("packingberes");
            });

            modelBuilder.Entity<Dpenggantikirimretur>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dpenggantikirimretur");

                entity.Property(e => e.Harga)
                    .HasColumnType("int(11)")
                    .HasColumnName("harga");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(100)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Koded)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodedpengganti)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kodedpengganti");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodehpengganti)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehpengganti");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Dpenyesuaian>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dpenyesuaian");

                entity.Property(e => e.Kodebrgmasuk)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebrgmasuk");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");
            });

            modelBuilder.Entity<Dpoinaward>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dpoinaward");

                entity.Property(e => e.KodePoinAward)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodePoinAward");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Poin)
                    .HasColumnType("int(11)")
                    .HasColumnName("poin");
            });

            modelBuilder.Entity<Dpphtambahan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dpphtambahan");

                entity.Property(e => e.Harga)
                    .HasColumnType("int(11)")
                    .HasColumnName("harga");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Koded)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Namabarang)
                    .HasMaxLength(300)
                    .HasColumnName("namabarang")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Dproduktahunan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dproduktahunan");

                entity.Property(e => e.Carahitung).HasColumnName("carahitung");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Koded)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Namasinonim)
                    .HasMaxLength(150)
                    .HasColumnName("namasinonim")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Dpromo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dpromo");

                entity.Property(e => e.Hadiahdiberikan)
                    .HasMaxLength(200)
                    .HasColumnName("hadiahdiberikan");

                entity.Property(e => e.Hadiahlunas).HasColumnName("hadiahlunas");

                entity.Property(e => e.History).HasColumnName("history");

                entity.Property(e => e.Kodehpromo)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehpromo");

                entity.Property(e => e.Kodehtrans)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehtrans");

                entity.Property(e => e.Tglhadiahdiberikan)
                    .HasColumnType("date")
                    .HasColumnName("tglhadiahdiberikan");
            });

            modelBuilder.Entity<Dpromopoin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dpromopoin");

                entity.Property(e => e.Carahitung).HasColumnName("carahitung");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Namasinonim)
                    .HasMaxLength(150)
                    .HasColumnName("namasinonim");

                entity.Property(e => e.Poin).HasColumnName("poin");
            });

            modelBuilder.Entity<Drefund>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("drefund");

                entity.Property(e => e.Hargabaru)
                    .HasColumnType("int(11)")
                    .HasColumnName("hargabaru");

                entity.Property(e => e.Hargalama)
                    .HasColumnType("int(11)")
                    .HasColumnName("hargalama");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Kodebm)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebm");

                entity.Property(e => e.Koded)
                    .HasColumnType("int(11)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodehbeli)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehbeli");

                entity.Property(e => e.Nonota)
                    .HasMaxLength(50)
                    .HasColumnName("nonota")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Tgltrans)
                    .HasColumnType("date")
                    .HasColumnName("tgltrans")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<Dresipengiriman>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dresipengiriman");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Koded)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodesupplier)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodesupplier");

                entity.Property(e => e.Resi)
                    .HasMaxLength(10)
                    .HasColumnName("resi")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Dresipengirimankepelanggan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dresipengirimankepelanggan");

                entity.Property(e => e.Kirimmelalui)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kirimmelalui")
                    .HasComment("1=DARAT,2=UDARA,3=LAUT");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodehtrans)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehtrans");

                entity.Property(e => e.Koli)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("koli");

                entity.Property(e => e.OngkirBt)
                    .HasColumnName("ongkirBT")
                    .HasComment("0=tdk,1=bayartujuan");

                entity.Property(e => e.Ongkirfree)
                    .HasColumnName("ongkirfree")
                    .HasComment("0=tdkfree,1=free");

                entity.Property(e => e.Resi)
                    .HasMaxLength(30)
                    .HasColumnName("resi")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Dtargetomzettokopc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dtargetomzettokopcs");

                entity.Property(e => e.Carahitung).HasColumnName("carahitung");

                entity.Property(e => e.Hrgmin)
                    .HasColumnType("int(11)")
                    .HasColumnName("hrgmin");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Koded)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Namasinonim)
                    .HasMaxLength(150)
                    .HasColumnName("namasinonim")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Target)
                    .HasColumnType("int(11)")
                    .HasColumnName("target");
            });

            modelBuilder.Entity<Dtrans>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("dtrans");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Harga)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("harga");

                entity.Property(e => e.HargaOk)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("hargaOK");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Koded)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Komisi)
                    .HasColumnType("int(11)")
                    .HasColumnName("komisi");

                entity.Property(e => e.KuranginStok)
                    .IsRequired()
                    .HasColumnName("kuranginStok")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nmrsn)
                    .HasMaxLength(25)
                    .HasColumnName("nmrsn")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.PoinToko)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("poinToko");

                entity.Property(e => e.Tukartipe)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tukartipe");

                entity.Property(e => e.Untung)
                    .HasColumnType("int(11)")
                    .HasColumnName("untung");
            });

            modelBuilder.Entity<Dtransit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dtransit");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Koded)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("koded");

                entity.Property(e => e.Kodet)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodet");

                entity.Property(e => e.Namapenerima)
                    .HasMaxLength(100)
                    .HasColumnName("namapenerima")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.NmrSn)
                    .HasMaxLength(15)
                    .HasColumnName("nmrSN")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Sudahdicek).HasColumnName("sudahdicek");
            });

            modelBuilder.Entity<Dupdate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dupdate");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.KodeHupdate)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeHUpdate");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Koded)
                    .HasColumnType("int(11)")
                    .HasColumnName("koded");
            });

            modelBuilder.Entity<Emailpromohippo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("emailpromohippo");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.KodePelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodePelanggan");

                entity.Property(e => e.KodeSales)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodeSales");
            });

            modelBuilder.Entity<Glassperwilayah>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("glassperwilayah");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kode)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kode");

                entity.Property(e => e.Lokasi)
                    .HasMaxLength(50)
                    .HasColumnName("lokasi");

                entity.Property(e => e.Sales)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("sales");
            });

            modelBuilder.Entity<Groupbaranghabi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("groupbaranghabis");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .HasColumnName("email");

                entity.Property(e => e.JumData)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumData");

                entity.Property(e => e.JumHabis)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumHabis");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");

                entity.Property(e => e.Urut)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("urut");
            });

            modelBuilder.Entity<Hargasandisk>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hargasandisk");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.H1)
                    .HasColumnType("int(11)")
                    .HasColumnName("h1");

                entity.Property(e => e.H2)
                    .HasColumnType("int(11)")
                    .HasColumnName("h2");

                entity.Property(e => e.H3)
                    .HasColumnType("int(11)")
                    .HasColumnName("h3");

                entity.Property(e => e.H4)
                    .HasColumnType("int(11)")
                    .HasColumnName("h4");

                entity.Property(e => e.HolEcer)
                    .HasColumnType("int(11)")
                    .HasColumnName("hol_ecer");

                entity.Property(e => e.HolGrosir)
                    .HasColumnType("int(11)")
                    .HasColumnName("hol_grosir");

                entity.Property(e => e.HolOfficial)
                    .HasColumnType("int(11)")
                    .HasColumnName("hol_official");

                entity.Property(e => e.HolPromo)
                    .HasColumnType("int(11)")
                    .HasColumnName("hol_promo");

                entity.Property(e => e.Insertname)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("insertname");

                entity.Property(e => e.Inserttime)
                    .HasColumnType("datetime")
                    .HasColumnName("inserttime");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(200)
                    .HasColumnName("keterangan");

                entity.Property(e => e.Kodebrg)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebrg");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.M1)
                    .HasColumnType("int(11)")
                    .HasColumnName("m1");

                entity.Property(e => e.M2)
                    .HasColumnType("int(11)")
                    .HasColumnName("m2");

                entity.Property(e => e.R1)
                    .HasColumnType("int(11)")
                    .HasColumnName("r1");

                entity.Property(e => e.R2)
                    .HasColumnType("int(11)")
                    .HasColumnName("r2");

                entity.Property(e => e.R3)
                    .HasColumnType("int(11)")
                    .HasColumnName("r3");
            });

            modelBuilder.Entity<Hbawatagihan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hbawatagihan");

                entity.Property(e => e.InsertName)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.KodeH)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeH");

                entity.Property(e => e.Sales)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("sales");

                entity.Property(e => e.TglBawa)
                    .HasColumnType("date")
                    .HasColumnName("tglBawa")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<Hbayarpotongan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hbayarpotongan");

                entity.Property(e => e.Coa4)
                    .HasColumnType("int(11)")
                    .HasColumnName("coa4");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(200)
                    .HasColumnName("keterangan");

                entity.Property(e => e.Kodedbukubesar)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodedbukubesar");

                entity.Property(e => e.Kodedetailbayar)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodedetailbayar");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodehbayar)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehbayar");

                entity.Property(e => e.Kodesupplier)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodesupplier");

                entity.Property(e => e.Piutang)
                    .HasColumnType("int(11)")
                    .HasColumnName("piutang");

                entity.Property(e => e.Tgllunas)
                    .HasColumnType("date")
                    .HasColumnName("tgllunas");

                entity.Property(e => e.Urut)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("urut");
            });

            modelBuilder.Entity<Hbayarsupplier>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hbayarsupplier");

                entity.Property(e => e.Bank)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bank")
                    .HasDefaultValueSql("'1'")
                    .HasComment("0=tunai,1=bank");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status")
                    .HasComment("0=belum,1=sudahterekam");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("date")
                    .HasColumnName("tanggal")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<Hbeli>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hbeli");

                entity.Property(e => e.Export)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("export")
                    .HasComment("0=Belum,1=Sudah");

                entity.Property(e => e.HistoryNya)
                    .HasMaxLength(1)
                    .HasColumnName("historyNya")
                    .HasDefaultValueSql("'''1'''")
                    .HasComment("1:belum,0:jhonny");

                entity.Property(e => e.InsertName).HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(400)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.KodeH)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeH");

                entity.Property(e => e.KodeSupplier)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kodeSupplier");

                entity.Property(e => e.Kodefaktur)
                    .HasMaxLength(30)
                    .HasColumnName("kodefaktur")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodegudang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodegudang")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.KodehBayar)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehBayar");

                entity.Property(e => e.Lunas)
                    .HasMaxLength(1)
                    .HasColumnName("lunas")
                    .HasDefaultValueSql("'''0'''")
                    .HasComment("1 = lunas, 0 = belum lunas");

                entity.Property(e => e.Nonota)
                    .HasMaxLength(20)
                    .HasColumnName("nonota")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Ppn)
                    .HasColumnType("int(11)")
                    .HasColumnName("ppn");

                entity.Property(e => e.Ppndiarsip)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("ppndiarsip");

                entity.Property(e => e.TambahanLainnya)
                    .HasColumnType("int(11)")
                    .HasColumnName("tambahanLainnya");

                entity.Property(e => e.TglLaporPpn)
                    .HasColumnType("date")
                    .HasColumnName("tglLaporPPN")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.TglLunas)
                    .HasColumnType("date")
                    .HasColumnName("tglLunas")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.TglTrans)
                    .HasColumnType("date")
                    .HasColumnName("tglTrans")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tglppn)
                    .HasColumnType("date")
                    .HasColumnName("tglppn")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.UpdateName).HasColumnName("updateName");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Urut)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("urut");
            });

            modelBuilder.Entity<Hbelicina>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hbelicina");

                entity.Property(e => e.Berat).HasColumnName("berat");

                entity.Property(e => e.Hargaongkir)
                    .HasColumnType("int(11)")
                    .HasColumnName("hargaongkir");

                entity.Property(e => e.Historynya)
                    .IsRequired()
                    .HasColumnName("historynya")
                    .HasDefaultValueSql("'2'")
                    .HasComment("2=Belum Periksa,1=Sudah");

                entity.Property(e => e.Insertname)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("insertname");

                entity.Property(e => e.Inserttime)
                    .HasColumnType("datetime")
                    .HasColumnName("inserttime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kirimvia)
                    .HasColumnName("kirimvia")
                    .HasComment("0=air,1=sea");

                entity.Property(e => e.Kodeekspedisi)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeekspedisi")
                    .HasComment("0=FASDELI,1=INTEGRA");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodehongkircina)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehongkircina");

                entity.Property(e => e.Kodesuppliercina)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodesuppliercina");

                entity.Property(e => e.Lunas).HasColumnName("lunas");

                entity.Property(e => e.Marking)
                    .HasColumnType("int(11)")
                    .HasColumnName("marking");

                entity.Property(e => e.Ongkirtambahan)
                    .HasColumnType("int(11)")
                    .HasColumnName("ongkirtambahan");

                entity.Property(e => e.Sudahdatang).HasColumnName("sudahdatang");

                entity.Property(e => e.Tglkirim)
                    .HasColumnType("date")
                    .HasColumnName("tglkirim")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tgllunas)
                    .HasColumnType("date")
                    .HasColumnName("tgllunas")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tglnyampe)
                    .HasColumnType("date")
                    .HasColumnName("tglnyampe")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Updatename)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("updatename");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("updatetime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Hbonusjete>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hbonusjete");

                entity.Property(e => e.Bonus1)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonus1");

                entity.Property(e => e.Bonus2)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonus2");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");

                entity.Property(e => e.Qty1)
                    .HasColumnType("int(11)")
                    .HasColumnName("qty1");

                entity.Property(e => e.Qty2)
                    .HasColumnType("int(11)")
                    .HasColumnName("qty2");
            });

            modelBuilder.Entity<Hbrgmasukretur>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hbrgmasukretur");

                entity.Property(e => e.HistoryNya)
                    .HasMaxLength(1)
                    .HasColumnName("historyNya")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.InsertName).HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(150)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.KodeH)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeH");

                entity.Property(e => e.KodePelanggan)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kodePelanggan");

                entity.Property(e => e.KodePemberi)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kodePemberi");

                entity.Property(e => e.Kodesales)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodesales");

                entity.Property(e => e.NamaCust)
                    .HasMaxLength(100)
                    .HasColumnName("namaCust")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.TglTrans)
                    .HasColumnType("date")
                    .HasColumnName("tglTrans")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.UpdateName).HasColumnName("updateName");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Hcekharga>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hcekharga");

                entity.Property(e => e.Carahitung)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("carahitung")
                    .HasComment("0=Kode,1=Sinonim Nama");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Nama).HasMaxLength(100);
            });

            modelBuilder.Entity<Hdetailbayar>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hdetailbayar");

                entity.Property(e => e.InsertName)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("insertName")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Kodehbayar)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehbayar");

                entity.Property(e => e.Kodesupplier)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodesupplier");
            });

            modelBuilder.Entity<Hgajipegawai>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hgajipegawai");

                entity.HasComment("1 belum dicek, 0 uda dicek");

                entity.Property(e => e.Bulan)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("bulan");

                entity.Property(e => e.InsertName)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.JumlahFull)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlahFULL");

                entity.Property(e => e.KodeFormGaji)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeFormGaji");

                entity.Property(e => e.KodePeg)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodePeg");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("'3'")
                    .HasComment("3=Belum,2=siapdiberikan,1=sudahdiberikan,0=sudahdipotong");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(4)")
                    .HasColumnName("tahun");

                entity.Property(e => e.TglBagi)
                    .HasColumnType("datetime")
                    .HasColumnName("tglBagi");

                entity.Property(e => e.TglPotong)
                    .HasColumnType("datetime")
                    .HasColumnName("tglPotong");

                entity.Property(e => e.Tunai)
                    .HasColumnName("tunai")
                    .HasComment("0:Tunai;1:TT");

                entity.Property(e => e.UpdateName)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("updateName");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime");
            });

            modelBuilder.Entity<Hgrouppelanggan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hgrouppelanggan");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");
            });

            modelBuilder.Entity<Historyka>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("historykas");

                entity.Property(e => e.InsertName).HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(100)
                    .HasColumnName("keterangan");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.TglKas)
                    .HasColumnType("date")
                    .HasColumnName("tglKas");
            });

            modelBuilder.Entity<Historylimit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("historylimit");

                entity.Property(e => e.Insertname)
                    .HasColumnType("int(11)")
                    .HasColumnName("insertname");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Kodepelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepelanggan");

                entity.Property(e => e.Tglnaik)
                    .HasColumnType("datetime")
                    .HasColumnName("tglnaik");
            });

            modelBuilder.Entity<Hjamkerja>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hjamkerja");

                entity.Property(e => e.Batasjammasuk1)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("batasjammasuk1");

                entity.Property(e => e.Batasjammasuk2)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("batasjammasuk2");

                entity.Property(e => e.Batasjampulang1)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("batasjampulang1");

                entity.Property(e => e.Batasjampulang2)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("batasjampulang2");

                entity.Property(e => e.Jammasuk)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jammasuk");

                entity.Property(e => e.Jampulang)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jampulang");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .HasColumnName("nama");
            });

            modelBuilder.Entity<Hkelompokbarang>(entity =>
            {

                entity.ToTable("hkelompokbarang");
                entity.HasKey(x => x.Kode);
                entity.Property(e => e.Kode)
                   .HasColumnType("int(11)")
                   .HasColumnName("kode")
                   .ValueGeneratedOnAdd();

                entity.Property(e => e.Nama)
                    .HasMaxLength(20)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

               
            });

            modelBuilder.Entity<Hkategoribarang>(entity =>
            {

                entity.ToTable("hkategoribarang");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Cektahunan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("cektahunan")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Hargakhusus)
                    .HasColumnType("int(11)")
                    .HasColumnName("hargakhusus");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Nama)
                    .HasMaxLength(20)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Perlusetharga)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("perlusetharga")
                    .HasDefaultValueSql("'1'");


                entity.HasKey(x => x.Kodeh);
            });

            modelBuilder.Entity<Hkirimretur>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hkirimretur");

                entity.Property(e => e.HistoryNya)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("historyNya")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1:belum,0:jhonny");

                entity.Property(e => e.InsertName).HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(400)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.KodeH)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeH");

                entity.Property(e => e.KodeSupplier)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kodeSupplier");

                entity.Property(e => e.Lunas)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("lunas")
                    .HasComment("1 = lunas, 0 = belum lunas");

                entity.Property(e => e.Penyesuaian)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("penyesuaian")
                    .HasComment("0=returbiasa,1=penyesuaian");

                entity.Property(e => e.TglLunas)
                    .HasColumnType("date")
                    .HasColumnName("tglLunas")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.TglTrans)
                    .HasColumnType("date")
                    .HasColumnName("tglTrans")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.UpdateName).HasColumnName("updateName");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Hkomisi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hkomisi");

                entity.Property(e => e.Bonusarea)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonusarea");

                entity.Property(e => e.Bonusjete)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonusjete");

                entity.Property(e => e.Bulan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bulan");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodesales)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodesales");

                entity.Property(e => e.Komisi)
                    .HasColumnType("int(11)")
                    .HasColumnName("komisi");

                entity.Property(e => e.Komisidanbonus)
                    .HasColumnType("int(11)")
                    .HasColumnName("komisidanbonus");

                entity.Property(e => e.PersenSedia).HasColumnName("persenSedia");

                entity.Property(e => e.Sisagaji)
                    .HasColumnType("int(11)")
                    .HasColumnName("sisagaji");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status")
                    .HasComment("0=belum,1=sudah");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");

                entity.Property(e => e.Tgltt)
                    .HasColumnType("date")
                    .HasColumnName("tgltt");

                entity.Property(e => e.Totalomzet)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("totalomzet");

                entity.Property(e => e.Untung)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("untung");
            });

            modelBuilder.Entity<Hlevelgaji>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hlevelgaji");

                entity.Property(e => e.Formatspg)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("formatspg")
                    .HasComment("Bila 1, maka gaji akan FIX di jumlah hari SPG (1 minggu libur 4x");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .HasColumnName("nama");
            });

            modelBuilder.Entity<Hlunasinmassal>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hlunasinmassal");

                entity.Property(e => e.Insertname)
                    .HasColumnType("int(11)")
                    .HasColumnName("insertname");

                entity.Property(e => e.Inserttime)
                    .HasColumnType("datetime")
                    .HasColumnName("inserttime");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Periksa)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("periksa")
                    .HasComment("0=Belum,1=Sudah");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("date")
                    .HasColumnName("tanggal");
            });

            modelBuilder.Entity<Hnilaipegawai>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hnilaipegawai");

                entity.Property(e => e.Bulan)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("bulan");

                entity.Property(e => e.KodePeg)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodePeg");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Pesan)
                    .HasMaxLength(500)
                    .HasColumnName("pesan");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("0 : TDK BISA UPDATE, 1 BISA UPDATE");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(4)")
                    .HasColumnName("tahun");
            });

            modelBuilder.Entity<Hongkircina>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hongkircina");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("date")
                    .HasColumnName("tanggal");
            });

            modelBuilder.Entity<Horder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("horder");

                entity.Property(e => e.Barcodeonline)
                    .HasMaxLength(30)
                    .HasColumnName("barcodeonline")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Dicetak).HasColumnName("dicetak");

                entity.Property(e => e.Historynya)
                    .IsRequired()
                    .HasColumnName("historynya")
                    .HasDefaultValueSql("'3'")
                    .HasComment("5=BelumdicekOL");

                entity.Property(e => e.Infopenting)
                    .HasMaxLength(30)
                    .HasColumnName("infopenting")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Insertname)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("insertname");

                entity.Property(e => e.Inserttime)
                    .HasColumnType("datetime")
                    .HasColumnName("inserttime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(400)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kirimmelalui).HasColumnName("kirimmelalui");

                entity.Property(e => e.Kodeexp)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeexp");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodeonline)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeonline");

                entity.Property(e => e.Kodeorderapps)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeorderapps");

                entity.Property(e => e.Kodepelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepelanggan");

                entity.Property(e => e.Kodepenyiap)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodepenyiap");

                entity.Property(e => e.Kodesales)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodesales");

                entity.Property(e => e.Lunas).HasColumnName("lunas");

                entity.Property(e => e.NamaCust)
                    .HasMaxLength(50)
                    .HasColumnName("namaCust")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.NmrHp)
                    .HasMaxLength(15)
                    .HasColumnName("nmrHP")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.NoSeriOnline)
                    .HasMaxLength(20)
                    .HasColumnName("noSeriOnline")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Ppn)
                    .HasColumnType("int(11)")
                    .HasColumnName("ppn");

                entity.Property(e => e.StokSales)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("stokSales");

                entity.Property(e => e.Sudahupdatephone)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("sudahupdatephone")
                    .HasComment("UNTUK UPDATE NMR HP");

                entity.Property(e => e.Tglcetak)
                    .HasColumnType("datetime")
                    .HasColumnName("tglcetak")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Tglorder)
                    .HasColumnType("date")
                    .HasColumnName("tglorder")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tgltempo)
                    .HasColumnType("date")
                    .HasColumnName("tgltempo")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tipetempo)
                    .IsRequired()
                    .HasColumnName("tipetempo")
                    .HasDefaultValueSql("'30'");

                entity.Property(e => e.Updatename)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("updatename");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("updatetime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Hordercina>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hordercina");

                entity.Property(e => e.Insertname)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("insertname");

                entity.Property(e => e.Inserttime)
                    .HasColumnType("datetime")
                    .HasColumnName("inserttime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Jumlahdp)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlahdp");

                entity.Property(e => e.Kelengkapanberes)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kelengkapanberes");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(200)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kirim)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kirim");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodesupplier)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodesupplier");

                entity.Property(e => e.Perkiraantglkirim)
                    .HasColumnType("date")
                    .HasColumnName("perkiraantglkirim")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tglkirim)
                    .HasColumnType("date")
                    .HasColumnName("tglkirim")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tglorder)
                    .HasColumnType("date")
                    .HasColumnName("tglorder")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Updatename)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("updatename")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("updatetime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Hpakaiinventari>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hpakaiinventaris");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.KodeInventaris)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeInventaris");

                entity.Property(e => e.KodePegawai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodePegawai");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.TglPakai)
                    .HasColumnType("date")
                    .HasColumnName("tglPakai");
            });

            modelBuilder.Entity<Hpenggantikirimretur>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hpenggantikirimretur");

                entity.Property(e => e.HistoryNya)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("historyNya")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1:belum,0:jhonny");

                entity.Property(e => e.InsertName).HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(400)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.KodeH)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeH");

                entity.Property(e => e.KodeSupplier)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kodeSupplier");

                entity.Property(e => e.Nonota)
                    .HasMaxLength(20)
                    .HasColumnName("nonota")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status")
                    .HasComment("0=gantiretur, 1=potongnota");

                entity.Property(e => e.Sudahexport).HasColumnName("sudahexport");

                entity.Property(e => e.Sudahpotongnota).HasColumnName("sudahpotongnota");

                entity.Property(e => e.TglTrans)
                    .HasColumnType("date")
                    .HasColumnName("tglTrans")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tglpotongnota)
                    .HasColumnType("date")
                    .HasColumnName("tglpotongnota")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.UpdateName).HasColumnName("updateName");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Hpengiriman>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hpengiriman");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodehtrans)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehtrans");

                entity.Property(e => e.Kodepengiriman)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepengiriman");

                entity.Property(e => e.Tglkirim)
                    .HasColumnType("datetime")
                    .HasColumnName("tglkirim")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Hpenyesuaian>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hpenyesuaian");

                entity.Property(e => e.Historynya)
                    .IsRequired()
                    .HasColumnName("historynya")
                    .HasDefaultValueSql("'1'")
                    .HasComment("0=sudahdiperiksa,1=belum");

                entity.Property(e => e.Insertname)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("insertname");

                entity.Property(e => e.Inserttime)
                    .HasColumnType("datetime")
                    .HasColumnName("inserttime");

                entity.Property(e => e.Kodegudang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodegudang");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(6)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Tgltrans)
                    .HasColumnType("date")
                    .HasColumnName("tgltrans");
            });

            modelBuilder.Entity<Hpoinaward>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hpoinaward");

                entity.Property(e => e.Bulan)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("bulan");

                entity.Property(e => e.InsertName)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.KodePeg)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodePeg");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(4)")
                    .HasColumnName("tahun");
            });

            modelBuilder.Entity<Hppntambahan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hppntambahan");

                entity.Property(e => e.InsertName)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.KodeH)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeH");

                entity.Property(e => e.KodePelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodePelanggan");

                entity.Property(e => e.Ppn)
                    .HasColumnType("int(11)")
                    .HasColumnName("ppn");

                entity.Property(e => e.Ppndiarsip)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("ppndiarsip");

                entity.Property(e => e.TglLaporPpn)
                    .HasColumnType("date")
                    .HasColumnName("tglLaporPPN");

                entity.Property(e => e.TglTrans)
                    .HasColumnType("date")
                    .HasColumnName("tglTrans");

                entity.Property(e => e.Tipe)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tipe")
                    .HasComment("0=tambahan,1=gunggungan");
            });

            modelBuilder.Entity<Hproduktahunan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hproduktahunan");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");
            });

            modelBuilder.Entity<Hpromo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hpromo");

                entity.Property(e => e.Aktif)
                    .IsRequired()
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Hadiah)
                    .HasMaxLength(200)
                    .HasColumnName("hadiah");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(200)
                    .HasColumnName("nama");

                entity.Property(e => e.Target)
                    .HasMaxLength(200)
                    .HasColumnName("target");

                entity.Property(e => e.Tglakhir)
                    .HasColumnType("date")
                    .HasColumnName("tglakhir");

                entity.Property(e => e.Tglawal)
                    .HasColumnType("date")
                    .HasColumnName("tglawal");
            });

            modelBuilder.Entity<Hrefund>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hrefund");

                entity.Property(e => e.HistoryNya)
                    .HasMaxLength(1)
                    .HasColumnName("historyNya")
                    .HasDefaultValueSql("'''1'''")
                    .HasComment("1:belum,0:jhonny");

                entity.Property(e => e.InsertName).HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(400)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.KodeH)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeH");

                entity.Property(e => e.KodeSupplier)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeSupplier");

                entity.Property(e => e.Lunas)
                    .HasMaxLength(1)
                    .HasColumnName("lunas")
                    .HasDefaultValueSql("'''0'''")
                    .HasComment("1 = lunas, 0 = belum lunas");

                entity.Property(e => e.TglLunas)
                    .HasColumnType("date")
                    .HasColumnName("tglLunas")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.TglTrans)
                    .HasColumnType("date")
                    .HasColumnName("tglTrans")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.UpdateName).HasColumnName("updateName");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Hsidikjari>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hsidikjari");

                entity.Property(e => e.Jamacuan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jamacuan");

                entity.Property(e => e.Jamsidikjari)
                    .HasColumnType("datetime")
                    .HasColumnName("jamsidikjari")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jenisabsen)
                    .HasColumnName("jenisabsen")
                    .HasComment("0=masuk,1=pulang");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodeonline)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeonline");

                entity.Property(e => e.Kodepegawai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepegawai");
            });

            modelBuilder.Entity<Htrans>(entity =>
            {
                entity.HasKey(e => e.KodeH)
                     .HasName("PRIMARY");

                entity.ToTable("htrans");

                entity.HasIndex(e => e.AkanDjJurnalkan, "akanDjJurnalkan");

                entity.HasIndex(e => e.Jumlah, "jumlah");

                entity.HasIndex(e => e.KodePelanggan, "kodePelanggan");

                entity.HasIndex(e => e.KodeSales, "kodeSales");

                entity.HasIndex(e => e.Kodegudang, "kodegudang");

                entity.HasIndex(e => e.NoSeriOnline, "noSeriOnline");

                entity.HasIndex(e => new { e.TglTrans, e.KodePelanggan, e.Kodegudang }, "tglTrans");

                entity.Property(e => e.KodeH)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeH");

                entity.Property(e => e.Admingantiharga)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("admingantiharga")
                    .HasComment("Penanda Bila Admin ada ganti harga");

                entity.Property(e => e.Adminkiriman).HasColumnName("adminkiriman");

                entity.Property(e => e.AkanDjJurnalkan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("akanDjJurnalkan")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1=AKAN MASUK JURNAL PENJUALAN. 0=TIDAK MASUK JURNAL PENJUALAN");

                entity.Property(e => e.BagiKomisi)
                    .HasMaxLength(1)
                    .HasColumnName("bagiKomisi")
                    .HasDefaultValueSql("'''0'''")
                    .HasComment("1 = uda bagi, 0 = belum bagi");

                entity.Property(e => e.Barcodeonline)
                    .HasMaxLength(30)
                    .HasColumnName("barcodeonline")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.Cadanganppn)
                    .HasColumnType("int(11)")
                    .HasColumnName("cadanganppn")
                    .HasComment("UNTUK SIMPAN CADANGAN PPN SEBELUM DILAKUKAN PERUBAHAN BESAR");

                entity.Property(e => e.CustOlkodepos)
                    .HasMaxLength(20)
                    .HasColumnName("custOLKodepos")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.CustOlkota)
                    .HasMaxLength(100)
                    .HasColumnName("custOLkota")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.CustOlprovinsi)
                    .HasMaxLength(100)
                    .HasColumnName("custOLprovinsi")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.CustOlwilayah)
                    .HasMaxLength(100)
                    .HasColumnName("custOLwilayah")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.DiCetak).HasColumnName("diCetak");

                entity.Property(e => e.Dikirim)
                    .HasColumnType("int(11)")
                    .HasColumnName("dikirim");

                entity.Property(e => e.Diskon)
                    .HasColumnType("int(11)")
                    .HasColumnName("diskon");

                entity.Property(e => e.Dpp)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("dpp");

                entity.Property(e => e.HistoryNya)
                    .HasMaxLength(1)
                    .HasColumnName("historyNya")
                    .HasDefaultValueSql("'''4'''")
                    .HasComment("3:belum,2:yanti,1:audit,0:jhonny");

                entity.Property(e => e.Infopenting)
                    .HasMaxLength(31)
                    .HasColumnName("infopenting")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.InsertName)
                    .HasColumnType("int(11)")
                    .HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.JumKoli)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumKoli");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.JumlahKomisi)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlahKomisi");

                entity.Property(e => e.JumlahOnString)
                    .HasMaxLength(8)
                    .HasColumnName("jumlahOnString")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.Jumlahbarangbiaya)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlahbarangbiaya")
                    .HasComment("TOTAL DARI BRG2 YG BERUPA BIAYA NON JURNAL PENJUALAN");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(400)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.KodePelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodePelanggan");

                entity.Property(e => e.KodeSales)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeSales");

                entity.Property(e => e.Kodegudang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodegudang")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Kodenota)
                    .HasMaxLength(12)
                    .HasColumnName("kodenota")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodeonline)
                    .HasColumnType("int(16)")
                    .HasColumnName("kodeonline");

                entity.Property(e => e.Kodeorderapps)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeorderapps")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Lunas)
                    .HasMaxLength(1)
                    .HasColumnName("lunas")
                    .HasDefaultValueSql("'''0'''")
                    .HasComment("1 = lunas, 0 = belum lunas");

                entity.Property(e => e.NamaCust)
                    .HasMaxLength(50)
                    .HasColumnName("namaCust")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.NmrHp)
                    .HasMaxLength(15)
                    .HasColumnName("nmrHP")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.NoOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("noOrder");

                entity.Property(e => e.NoSeriOnline)
                    .HasMaxLength(20)
                    .HasColumnName("noSeriOnline")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.Noretur)
                    .HasColumnType("int(11)")
                    .HasColumnName("noretur");

                entity.Property(e => e.Notrans)
                    .HasColumnType("int(11)")
                    .HasColumnName("notrans");

                entity.Property(e => e.PoinToko)
                    .HasColumnType("smallint(4)")
                    .HasColumnName("poinToko");

                entity.Property(e => e.Ppn)
                    .HasColumnType("int(11)")
                    .HasColumnName("ppn");

                entity.Property(e => e.Ppndiarsip)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("ppndiarsip");

                entity.Property(e => e.Ppnreal)
                    .HasColumnType("int(11)")
                    .HasColumnName("ppnreal")
                    .HasComment("PPN 100% UNTUK SEMUA");

                entity.Property(e => e.Retur)
                    .HasMaxLength(1)
                    .HasColumnName("retur")
                    .HasDefaultValueSql("'''0'''")
                    .HasComment("0=NORMAL. 2=RETUR. 1 TIDAK DIPAKE");

                entity.Property(e => e.SalesPenagih)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("salesPenagih");

                entity.Property(e => e.StatusNota).HasColumnName("statusNota");

                entity.Property(e => e.Stoknota).HasColumnName("stoknota");

                entity.Property(e => e.Sudahupdateorderapps)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("sudahupdateorderapps")
                    .HasComment("BUAT KEPERLUAN CROWN UPDATE STATUS TERKIRIM DI APPS DORAN.ID");

                entity.Property(e => e.Sudahupdatephone)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("sudahupdatephone")
                    .HasComment("UNTUK UPDATE NMR HP");

                entity.Property(e => e.TambahanLainnya)
                    .HasColumnType("int(11)")
                    .HasColumnName("tambahanLainnya");

                entity.Property(e => e.Terbitfakturppn)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("terbitfakturppn")
                    .HasComment("0=TIDAK_TERBIT. 1=TERBIT_FAKTUR_PPN");

                entity.Property(e => e.TglBagiKomisi)
                    .HasColumnType("date")
                    .HasColumnName("tglBagiKomisi")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.TglLaporPpn)
                    .HasColumnType("date")
                    .HasColumnName("tglLaporPPN")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.TglLunas)
                    .HasColumnType("date")
                    .HasColumnName("tglLunas")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.TglPpn)
                    .HasColumnType("date")
                    .HasColumnName("tglPPN")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.TglTrans)
                    .HasColumnType("date")
                    .HasColumnName("tglTrans")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tglcek)
                    .HasColumnType("datetime")
                    .HasColumnName("tglcek")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''")
                    .HasComment("Buat isi kapan dicek oleh tim finance");

                entity.Property(e => e.Tgldikirim)
                    .HasColumnType("datetime")
                    .HasColumnName("tgldikirim")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Tgltempo)
                    .HasColumnType("date")
                    .HasColumnName("tgltempo")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tipetempo)
                    .IsRequired()
                    .HasColumnName("tipetempo")
                    .HasDefaultValueSql("'30'");

                entity.Property(e => e.Untung)
                    .HasColumnType("int(11)")
                    .HasColumnName("untung");

                entity.Property(e => e.UntungbelumpotOl)
                    .HasColumnType("int(11)")
                    .HasColumnName("untungbelumpotOL");

                entity.Property(e => e.UpdateName)
                    .HasColumnType("int(11)")
                    .HasColumnName("updateName");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Htransit>(entity =>
            {
                entity.HasKey(e => e.KodeT)
                    .HasName("PRIMARY");

                entity.ToTable("htransit");

                entity.HasIndex(e => e.KodeGudangTujuan, "kodeGudangTujuan");

                entity.HasIndex(e => e.Kodegudang, "kodegudang");

                entity.Property(e => e.KodeT)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeT");

                entity.Property(e => e.Export)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("export")
                    .HasDefaultValueSql("'0'")
                    .HasComment("0=Belum,1=Sudah");

                entity.Property(e => e.HistoryNya)
                    .HasMaxLength(1)
                    .HasColumnName("historyNya")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.InsertName)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("insertName")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(150)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.KodeGudangTujuan)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kodeGudangTujuan")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Kodegudang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodegudang")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Kodeonline)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeonline")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Kodepenyiap)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodepenyiap")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TglTrans)
                    .HasColumnType("date")
                    .HasColumnName("tglTrans")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.UpdateName)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("updateName")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Htuga>(entity =>
            {
                entity.HasKey(e => e.Kodeh)
                    .HasName("PRIMARY");

                entity.ToTable("htugas");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodesales)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodesales");

                entity.Property(e => e.Kodetugas)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodetugas");

                entity.Property(e => e.Poin)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("poin");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tgldapattugas)
                    .HasColumnType("date")
                    .HasColumnName("tgldapattugas")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tglselesaitugas)
                    .HasColumnType("date")
                    .HasColumnName("tglselesaitugas")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<Hupdate>(entity =>
            {
                entity.HasKey(e => e.KodeHupdate)
                    .HasName("PRIMARY");

                entity.ToTable("hupdate");

                entity.Property(e => e.KodeHupdate)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeHUpdate");

                entity.Property(e => e.InsertName)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(400)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.KodeH)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeH");
            });

            modelBuilder.Entity<Hwunderlist>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("hwunderlist");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Adminselesai)
                    .HasColumnType("int(11)")
                    .HasColumnName("adminselesai");

                entity.Property(e => e.Insertname)
                    .HasColumnType("int(11)")
                    .HasColumnName("insertname");

                entity.Property(e => e.Kodepegawai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepegawai");

                entity.Property(e => e.Pekerjaan)
                    .HasMaxLength(200)
                    .HasColumnName("pekerjaan");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");

                entity.Property(e => e.Tglbuat)
                    .HasColumnType("date")
                    .HasColumnName("tglbuat");

                entity.Property(e => e.Tglselesai)
                    .HasColumnType("date")
                    .HasColumnName("tglselesai");

                entity.Property(e => e.Tgltarget)
                    .HasColumnType("date")
                    .HasColumnName("tgltarget");
            });

            modelBuilder.Entity<Idolshop>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("idolshop");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Jumfollower)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumfollower");

                entity.Property(e => e.Jumfoto)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumfoto");

                entity.Property(e => e.Kodesales)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodesales");

                entity.Property(e => e.Namatoko)
                    .HasMaxLength(200)
                    .HasColumnName("namatoko");

                entity.Property(e => e.Nohpterdaftar)
                    .HasMaxLength(50)
                    .HasColumnName("nohpterdaftar");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("password");

                entity.Property(e => e.Tipeid)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("tipeid");

                entity.Property(e => e.Userid)
                    .HasMaxLength(30)
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<Jadwalluarkotum>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("jadwalluarkota");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Insertname)
                    .HasColumnType("int(11)")
                    .HasColumnName("insertname");

                entity.Property(e => e.Inserttime)
                    .HasColumnType("datetime")
                    .HasColumnName("inserttime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(100)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodepegawai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepegawai");

                entity.Property(e => e.Kodesupir)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodesupir");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("date")
                    .HasColumnName("tanggal")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<Jenisidolshop>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("jenisidolshop");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .HasColumnName("nama");
            });

            modelBuilder.Entity<JobsFailed>(entity =>
            {
                entity.ToTable("jobs_failed");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Connection)
                    .HasColumnType("text")
                    .HasColumnName("connection");

                entity.Property(e => e.Exception).HasColumnName("exception");

                entity.Property(e => e.FailedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("failed_at")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Payload).HasColumnName("payload");

                entity.Property(e => e.Queue)
                    .HasColumnType("text")
                    .HasColumnName("queue");
            });

            modelBuilder.Entity<JobsRunning>(entity =>
            {
                entity.ToTable("jobs_running");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ConnectionName)
                    .HasMaxLength(100)
                    .HasColumnName("connection_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CurrentOffset)
                    .HasColumnType("int(11)")
                    .HasColumnName("current_offset")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.JobId)
                    .HasColumnType("int(11)")
                    .HasColumnName("job_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Log)
                    .HasColumnType("text")
                    .HasColumnName("log")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ShopId)
                    .HasMaxLength(255)
                    .HasColumnName("shop_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TotalData)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_data")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Kaizen>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("kaizen");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(4)")
                    .HasColumnName("kode");

                entity.Property(e => e.Admin)
                    .HasColumnType("int(4)")
                    .HasColumnName("admin");

                entity.Property(e => e.Bulan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bulan");

                entity.Property(e => e.Diperiksa)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("diperiksa");

                entity.Property(e => e.Isi)
                    .HasMaxLength(500)
                    .HasColumnName("isi");

                entity.Property(e => e.Judul)
                    .HasMaxLength(100)
                    .HasColumnName("judul");

                entity.Property(e => e.Kodepegawai)
                    .HasColumnType("int(4)")
                    .HasColumnName("kodepegawai");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(4)")
                    .HasColumnName("tahun");
            });

            modelBuilder.Entity<Komponenprestasi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("komponenprestasi");

                entity.Property(e => e.BackAbu)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("backAbu");

                entity.Property(e => e.Baris)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("baris");

                entity.Property(e => e.Fungsi)
                    .HasMaxLength(60)
                    .HasColumnName("fungsi")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kolom)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kolom");

                entity.Property(e => e.Lebar)
                    .HasColumnType("smallint(11)")
                    .HasColumnName("lebar");

                entity.Property(e => e.Tebal)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tebal");
            });

            modelBuilder.Entity<Laporanakuntansi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("laporanakuntansi");

                entity.Property(e => e.Bulan)
                    .HasColumnType("int(11)")
                    .HasColumnName("bulan");

                entity.Property(e => e.Insertname)
                    .HasColumnType("int(11)")
                    .HasColumnName("insertname");

                entity.Property(e => e.Inserttime)
                    .HasColumnType("datetime")
                    .HasColumnName("inserttime");

                entity.Property(e => e.Jenis)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jenis")
                    .HasComment("0=NR,1=LR");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodecoa4)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa4");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");
            });

            modelBuilder.Entity<Laporanharian>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("laporanharian");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Bulan)
                    .HasColumnType("int(11)")
                    .HasColumnName("bulan");

                entity.Property(e => e.Jumtidaklaporan)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumtidaklaporan");

                entity.Property(e => e.Kodepegawai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepegawai");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");
            });

            modelBuilder.Entity<LogUpdatePhone>(entity =>
            {
                entity.ToTable("log_update_phone");

                entity.HasComment("table untuk log saat terakhir ubah nomor hp pelanggan");

                entity.HasIndex(e => e.BrandId, "brand_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.BrandId)
                    .HasColumnType("int(11)")
                    .HasColumnName("brand_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'current_timestamp()'");
            });

            modelBuilder.Entity<Logfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("logfile");

                entity.Property(e => e.Keterangan)
                    .HasColumnType("text")
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("datetime")
                    .HasColumnName("tanggal")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Username).HasColumnName("username");
            });

            modelBuilder.Entity<Logfileserver>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("logfileserver");

                entity.HasIndex(e => e.Kode, "kode");

                entity.Property(e => e.Isilaporan)
                    .HasColumnName("isilaporan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Pengirim)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("pengirim");

                entity.Property(e => e.Perintah)
                    .HasMaxLength(20)
                    .HasColumnName("perintah")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.Sudahdibalas)
                    .HasColumnName("sudahdibalas")
                    .HasComment("0:BELUM. 1:SUDAH");

                entity.Property(e => e.Tgl)
                    .HasColumnType("date")
                    .HasColumnName("tgl")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<LokasiKota>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("lokasi_kota");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.AdaKertasOrder)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("adaKertasOrder");

                entity.Property(e => e.Kodeareapengiriman)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodeareapengiriman");

                entity.Property(e => e.Kodecoa4)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa4");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");

                entity.Property(e => e.Provinsi)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("provinsi");
            });

            modelBuilder.Entity<LokasiProvinsi>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("lokasi_provinsi");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");
            });

            modelBuilder.Entity<Manageriallaporan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("manageriallaporan");

                entity.Property(e => e.Kodemanager)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodemanager");

                entity.Property(e => e.Kodepegawai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepegawai");

                entity.Property(e => e.Teruskankeatasan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("teruskankeatasan");
            });

            modelBuilder.Entity<MasterPelangganGabungan>(entity =>
            {
                entity.ToTable("master_pelanggan_gabungan");

                entity.HasIndex(e => e.BrandId, "kategori_barang");

                entity.HasIndex(e => e.KodeBarang, "kode_barang");

                entity.HasIndex(e => e.KodePelanggan, "kode_pelanggan");

                entity.HasIndex(e => e.KodeSales, "kode_sales");

                entity.HasIndex(e => e.Kodeh, "koded");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BrandId)
                    .HasColumnType("int(11)")
                    .HasColumnName("brand_id");

                entity.Property(e => e.Harga)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("harga")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.HasUpdated).HasColumnName("has_updated");

                entity.Property(e => e.IsOrder)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("is_order");

                entity.Property(e => e.KodeBarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode_barang");

                entity.Property(e => e.KodePelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode_pelanggan");

                entity.Property(e => e.KodeSales)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode_sales")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.NamaCust)
                    .HasMaxLength(255)
                    .HasColumnName("nama_cust")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nomorgudang)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("nomorgudang");

                entity.Property(e => e.Pcs)
                    .HasColumnType("int(11)")
                    .HasColumnName("pcs");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("date")
                    .HasColumnName("tanggal")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Masteragama>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masteragama");

                entity.Property(e => e.Kode).HasColumnType("tinyint(4)");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Masterbank>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masterbank");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Kodebuku)
                    .HasMaxLength(3)
                    .HasColumnName("kodebuku")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodecoa4)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa4");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Masterbarang>(entity =>
            {
                entity.HasKey(e => e.BrgKode)
                    .HasName("PRIMARY");

                entity.ToTable("masterbarang");

                entity.HasIndex(e => e.BrgAktif, "brgAktif");

                entity.HasIndex(e => e.KategoriBrg, "kategoriBrg");

                entity.Property(e => e.BrgKode)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("brgKode");

                entity.Property(e => e.BrgAktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("brgAktif");

                entity.Property(e => e.BrgHabis)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("brgHabis");

                entity.Property(e => e.BrgNama)
                    .HasMaxLength(100)
                    .HasColumnName("brgNama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Brgspesial).HasColumnName("brgspesial");

                entity.Property(e => e.Diskontinu)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("diskontinu");

                entity.Property(e => e.Favorit)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("favorit");

                entity.Property(e => e.Groupbaranghabis)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("groupbaranghabis");

                entity.Property(e => e.HargaSrp)
                    .HasColumnType("int(11)")
                    .HasColumnName("hargaSRP");

                entity.Property(e => e.Hargaol)
                    .HasColumnType("int(11)")
                    .HasColumnName("hargaol");

                entity.Property(e => e.Hargatoko)
                    .HasColumnType("int(11)")
                    .HasColumnName("hargatoko");

                entity.Property(e => e.InsertName).HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.KategoriBrg)
                    .HasColumnType("int(11)")
                    .HasColumnName("kategoriBrg");

                entity.Property(e => e.KetKirimanCina)
                    .HasMaxLength(20)
                    .HasColumnName("ketKirimanCina")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Komisi)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("komisi")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Kpikelengkapantoko)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kpikelengkapantoko")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Keperluan Apps PastiSukses untuk cek apakah brg ini perlu diorder toko atau belum. 1=Perlu. 0=TidakPerlu.");

                entity.Property(e => e.Maksstok)
                    .HasColumnType("int(11)")
                    .HasColumnName("maksstok");

                entity.Property(e => e.MinStokHabis)
                    .HasColumnType("int(11)")
                    .HasColumnName("minStokHabis");

                entity.Property(e => e.Modal)
                    .HasColumnType("int(11)")
                    .HasColumnName("modal");

                entity.Property(e => e.Namaol)
                    .HasMaxLength(100)
                    .HasColumnName("namaol")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.PoinToko)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("poinToko");

                entity.Property(e => e.SetHarga)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("setHarga");

                entity.Property(e => e.Simpanmemostok)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("simpanmemostok");

                entity.Property(e => e.StatusKirimanCina)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("statusKirimanCina")
                    .HasComment("0=tidakada,1=disiapkan,2=dikirim");

                entity.Property(e => e.Supplierkode)
                    .HasColumnType("int(11)")
                    .HasColumnName("supplierkode")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Tipebarang)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tipebarang")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdateName).HasColumnName("updateName");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("'current_timestamp()'");
            });

            modelBuilder.Entity<Mastercatatan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mastercatatan");

                entity.Property(e => e.Catatan)
                    .HasColumnType("text")
                    .HasColumnName("catatan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodeku)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("kodeku");
            });

            modelBuilder.Entity<Masterchannelsales>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PK_masterchannelsales");
                entity.ToTable("masterchannelsales");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Mastercicilan>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("mastercicilan");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Besarpinjaman)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("besarpinjaman");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodepegawai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepegawai");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Potongdi)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("potongdi")
                    .HasComment("0=gapok,1=komisi");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status")
                    .HasComment("0=belum,1=lunas");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("date")
                    .HasColumnName("tanggal")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<Masterdivisi>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masterdivisi");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Mastergrupnilai>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("mastergrupnilai");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(30)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Mastergudang>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("mastergudang");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Aktif)
                    .IsRequired()
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Boletransit)
                    .HasColumnType("smallint(1)")
                    .HasColumnName("boletransit")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nama)
                    .HasMaxLength(20)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Urut)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("urut")
                    .HasDefaultValueSql("'10'");
            });

            modelBuilder.Entity<Masterharilibur>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masterharilibur");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(100)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("date")
                    .HasColumnName("tanggal")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<Masterinventari>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masterinventaris");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Harga)
                    .HasColumnType("int(11)")
                    .HasColumnName("harga");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(100)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodejenis)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodejenis");

                entity.Property(e => e.Kodepegawai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepegawai");

                entity.Property(e => e.TglPakai)
                    .HasColumnType("date")
                    .HasColumnName("tglPakai")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tglbeli)
                    .HasColumnType("date")
                    .HasColumnName("tglbeli")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<Masterjabatan>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masterjabatan");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Masterjenisinventari>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masterjenisinventaris");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.KodeTipe)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodeTipe");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Masterlevelpelanggan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("masterlevelpelanggan");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(30)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Masterleveltokopedium>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masterleveltokopedia");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Urut)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("urut");
            });

            modelBuilder.Entity<Masternilai>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masternilai");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode");

                entity.Property(e => e.Bobot)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bobot");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Masterpegawai>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masterpegawai");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Akses)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("akses");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(250)
                    .HasColumnName("alamat")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Bpjsbyperush)
                    .HasColumnType("int(11)")
                    .HasColumnName("bpjsbyperush");

                entity.Property(e => e.Bpjsbysendiri)
                    .HasColumnType("int(11)")
                    .HasColumnName("bpjsbysendiri");

                entity.Property(e => e.Bpjstk)
                    .HasColumnType("int(11)")
                    .HasColumnName("bpjstk");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Grupgaji)
                    .HasColumnType("int(11)")
                    .HasColumnName("grupgaji");

                entity.Property(e => e.Grupnilai)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("grupnilai");

                entity.Property(e => e.Jabatan)
                    .HasMaxLength(50)
                    .HasColumnName("jabatan")
                    .HasDefaultValueSql("'''Staff Gudang Bawah'''");

                entity.Property(e => e.KodeAgama)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodeAgama");

                entity.Property(e => e.Kodeatasan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeatasan");

                entity.Property(e => e.Kodedivisi)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodedivisi");

                entity.Property(e => e.Kodejabatan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodejabatan");

                entity.Property(e => e.Kodejamkerja)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodejamkerja");

                entity.Property(e => e.Ktp)
                    .HasMaxLength(16)
                    .HasColumnName("ktp")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Laporan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("laporan");

                entity.Property(e => e.Nama)
                    .HasMaxLength(30)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Npwp)
                    .HasMaxLength(20)
                    .HasColumnName("npwp")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .HasColumnName("pass")
                    .HasDefaultValueSql("'''akucintadoran'''");

                entity.Property(e => e.Pengiriman).HasColumnName("pengiriman");

                entity.Property(e => e.Rek)
                    .HasMaxLength(20)
                    .HasColumnName("rek")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Sidikjari)
                    .HasColumnType("text")
                    .HasColumnName("sidikjari")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Telp)
                    .HasMaxLength(20)
                    .HasColumnName("telp")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Tgljoin)
                    .HasColumnType("date")
                    .HasColumnName("tgljoin")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tgllahir)
                    .HasColumnType("date")
                    .HasColumnName("tgllahir")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<Masterpelanggan>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masterpelanggan");

                entity.HasIndex(e => e.Kota, "kode");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Adminhp)
                    .HasMaxLength(30)
                    .HasColumnName("adminhp")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Adminnama)
                    .HasMaxLength(50)
                    .HasColumnName("adminnama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Adminpinbbm)
                    .HasMaxLength(20)
                    .HasColumnName("adminpinbbm")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif");

                entity.Property(e => e.BatasOmzet)
                    .HasColumnType("int(11)")
                    .HasColumnName("batasOmzet");

                entity.Property(e => e.Caranagih)
                    .HasMaxLength(100)
                    .HasColumnName("caranagih")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Cpemail1)
                    .HasMaxLength(30)
                    .HasColumnName("cpemail1")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Cpemail2)
                    .HasMaxLength(30)
                    .HasColumnName("cpemail2")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Cpemail3)
                    .HasMaxLength(150)
                    .HasColumnName("cpemail3")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Cphp1)
                    .HasMaxLength(30)
                    .HasColumnName("cphp1")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Cphp2)
                    .HasMaxLength(30)
                    .HasColumnName("cphp2")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Cphp3)
                    .HasMaxLength(30)
                    .HasColumnName("cphp3")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Cpjabatan1)
                    .HasMaxLength(20)
                    .HasColumnName("cpjabatan1")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Cpjabatan2)
                    .HasMaxLength(20)
                    .HasColumnName("cpjabatan2")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Cpjabatan3)
                    .HasMaxLength(20)
                    .HasColumnName("cpjabatan3")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Cpnama1)
                    .HasMaxLength(30)
                    .HasColumnName("cpnama1")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Cpnama2)
                    .HasMaxLength(30)
                    .HasColumnName("cpnama2")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Cpnama3)
                    .HasMaxLength(30)
                    .HasColumnName("cpnama3")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.DefaultPpn)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("defaultPPN")
                    .HasComment("0=tidak,1=ppn");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Fotoform)
                    .HasMaxLength(80)
                    .HasColumnName("fotoform")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Fotoktp)
                    .HasMaxLength(80)
                    .HasColumnName("fotoktp")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Fototoko)
                    .HasMaxLength(80)
                    .HasColumnName("fototoko")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.InsertName).HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jenisusaha).HasColumnName("jenisusaha");

                entity.Property(e => e.Jumlahlimit)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlahlimit");

                entity.Property(e => e.Kirimmelalui)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kirimmelalui");

                entity.Property(e => e.Kodeareapengiriman)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodeareapengiriman");

                entity.Property(e => e.Kodecoa4)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa4");

                entity.Property(e => e.Kodegroup)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodegroup");

                entity.Property(e => e.Kodelevel)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodelevel");

                entity.Property(e => e.Kodelevelharga)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodelevelharga")
                    .HasComment("UNTUK KODE LEVEL HARGA ONLINE");

                entity.Property(e => e.KodelevelhargaJete)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodelevelhargaJETE")
                    .HasDefaultValueSql("'3'");

                entity.Property(e => e.Kodeleveltokopedia)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodeleveltokopedia");

                entity.Property(e => e.Kota)
                    .HasColumnType("int(11)")
                    .HasColumnName("kota");

                entity.Property(e => e.KursKomisi)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("kursKomisi")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Lamakredit)
                    .HasMaxLength(2)
                    .HasColumnName("lamakredit")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Linktoko)
                    .HasMaxLength(250)
                    .HasColumnName("linktoko")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Lokasi)
                    .HasMaxLength(100)
                    .HasColumnName("lokasi")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.NamaPemilik)
                    .HasMaxLength(30)
                    .HasColumnName("namaPemilik")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Namaformal)
                    .HasMaxLength(50)
                    .HasColumnName("namaformal")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Npwp)
                    .HasMaxLength(30)
                    .HasColumnName("npwp")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Panggilan)
                    .HasMaxLength(5)
                    .HasColumnName("panggilan")
                    .HasDefaultValueSql("'''Bos'''");

                entity.Property(e => e.Pemilikalamat)
                    .HasMaxLength(250)
                    .HasColumnName("pemilikalamat")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Pemilikhp)
                    .HasMaxLength(50)
                    .HasColumnName("pemilikhp")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Pemilikpinbbm)
                    .HasMaxLength(20)
                    .HasColumnName("pemilikpinbbm")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Pemiliktelp)
                    .HasMaxLength(50)
                    .HasColumnName("pemiliktelp")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Potongan).HasColumnName("potongan");

                entity.Property(e => e.Provinsi)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("provinsi");

                entity.Property(e => e.Punyaform).HasColumnName("punyaform");

                entity.Property(e => e.Punyapinbbm).HasColumnName("punyapinbbm");

                entity.Property(e => e.Salespemilik)
                    .HasColumnType("int(11)")
                    .HasColumnName("salespemilik");

                entity.Property(e => e.Sewa1)
                    .HasColumnType("date")
                    .HasColumnName("sewa1")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Sewa2)
                    .HasColumnType("date")
                    .HasColumnName("sewa2")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Showultah).HasColumnName("showultah");

                entity.Property(e => e.Statustempatusaha).HasColumnName("statustempatusaha");

                entity.Property(e => e.TargetAdmin)
                    .IsRequired()
                    .HasColumnName("targetAdmin")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TglLahir)
                    .HasColumnType("date")
                    .HasColumnName("tglLahir")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tglberdiri)
                    .HasColumnType("date")
                    .HasColumnName("tglberdiri")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Tipeakun)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tipeakun")
                    .HasComment("0=Masterpelanggan, 1=AKun Pelengkap buat jurnal");

                entity.Property(e => e.Tipepembayaran).HasColumnName("tipepembayaran");

                entity.Property(e => e.Tipetrans).HasColumnName("tipetrans");

                entity.Property(e => e.Tokoalamatkirim)
                    .HasMaxLength(250)
                    .HasColumnName("tokoalamatkirim")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Tokoalamatlengkap)
                    .HasMaxLength(250)
                    .HasColumnName("tokoalamatlengkap")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Tokoexp)
                    .HasColumnType("int(11)")
                    .HasColumnName("tokoexp");

                entity.Property(e => e.Tokohp)
                    .HasMaxLength(50)
                    .HasColumnName("tokohp")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Tokopinbbm)
                    .HasMaxLength(20)
                    .HasColumnName("tokopinbbm")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Tokotelp)
                    .HasMaxLength(50)
                    .HasColumnName("tokotelp")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.UpdateName).HasColumnName("updateName");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Urutpelanggan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("urutpelanggan");
            });

            modelBuilder.Entity<Masterpemasukan>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masterpemasukan");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Kodecoa4)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa4")
                    .HasDefaultValueSql("'125002'");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.NomorCicilan)
                    .HasColumnType("int(11)")
                    .HasColumnName("nomorCicilan");

                entity.Property(e => e.Sales)
                    .HasColumnType("int(11)")
                    .HasColumnName("sales");
            });

            modelBuilder.Entity<Masterpengeluaran>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masterpengeluaran");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.AdaBarcode)
                    .IsRequired()
                    .HasColumnName("adaBarcode")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Cargo).HasColumnName("cargo");

                entity.Property(e => e.HarusInputNoHp)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("harusInputNoHP")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.JenisKas)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jenisKas");

                entity.Property(e => e.JenisUk)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jenisUK")
                    .HasComment("0=UK, 1=Cicilan");

                entity.Property(e => e.Kodeareapengiriman)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodeareapengiriman");

                entity.Property(e => e.Kodecoa4)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa4");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.NomorCicilan)
                    .HasColumnType("int(11)")
                    .HasColumnName("nomorCicilan");

                entity.Property(e => e.OllangusungCetak)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("OLLangusungCetak")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Sales)
                    .HasColumnType("int(11)")
                    .HasColumnName("sales");

                entity.Property(e => e.Telpekspedisi)
                    .HasMaxLength(50)
                    .HasColumnName("telpekspedisi")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Masterpoinaward>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("masterpoinaward");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode");

                entity.Property(e => e.Aktif)
                    .IsRequired()
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Urut)
                    .IsRequired()
                    .HasColumnName("urut")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<Mastersupplier>(entity =>
            {
                entity.HasKey(e => e.SupplierKode)
                    .HasName("PRIMARY");

                entity.ToTable("mastersupplier");

                entity.Property(e => e.SupplierKode)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("supplierKode");

                entity.Property(e => e.Distiresmi)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("distiresmi");

                entity.Property(e => e.EmailBarangHabis)
                    .HasMaxLength(200)
                    .HasColumnName("emailBarangHabis")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.InsertName).HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jurnalbeli)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jurnalbeli")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Kodecoa4)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa4");

                entity.Property(e => e.Namalengkap)
                    .HasMaxLength(100)
                    .HasColumnName("namalengkap")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Npwp)
                    .HasMaxLength(20)
                    .HasColumnName("npwp")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Rekening)
                    .HasMaxLength(30)
                    .HasColumnName("rekening")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.SupplierAktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("supplierAktif");

                entity.Property(e => e.SupplierNama)
                    .HasMaxLength(50)
                    .HasColumnName("supplierNama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.UpdateName).HasColumnName("updateName");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Mastersuppliercina>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("mastersuppliercina");

                entity.Property(e => e.Kode)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kode");

                entity.Property(e => e.Aktif)
                    .IsRequired()
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Mastertarget>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("mastertarget");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Bonus)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonus");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(200)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodepelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepelanggan");

                entity.Property(e => e.Kodepengirim)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepengirim");

                entity.Property(e => e.Kodesales)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodesales");

                entity.Property(e => e.Kota)
                    .HasColumnType("int(11)")
                    .HasColumnName("kota");

                entity.Property(e => e.Kp2)
                    .HasColumnType("int(11)")
                    .HasColumnName("kp2");

                entity.Property(e => e.Kp3)
                    .HasColumnType("int(11)")
                    .HasColumnName("kp3");

                entity.Property(e => e.Provinsi)
                    .HasColumnType("int(11)")
                    .HasColumnName("provinsi");

                entity.Property(e => e.Target)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("target");

                entity.Property(e => e.Tim)
                    .HasMaxLength(50)
                    .HasColumnName("tim")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Urut)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("urut");
            });

            modelBuilder.Entity<Mastertargettahunan>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("mastertargettahunan");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Bulan)
                    .HasColumnType("int(11)")
                    .HasColumnName("bulan");

                entity.Property(e => e.Jenis)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jenis");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(200)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.KodeKategoriBarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeKategoriBarang");

                entity.Property(e => e.Kota)
                    .HasColumnType("int(11)")
                    .HasColumnName("kota");

                entity.Property(e => e.Provinsi)
                    .HasColumnType("int(11)")
                    .HasColumnName("provinsi");

                entity.Property(e => e.Sales)
                    .HasColumnType("tinyint(11)")
                    .HasColumnName("sales");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");

                entity.Property(e => e.Target)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("target");
            });

            modelBuilder.Entity<Mastertimsales>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("mastertimsales");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Kodechannel)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodechannel");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.SyaratKomisi)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("syaratKomisi");

                entity.Property(e => e.Tampiltahunlalu)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tampiltahunlalu");

                entity.Property(e => e.Targetjete)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("targetjete");

                entity.Property(e => e.Targetomzet)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("targetomzet");
            });

            modelBuilder.Entity<Mastertipebarang>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("mastertipebarang");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(40)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Shownya)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("shownya")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Urut)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("urut");
            });

            modelBuilder.Entity<Mastertipeinventari>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("mastertipeinventaris");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nama)
                    .HasMaxLength(30)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Mastertipetuga>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("mastertipetugas");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kode");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Mastertuga>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("mastertugas");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Cycle).HasColumnName("cycle");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(200)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Minlevel)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("minlevel");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Poin)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("poin");

                entity.Property(e => e.Prioritas)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("prioritas");

                entity.Property(e => e.Tipetugas)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tipetugas");

                entity.Property(e => e.Urut)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("urut");
            });

            modelBuilder.Entity<Masteruser>(entity =>
            {
                entity.HasKey(e => e.Kodeku)
                    .HasName("PK_masteruser");

                entity.ToTable("masteruser");

                entity.Property(e => e.Kodeku)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeku");

                entity.Property(e => e.Akses)
                    .HasMaxLength(20)
                    .HasColumnName("akses")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Kodesales)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodesales")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Passwordku)
                    .HasMaxLength(30)
                    .HasColumnName("passwordku")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Sidikjari)
                    .HasColumnType("text")
                    .HasColumnName("sidikjari")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Usernameku)
                    .HasMaxLength(20)
                    .HasColumnName("usernameku")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Masteruserretur>(entity =>
            {
                entity.HasKey(e => e.Kodeku)
                    .HasName("PRIMARY");

                entity.ToTable("masteruserretur");

                entity.Property(e => e.Kodeku).HasColumnName("kodeku");

                entity.Property(e => e.Akses)
                    .HasMaxLength(20)
                    .HasColumnName("akses")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Passwordku)
                    .HasMaxLength(20)
                    .HasColumnName("passwordku")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Usernameku)
                    .HasMaxLength(20)
                    .HasColumnName("usernameku")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Memostok>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("memostok");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodebrg)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebrg");

                entity.Property(e => e.Kodegudang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodegudang");

                entity.Property(e => e.Tgl)
                    .HasColumnType("date")
                    .HasColumnName("tgl")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<Penandajurnal>(entity =>
            {
                entity.HasKey(e => e.Kodeh)
                    .HasName("PRIMARY");

                entity.ToTable("penandajurnal");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Bank)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bank");

                entity.Property(e => e.Baranggratis)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("baranggratis");

                entity.Property(e => e.Barangretur)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("barangretur");

                entity.Property(e => e.Beli)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("beli");

                entity.Property(e => e.Bulan)
                    .HasColumnType("int(11)")
                    .HasColumnName("bulan");

                entity.Property(e => e.Jual)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jual");

                entity.Property(e => e.Kaskeluar)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kaskeluar");

                entity.Property(e => e.Kasmasuk)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kasmasuk");

                entity.Property(e => e.Lr)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("LR");

                entity.Property(e => e.Memogaji)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("memogaji");

                entity.Property(e => e.Memokomisi)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("memokomisi");

                entity.Property(e => e.Memopengeluarantambahan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("memopengeluarantambahan");

                entity.Property(e => e.NameLr)
                    .HasColumnType("int(11)")
                    .HasColumnName("nameLR");

                entity.Property(e => e.NameNeraca)
                    .HasColumnType("int(11)")
                    .HasColumnName("nameNeraca");

                entity.Property(e => e.NameOngkirNetral).HasColumnType("int(11)");

                entity.Property(e => e.Namebank).HasColumnType("int(11)");

                entity.Property(e => e.Namebaranggratis).HasColumnType("int(11)");

                entity.Property(e => e.Namebarangretur).HasColumnType("int(11)");

                entity.Property(e => e.Namebeli).HasColumnType("int(11)");

                entity.Property(e => e.Namejual).HasColumnType("int(11)");

                entity.Property(e => e.Namekaskeluar).HasColumnType("int(11)");

                entity.Property(e => e.Namekasmasuk).HasColumnType("int(11)");

                entity.Property(e => e.Namememogaji).HasColumnType("int(11)");

                entity.Property(e => e.Namememokomisi).HasColumnType("int(11)");

                entity.Property(e => e.Namememopengeluarantambahan).HasColumnType("int(11)");

                entity.Property(e => e.Nameongkirkepelanggan).HasColumnType("int(11)");

                entity.Property(e => e.Neraca)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("neraca");

                entity.Property(e => e.OngkirNetral).HasColumnType("tinyint(4)");

                entity.Property(e => e.Ongkirkepelanggan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("ongkirkepelanggan");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");

                entity.Property(e => e.TimeLr)
                    .HasColumnType("datetime")
                    .HasColumnName("timeLR")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.TimeNeraca)
                    .HasColumnType("datetime")
                    .HasColumnName("timeNeraca")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.TimeOngkirNetral)
                    .HasColumnType("datetime")
                    .HasColumnName("timeOngkirNetral")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Timebank)
                    .HasColumnType("datetime")
                    .HasColumnName("timebank")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Timebaranggratis)
                    .HasColumnType("datetime")
                    .HasColumnName("timebaranggratis")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Timebarangretur)
                    .HasColumnType("datetime")
                    .HasColumnName("timebarangretur")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Timebeli)
                    .HasColumnType("datetime")
                    .HasColumnName("timebeli")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Timejual)
                    .HasColumnType("datetime")
                    .HasColumnName("timejual")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Timekaskeluar)
                    .HasColumnType("datetime")
                    .HasColumnName("timekaskeluar")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Timekasmasuk)
                    .HasColumnType("datetime")
                    .HasColumnName("timekasmasuk")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Timememogaji)
                    .HasColumnType("datetime")
                    .HasColumnName("timememogaji")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Timememokomisi)
                    .HasColumnType("datetime")
                    .HasColumnName("timememokomisi")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Timememopengeluarantambahan)
                    .HasColumnType("datetime")
                    .HasColumnName("timememopengeluarantambahan")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Timeongkirkepelanggan)
                    .HasColumnType("datetime")
                    .HasColumnName("timeongkirkepelanggan")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Penyiaporder>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("penyiaporder");

                entity.Property(e => e.Kode)
                    .HasColumnType("tinyint(3)")
                    .HasColumnName("kode");

                entity.Property(e => e.Aktif)
                    .IsRequired()
                    .HasColumnName("aktif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nama)
                    .HasMaxLength(20)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Potonganbarangkurang>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("potonganbarangkurang");

                entity.Property(e => e.Bulan)
                    .HasColumnType("int(11)")
                    .HasColumnName("bulan");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodepegawai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepegawai");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status")
                    .HasComment("0=belum,1=sudahdipotonggaji");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");
            });

            modelBuilder.Entity<Profileperush>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("profileperush");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Akhirjamlaporan).HasColumnName("akhirjamlaporan");

                entity.Property(e => e.Footer1)
                    .HasMaxLength(50)
                    .HasColumnName("footer1");

                entity.Property(e => e.Footer2)
                    .HasMaxLength(50)
                    .HasColumnName("footer2");

                entity.Property(e => e.Footer3)
                    .HasMaxLength(50)
                    .HasColumnName("footer3");

                entity.Property(e => e.Footer4)
                    .HasMaxLength(50)
                    .HasColumnName("footer4");

                entity.Property(e => e.Header1)
                    .HasMaxLength(50)
                    .HasColumnName("header1");

                entity.Property(e => e.Header2)
                    .HasMaxLength(50)
                    .HasColumnName("header2");

                entity.Property(e => e.Header3)
                    .HasMaxLength(50)
                    .HasColumnName("header3");

                entity.Property(e => e.JamHabis)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jamHabis")
                    .HasDefaultValueSql("'16'");

                entity.Property(e => e.JamTenggang)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jamTenggang")
                    .HasDefaultValueSql("'18'");

                entity.Property(e => e.KodePenyiap)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodePenyiap");

                entity.Property(e => e.Kodebonusarea)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodebonusarea");

                entity.Property(e => e.Memobonusjete).HasColumnName("memobonusjete");

                entity.Property(e => e.MenitHabis)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("menitHabis")
                    .HasDefaultValueSql("'45'");

                entity.Property(e => e.MenitTenggang)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("menitTenggang")
                    .HasDefaultValueSql("'59'");

                entity.Property(e => e.Minbonusarea)
                    .HasColumnType("int(11)")
                    .HasColumnName("minbonusarea");

                entity.Property(e => e.NamaProgram)
                    .HasMaxLength(50)
                    .HasColumnName("namaProgram");

                entity.Property(e => e.OmzetMin)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("omzetMin");

                entity.Property(e => e.Profdibagi)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("profdibagi");

                entity.Property(e => e.Profmin)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("profmin");

                entity.Property(e => e.TargetAdmin)
                    .HasColumnType("int(11)")
                    .HasColumnName("targetAdmin");

                entity.Property(e => e.TglLogitech)
                    .HasColumnType("date")
                    .HasColumnName("tglLogitech");

                entity.Property(e => e.TglSandisk)
                    .HasColumnType("date")
                    .HasColumnName("tglSandisk");

                entity.Property(e => e.TglWd)
                    .HasColumnType("date")
                    .HasColumnName("tglWD");

                entity.Property(e => e.Tglseagate)
                    .HasColumnType("date")
                    .HasColumnName("tglseagate");

                entity.Property(e => e.Tgltplink)
                    .HasColumnType("date")
                    .HasColumnName("tgltplink");

                entity.Property(e => e.Versicekorder)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("versicekorder");

                entity.Property(e => e.Versiprogram)
                    .HasColumnType("int(11)")
                    .HasColumnName("versiprogram");

                entity.Property(e => e.Versiprogramjtol)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("versiprogramjtol");

                entity.Property(e => e.Versiprogrampengiriman)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("versiprogrampengiriman");

                entity.Property(e => e.Versiprogramreturan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("versiprogramreturan");

                entity.Property(e => e.Versipujian)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("versipujian");
            });

            modelBuilder.Entity<Rumushargaonline>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("rumushargaonline");

                entity.Property(e => e.Hgrosir).HasColumnName("hgrosir");

                entity.Property(e => e.Hofficial).HasColumnName("hofficial");

                entity.Property(e => e.Hpromo).HasColumnName("hpromo");

                entity.Property(e => e.KodeBrand)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeBrand");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("sales");

                entity.HasIndex(e => e.Kodetimsales, "kodetimsales");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Aktif)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("aktif");

                entity.Property(e => e.Bisalihatomzettahunantim)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bisalihatomzettahunantim");

                entity.Property(e => e.BonusJete)
                    .HasColumnType("int(11)")
                    .HasColumnName("bonusJETE")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.EmailJeteterdahsyat)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("emailJETETerdahsyat");

                entity.Property(e => e.EmailOmzetTerdahsyat)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("emailOmzetTerdahsyat");

                entity.Property(e => e.EmailTargetTahunan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("emailTargetTahunan");

                entity.Property(e => e.Emailbos)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("emailbos");

                entity.Property(e => e.Emailresikiriman)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("emailresikiriman");

                entity.Property(e => e.Emailspv)
                    .HasMaxLength(100)
                    .HasColumnName("emailspv");

                entity.Property(e => e.Jenis)
                    .HasColumnName("jenis")
                    .HasComment("1 = Terima Email OMZET");

                entity.Property(e => e.Kodemanager)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodemanager");

                entity.Property(e => e.Kodepegawai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepegawai");

                entity.Property(e => e.Kodetimsales)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodetimsales")
                    .HasDefaultValueSql("'12'");

                entity.Property(e => e.Manager)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("manager");

                entity.Property(e => e.Nama)
                    .HasMaxLength(20)
                    .HasColumnName("nama");

                entity.Property(e => e.NamaPendamping)
                    .HasMaxLength(20)
                    .HasColumnName("namaPendamping");

                entity.Property(e => e.Persenbonus)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("persenbonus");

                entity.Property(e => e.Persenkomisi)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("persenkomisi");

                entity.Property(e => e.Salesol)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("salesol");

                entity.Property(e => e.Syaratbonus)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("syaratbonus");

                entity.Property(e => e.T1)
                    .HasColumnType("int(11)")
                    .HasColumnName("t1");

                entity.Property(e => e.T2)
                    .HasColumnType("int(11)")
                    .HasColumnName("t2");

                entity.Property(e => e.T3)
                    .HasColumnType("int(11)")
                    .HasColumnName("t3");

                entity.Property(e => e.T4)
                    .HasColumnType("int(11)")
                    .HasColumnName("t4");

                entity.Property(e => e.T5)
                    .HasColumnType("int(11)")
                    .HasColumnName("t5");

                entity.Property(e => e.Tim)
                    .HasMaxLength(100)
                    .HasColumnName("tim");

                entity.Property(e => e.Tipe)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tipe");

                entity.Property(e => e.Urutan)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("urutan");
            });

            modelBuilder.Entity<Sethargajual>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("sethargajual");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Harga)
                    .HasColumnType("int(11)")
                    .HasColumnName("harga");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Kodelevel)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodelevel");
            });

            modelBuilder.Entity<Sethargalevel>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("sethargalevel");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.AcuanPotong).HasColumnName("acuanPotong");

                entity.Property(e => e.AcuanTambah).HasColumnName("acuanTambah");

                entity.Property(e => e.Modal)
                    .HasColumnType("int(11)")
                    .HasColumnName("modal");

                entity.Property(e => e.Nama)
                    .HasMaxLength(150)
                    .HasColumnName("nama")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Online)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("online");

                entity.Property(e => e.Urutan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("urutan")
                    .HasDefaultValueSql("'10'");
            });

            modelBuilder.Entity<Sethargatoko>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("sethargatoko");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Kodebrand)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebrand");

                entity.Property(e => e.Kodelevel)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodelevel");

                entity.Property(e => e.Kodepelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepelanggan");
            });

            modelBuilder.Entity<Simpanbonusjete>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("simpanbonusjete");

                entity.Property(e => e.Bulan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bulan");

                entity.Property(e => e.History)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("history");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodesales)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodesales");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");
            });

            modelBuilder.Entity<Simpandendalainnya>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("simpandendalainnya");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Bulan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bulan");

                entity.Property(e => e.History)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("history");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Kodepegawai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepegawai");

                entity.Property(e => e.Namadenda)
                    .HasMaxLength(100)
                    .HasColumnName("namadenda")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");
            });

            modelBuilder.Entity<Simpandendum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("simpandenda");

                entity.Property(e => e.Besardenda)
                    .HasColumnType("int(11)")
                    .HasColumnName("besardenda");

                entity.Property(e => e.Bulan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bulan");

                entity.Property(e => e.Dendabriefing)
                    .HasColumnType("int(11)")
                    .HasColumnName("dendabriefing");

                entity.Property(e => e.History)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("history");

                entity.Property(e => e.Jumhadir)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumhadir");

                entity.Property(e => e.Jumharikerja)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumharikerja");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Jumpulanglebihawal)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumpulanglebihawal");

                entity.Property(e => e.Kodepegawai)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepegawai");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");

                entity.Property(e => e.Telat)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("telat");

                entity.Property(e => e.Tidakmasuk)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tidakmasuk");
            });

            modelBuilder.Entity<Syaratbonusjete>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("syaratbonusjete");

                entity.HasIndex(e => e.Kodebrg, "kodebrg");

                entity.Property(e => e.Bulan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bulan");

                entity.Property(e => e.Jenis)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jenis")
                    .HasComment("0=kodekat,1=kodebrg,2=namabrg");

                entity.Property(e => e.Kodebrg)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebrg");

                entity.Property(e => e.Sinonim)
                    .HasMaxLength(100)
                    .HasColumnName("sinonim");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");

                entity.Property(e => e.Target)
                    .HasColumnType("int(11)")
                    .HasColumnName("target");
            });

            modelBuilder.Entity<Syaratkomisi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("syaratkomisi");

                entity.Property(e => e.Bulan)
                    .HasColumnType("int(11)")
                    .HasColumnName("bulan");

                entity.Property(e => e.GapokAdmin)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("gapokAdmin");

                entity.Property(e => e.GapokAdminKet)
                    .HasMaxLength(200)
                    .HasColumnName("gapokAdminKet");

                entity.Property(e => e.GapokManager)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("gapokManager");

                entity.Property(e => e.GapokManagerKet)
                    .HasMaxLength(200)
                    .HasColumnName("gapokManagerKet");

                entity.Property(e => e.GapokNotaBlok)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("gapokNotaBlok");

                entity.Property(e => e.GapokNotaBlokKet)
                    .HasMaxLength(200)
                    .HasColumnName("gapokNotaBlokKet");

                entity.Property(e => e.GapokNotaTrans)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("gapokNotaTrans");

                entity.Property(e => e.GapokNotaTransKet)
                    .HasMaxLength(200)
                    .HasColumnName("gapokNotaTransKet");

                entity.Property(e => e.GapokPembelian)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("gapokPembelian");

                entity.Property(e => e.GapokPembelianKet)
                    .HasMaxLength(200)
                    .HasColumnName("gapokPembelianKet");

                entity.Property(e => e.GapokTagTitip)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("gapokTagTitip");

                entity.Property(e => e.GapokTagTitipKet)
                    .HasMaxLength(200)
                    .HasColumnName("gapokTagTitipKet");

                entity.Property(e => e.GapokTarget)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("gapokTarget");

                entity.Property(e => e.Kodesales)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodesales");

                entity.Property(e => e.KomisiAdmin)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("komisiAdmin");

                entity.Property(e => e.KomisiAdminKet)
                    .HasMaxLength(200)
                    .HasColumnName("komisiAdminKet");

                entity.Property(e => e.KomisiDoranCare)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("komisiDoranCare");

                entity.Property(e => e.KomisiDoranCareKet)
                    .HasMaxLength(200)
                    .HasColumnName("komisiDoranCareKet");

                entity.Property(e => e.KomisiEvaluasi)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("komisiEvaluasi");

                entity.Property(e => e.KomisiKoper)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("komisiKoper");

                entity.Property(e => e.KomisiKoperket)
                    .HasMaxLength(200)
                    .HasColumnName("komisiKoperket");

                entity.Property(e => e.KomisiManager)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("komisiManager");

                entity.Property(e => e.KomisiManagerKet)
                    .HasMaxLength(200)
                    .HasColumnName("komisiManagerKet");

                entity.Property(e => e.KomisiNotaBlok)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("komisiNotaBlok");

                entity.Property(e => e.KomisiNotaBlokKet)
                    .HasMaxLength(200)
                    .HasColumnName("komisiNotaBlokKet");

                entity.Property(e => e.KomisiNotaTrans)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("komisiNotaTrans");

                entity.Property(e => e.KomisiNotaTransKet)
                    .HasMaxLength(200)
                    .HasColumnName("komisiNotaTransKet");

                entity.Property(e => e.KomisiPembelian)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("komisiPembelian");

                entity.Property(e => e.KomisiPembelianKet)
                    .HasMaxLength(200)
                    .HasColumnName("komisiPembelianKet");

                entity.Property(e => e.KomisiTagTitip)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("komisiTagTitip");

                entity.Property(e => e.KomisiTagTitipKet)
                    .HasMaxLength(200)
                    .HasColumnName("komisiTagTitipKet");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");
            });

            modelBuilder.Entity<Syarattargetarea>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("syarattargetarea");

                entity.Property(e => e.Bulan)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bulan");

                entity.Property(e => e.Jenis)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jenis")
                    .HasComment("0=kodekat,1=kodebrg,2=namabrg");

                entity.Property(e => e.Kodebrg)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebrg");

                entity.Property(e => e.Sinonim)
                    .HasMaxLength(100)
                    .HasColumnName("sinonim");

                entity.Property(e => e.Tahun)
                    .HasColumnType("int(11)")
                    .HasColumnName("tahun");

                entity.Property(e => e.Target)
                    .HasColumnType("int(11)")
                    .HasColumnName("target");
            });

            modelBuilder.Entity<Tagihan>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("tagihan");

                entity.HasIndex(e => e.KodeTotalSetoran, "kodeTotalSetoran");

                entity.HasIndex(e => e.Kodeh, "kodeh");

                entity.HasIndex(e => e.Kodehlunasinmassal, "kodehlunasinmassal");

                entity.HasIndex(e => e.Kodett, "kodett");

                entity.HasIndex(e => e.TglAngsur, "tglAngsur");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Dihitung)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("dihitung")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Dihitung dalam detail transfer atau tidak");

                entity.Property(e => e.InsertName).HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(200)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''''''''''");

                entity.Property(e => e.KodeTotalSetoran)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeTotalSetoran");

                entity.Property(e => e.Kodecoa4)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodecoa4");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodehlunasinmassal)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehlunasinmassal");

                entity.Property(e => e.Kodetipeonline)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodetipeonline")
                    .HasComment("Kode jenis bayar dari Market Place");

                entity.Property(e => e.Kodett)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodett");

                entity.Property(e => e.Penagih).HasColumnName("penagih");

                entity.Property(e => e.Periksa)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("periksa")
                    .HasComment("Keperluan Online : Sudah diperiksa valid atau belum");

                entity.Property(e => e.Tessubsiditkpd)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tessubsiditkpd");

                entity.Property(e => e.TglAngsur)
                    .HasColumnType("date")
                    .HasColumnName("tglAngsur")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Transfer)
                    .HasColumnName("transfer")
                    .HasComment("0 = tunai, 1 = transfer");

                entity.Property(e => e.UdaDiSetor)
                    .HasColumnName("udaDiSetor")
                    .HasComment("3 = udaDiCek, 2 = udaDiSetor, 1 0 = belum");
            });

            modelBuilder.Entity<Tagihansupplier>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("tagihansupplier");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Coa4)
                    .HasColumnType("int(11)")
                    .HasColumnName("coa4");

                entity.Property(e => e.InsertName)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("insertName")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(200)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodedetailbayar)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodedetailbayar");

                entity.Property(e => e.Kodehbeli)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodehbeli");

                entity.Property(e => e.Piutang)
                    .HasColumnType("int(11)")
                    .HasColumnName("piutang");
            });

            modelBuilder.Entity<Tagihanvirtual>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("tagihanvirtual");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Insertname)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("insertname");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Kodeh)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeh");

                entity.Property(e => e.Kodett)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodett");
            });

            modelBuilder.Entity<Targetomzettoko>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("targetomzettoko");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Hadiah)
                    .HasMaxLength(100)
                    .HasColumnName("hadiah");

                entity.Property(e => e.Kodepelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepelanggan");

                entity.Property(e => e.Kodesales)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodesales");

                entity.Property(e => e.Omzet)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("omzet");

                entity.Property(e => e.Tglakhir)
                    .HasColumnType("date")
                    .HasColumnName("tglakhir");

                entity.Property(e => e.Tglawal)
                    .HasColumnType("date")
                    .HasColumnName("tglawal");

                entity.Property(e => e.Toko2)
                    .HasColumnType("int(11)")
                    .HasColumnName("toko2");

                entity.Property(e => e.Toko3)
                    .HasColumnType("int(11)")
                    .HasColumnName("toko3");

                entity.Property(e => e.Toko4)
                    .HasColumnType("int(11)")
                    .HasColumnName("toko4");

                entity.Property(e => e.Toko5)
                    .HasColumnType("int(11)")
                    .HasColumnName("toko5");
            });

            modelBuilder.Entity<Targetomzettokojete>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("targetomzettokojete");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Hadiah)
                    .HasMaxLength(100)
                    .HasColumnName("hadiah");

                entity.Property(e => e.Kodepelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepelanggan");

                entity.Property(e => e.Kodesales)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodesales");

                entity.Property(e => e.Omzet)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("omzet");

                entity.Property(e => e.Tglakhir)
                    .HasColumnType("date")
                    .HasColumnName("tglakhir");

                entity.Property(e => e.Tglawal)
                    .HasColumnType("date")
                    .HasColumnName("tglawal");

                entity.Property(e => e.Toko2)
                    .HasColumnType("int(11)")
                    .HasColumnName("toko2");

                entity.Property(e => e.Toko3)
                    .HasColumnType("int(11)")
                    .HasColumnName("toko3");

                entity.Property(e => e.Toko4)
                    .HasColumnType("int(11)")
                    .HasColumnName("toko4");

                entity.Property(e => e.Toko5)
                    .HasColumnType("int(11)")
                    .HasColumnName("toko5");
            });

            modelBuilder.Entity<Targetomzettokopc>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("targetomzettokopcs");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("KODE");

                entity.Property(e => e.Carahitung).HasColumnName("carahitung");

                entity.Property(e => e.Hadiah)
                    .HasMaxLength(100)
                    .HasColumnName("hadiah");

                entity.Property(e => e.Hrgmin)
                    .HasColumnType("int(11)")
                    .HasColumnName("hrgmin");

                entity.Property(e => e.Kodebarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodebarang");

                entity.Property(e => e.Kodepelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepelanggan");

                entity.Property(e => e.Kodesales)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kodesales");

                entity.Property(e => e.Namasinonim)
                    .HasMaxLength(150)
                    .HasColumnName("namasinonim");

                entity.Property(e => e.Target)
                    .HasColumnType("int(11)")
                    .HasColumnName("target");

                entity.Property(e => e.Tglakhir)
                    .HasColumnType("date")
                    .HasColumnName("tglakhir");

                entity.Property(e => e.Tglawal)
                    .HasColumnType("date")
                    .HasColumnName("tglawal");

                entity.Property(e => e.Toko2)
                    .HasColumnType("int(11)")
                    .HasColumnName("toko2");

                entity.Property(e => e.Toko3)
                    .HasColumnType("int(11)")
                    .HasColumnName("toko3");

                entity.Property(e => e.Toko4)
                    .HasColumnType("int(11)")
                    .HasColumnName("toko4");

                entity.Property(e => e.Toko5)
                    .HasColumnType("int(11)")
                    .HasColumnName("toko5");
            });

            modelBuilder.Entity<Totalsetoran>(entity =>
            {
                entity.HasKey(e => e.KodeTotalSetoran)
                    .HasName("PRIMARY");

                entity.ToTable("totalsetoran");

                entity.Property(e => e.KodeTotalSetoran)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeTotalSetoran");

                entity.Property(e => e.Jum1).HasColumnType("int(11)");

                entity.Property(e => e.Jum2).HasColumnType("int(11)");

                entity.Property(e => e.Jum3).HasColumnType("int(11)");

                entity.Property(e => e.Jum4).HasColumnType("int(11)");

                entity.Property(e => e.Ket1)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Ket2)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Ket3)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Ket4)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodetotalsetoranglobal)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodetotalsetoranglobal");

                entity.Property(e => e.Setor).HasColumnName("setor");

                entity.Property(e => e.TglSetoran)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.TotalSetoran1)
                    .HasColumnType("int(11)")
                    .HasColumnName("TotalSetoran");
            });

            modelBuilder.Entity<Totalsetoranglobal>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("totalsetoranglobal");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.InsertName)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Jumlahakhir)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlahakhir");

                entity.Property(e => e.Kodett)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodett");

                entity.Property(e => e.Penerima)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("penerima");

                entity.Property(e => e.Setor).HasColumnName("setor");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("date")
                    .HasColumnName("tanggal")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.TglTerima)
                    .HasColumnType("datetime")
                    .HasColumnName("tglTerima")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Tglsetor)
                    .HasColumnType("date")
                    .HasColumnName("tglsetor")
                    .HasDefaultValueSql("'''0000-00-00'''");
            });

            modelBuilder.Entity<Transaksipemasukan>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("transaksipemasukan");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.InsertName)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(30)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.KodePemasukan)
                    .HasColumnType("int(4)")
                    .HasColumnName("kodePemasukan");

                entity.Property(e => e.KodeTotalSetoran)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeTotalSetoran");

                entity.Property(e => e.Kodetotalsetoranglobal)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodetotalsetoranglobal");

                entity.Property(e => e.Setor)
                    .HasColumnName("setor")
                    .HasComment("0 1 Admin, 2 Jhonny");

                entity.Property(e => e.TglPemasukan)
                    .HasColumnType("date")
                    .HasColumnName("tglPemasukan")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.UpdateName)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("updateName");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("'current_timestamp()'");
            });

            modelBuilder.Entity<Transaksipengeluaran>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("transaksipengeluaran");

                entity.HasIndex(e => e.Kodetotalsetoranglobal, "kodetotalsetoranglobal");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.Bank)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("bank")
                    .HasComment("0=tunai,1=bank");

                entity.Property(e => e.InsertName)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("insertName");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.JenisPengeluaran)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("jenisPengeluaran")
                    .HasComment("0 Normal, 1 Cargo Masuk, 2 Setoran, 3 Cargo Keluar");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.JumlahLainnya)
                    .HasColumnType("int(11)")
                    .HasColumnName("jumlahLainnya");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(300)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.KodePengeluaran)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodePengeluaran");

                entity.Property(e => e.KodeTotalSetoran)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeTotalSetoran");

                entity.Property(e => e.Kodetotalsetoranglobal)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodetotalsetoranglobal");

                entity.Property(e => e.Setor)
                    .HasColumnName("setor")
                    .HasComment("0 1 Admin, 2 Master Admin, 3 Jhonny");

                entity.Property(e => e.Sudahjurnal)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("sudahjurnal")
                    .HasComment("0=belum,1=sudah");

                entity.Property(e => e.TglPengeluaran)
                    .HasColumnType("date")
                    .HasColumnName("tglPengeluaran")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.UpdateName)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("updateName");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");
            });

            modelBuilder.Entity<Ttkeluar>(entity =>
            {
                entity.HasKey(e => e.Kodett)
                    .HasName("PRIMARY");

                entity.ToTable("ttkeluar");

                entity.Property(e => e.Kodett)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodett");

                entity.Property(e => e.Kodepenggunaan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepenggunaan")
                    .HasComment("kode lookup");

                entity.Property(e => e.Kodepenggunaan2)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepenggunaan2");

                entity.Property(e => e.Tipe)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("tipe")
                    .HasComment("0=tag,1=biaya,2=gaji");
            });

            modelBuilder.Entity<Ttmasuk>(entity =>
            {
                entity.HasKey(e => e.Kode)
                    .HasName("PRIMARY");

                entity.ToTable("ttmasuk");

                entity.HasIndex(e => e.Kodebank, "kodebank");

                entity.HasIndex(e => e.Kreditdebit, "kreditdebit");

                entity.HasIndex(e => e.Tgl, "tgl");

                entity.Property(e => e.Kode)
                    .HasColumnType("int(11)")
                    .HasColumnName("kode");

                entity.Property(e => e.History)
                    .HasColumnName("history")
                    .HasComment("0=belum, 1=beres, 2=dicekJhonny");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .HasColumnName("insertTime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Insertname)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("insertname");

                entity.Property(e => e.Jumlah)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("jumlah");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(100)
                    .HasColumnName("keterangan")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Kodebank).HasColumnName("kodebank");

                entity.Property(e => e.Kodeonline)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodeonline");

                entity.Property(e => e.Kodepelanggan)
                    .HasColumnType("int(11)")
                    .HasColumnName("kodepelanggan");

                entity.Property(e => e.Kreditdebit)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("kreditdebit")
                    .HasComment("0=Kredit,1=Debit");

                entity.Property(e => e.Tgl)
                    .HasColumnType("date")
                    .HasColumnName("tgl")
                    .HasDefaultValueSql("'''0000-00-00'''");

                entity.Property(e => e.Updatename)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("updatename");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("updatetime")
                    .HasDefaultValueSql("'''0000-00-00 00:00:00'''");

                entity.Property(e => e.Urut)
                    .HasColumnType("int(11)")
                    .HasColumnName("urut");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        public void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Masterpegawai>(e =>
            {
                e.HasOne(e => e.Masterdivisi)
                .WithMany(c => c.Masterpegawais)
                .HasForeignKey(x => x.Kodedivisi)
                .HasPrincipalKey(x => x.Kode);

                e.HasOne(e => e.Masterjabatan)
               .WithMany(c => c.Masterpegawais)
               .HasForeignKey(x => x.Kodejabatan)
               .HasPrincipalKey(x => x.Kode);
            });

            modelBuilder.Entity<Mastertimsales>(entity =>
            {
                entity.HasOne(e => e.Masterchannelsales)
                .WithMany(c => c.Mastertimsales)
                .HasForeignKey("Kodechannel");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasOne(e => e.SalesManager)
               .WithOne()
               .HasForeignKey<Sales>(f => f.Kodemanager);

                entity.HasOne(e => e.Mastertimsales)
                .WithMany(c => c.Sales)
                .HasForeignKey("Kodetimsales");
            });

            modelBuilder.Entity<Masteruser>(entity =>
            {
                entity.HasOne(e => e.Sales)
                  .WithOne(c => c.Masteruser)
                  .HasForeignKey<Masteruser>("Kodesales");
            });

            modelBuilder.Entity<Masterpelanggan>(entity =>
            {
                entity.HasOne(e => e.LokasiKota)
                  .WithMany(c => c.Masterpelanggans)
                  .HasForeignKey(e => e.Kota);
            });

            modelBuilder.Entity<Dtrans>(entity =>
            {
                entity.HasOne(e => e.Htrans)
                 .WithMany(e => e.Dtrans)
                 .HasForeignKey(e => e.Kodeh)
                 .HasPrincipalKey(e => e.KodeH)
                 .IsRequired(false);
            });

                modelBuilder.Entity<Htrans>(entity =>
            {
                entity.HasOne(e => e.Masterpelanggan)
                  .WithMany(e => e.Htrans)
                  .HasForeignKey(e => e.KodePelanggan)
                  .HasPrincipalKey(e => e.Kode)
                  .IsRequired(false);

                entity.HasOne(e => e.Sales)
                 .WithMany(e => e.Htrans)
                 .HasForeignKey(e => e.KodeSales)
                 .HasPrincipalKey(e => e.Kode)
                 .IsRequired(false);

                entity.HasOne(e => e.Mastergudang)
                 .WithMany(e => e.Htrans)
                 .HasForeignKey(e => e.Kodegudang)
                 .HasPrincipalKey(e => e.Kode)
                 .IsRequired(false);
            });

            modelBuilder.Entity<Dtrans>(entity =>
            {
                entity.HasOne(e => e.Masterbarang)
                  .WithMany(e => e.Dtrans)
                  .HasForeignKey(e => e.Kodebarang)
                  .HasPrincipalKey(e => e.BrgKode);
            });

            modelBuilder.Entity<Masterbarang>(entity =>
            {
                entity.HasOne(e => e.Dkategoribarang)
                  .WithMany(e => e.Masterbarang)
                  .HasForeignKey(e => e.KategoriBrg)
                  .HasPrincipalKey(e => e.Koded);
            });

            modelBuilder.Entity<LokasiKota>(entity =>
            {
                entity.HasOne(e => e.LokasiProvinsi)
                .WithMany(c => c.LokasiKota)
                .HasForeignKey(e => e.Provinsi)
                .HasPrincipalKey(e => e.Kode)
                .IsRequired(false);
            });

            modelBuilder.Entity<Dkategoribarang>(entity =>
            {
                entity.HasOne(e => e.Hkategoribarang)
                .WithMany(c => c.Dkategoribarang)
                .HasForeignKey(e => e.Kodeh)
                .HasPrincipalKey(e => e.Kodeh)
                .IsRequired(false);
            });

        }

        public void SoftDelete<TEntity>(TEntity entity) where TEntity : class, ISoftDelete
        {
            entity.DeletedAt = DateTime.Now;
            Update(entity);
        }

        public Task RestoreSoftDeleteAsync<TEntity>(TEntity entity) where TEntity : class, ISoftDelete
        {
            entity.DeletedAt = null;
            Update(entity);
            return SaveChangesAsync();
        }

    }
}
