using DoranOfficeBackend.Models;
using FluentValidation;

namespace DoranOfficeBackend.Dtos.Transit
{
    public class SaveHeaderTransitDto
    {
        public DateTime TglTrans { get; set; }
        public int KodeGudangTujuan { get; set; }
        public string? Keterangan { get; set; }
        public int Kodegudang { get; set; }
        public sbyte Kodepenyiap { get; set; }
    }

    public class SaveHeaderTransitValidation : AbstractValidator<SaveHeaderTransitDto>
    {
        public SaveHeaderTransitValidation()
        {
            RuleFor(x => x.KodeGudangTujuan)
                .NotEmpty()
                .WithMessage("\"Gudang Tujuan\" harus di isi");

            RuleFor(x => x.Kodegudang)
                .NotEmpty()
                .WithMessage("\"Gudang Tujuan\" harus di isi");

            RuleFor(x => x.Kodepenyiap)
                .NotNull()
                .WithMessage("\"Penyiap\" harus di isi");
            
            RuleFor(x => x.Kodegudang)
                .NotEqual(x => x.KodeGudangTujuan)
                .WithMessage("\"Kode Gudang\" tidak boleh sama dengan \"Kode Gudang Tujuan\"");
        }
    }
}
