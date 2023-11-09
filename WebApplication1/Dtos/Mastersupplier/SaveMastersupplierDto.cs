namespace DoranOfficeBackend.Dtos.Mastersupplier
{
    public class SaveMastersupplierDto
    {
        public string SupplierNama { get; set; }
        public string Namalengkap { get; set; }
        public string Rekening { get; set; }
        public string Npwp { get; set; }
        public bool? Aktif { get; set; } = true;
    }
}
