using DoranOfficeBackend.Dtos.Transit;
using FluentValidation;

namespace DoranOfficeBackend.Dtos.PermintaanSales
{
    public class SavePermintaanSalesDto
    {
        public DateTime Tglorder { get; set; }
        public string Keterangan { get; set; } = null!;
        public int? Kodegudang { get; set; } = 1;
        public int Kodepelanggan { get; set; }
        public int Kodepenyiap { get; set; }
        public int Kodesales { get; set; }
    }

    public class SavePermintaanSalesValidation : AbstractValidator<SavePermintaanSalesDto>
    {
        public SavePermintaanSalesValidation()
        {
            RuleFor(x => x.Tglorder)
               .NotEmpty()
               .WithMessage("\"Tanggal Order\" harus di isi");

            RuleFor(x => x.Kodepelanggan)
                .NotEmpty()
                .WithMessage("\"Gudang Tujuan\" harus di isi");

            RuleFor(x => x.Kodegudang)
                .NotEmpty()
                .WithMessage("\"Gudang Tujuan\" harus di isi");

            RuleFor(x => x.Kodepenyiap)
                .NotNull()
                .WithMessage("\"Penyiap\" harus di isi");

            RuleFor(x => x.Kodesales)
                .NotNull()
                .WithMessage("\"Sales\" harus di isi"); ;
        }
    }
}
