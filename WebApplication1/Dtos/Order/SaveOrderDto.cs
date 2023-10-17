using ConsoleDump;
using DoranOfficeBackend.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PhoneNumbers;
using _Masterpengeluaran = DoranOfficeBackend.Models.Masterpengeluaran;

namespace DoranOfficeBackend.Dtos.Order
{
    public class DetailOrder
    {
        public short Kodebarang { get; set; }
        public short Jumlah { get; set; }
        public int Harga { get; set; }
        public string Keterangan { get; set; } = null!;
    }
    public class SaveOrderDto: SaveOrderHeaderDto
    {
        public List<DetailOrder> Details { get; set; }
    }
    public class SaveOrderDtoValidator : AbstractValidator<SaveOrderDto>
    {
        private readonly MyDbContext _context;
        

        public SaveOrderDtoValidator(MyDbContext context)
        {
            _context = context;
            RuleFor(model => model.NmrHp)
                .MustAsync(
                    (e,value, validaton) =>  BeAValidPhoneNumber(value, e.Kodeexp)
                ).WithMessage("Nomor HP harus di isi dengan valid");
        }

        private async Task<bool> BeAValidPhoneNumber(string phoneNumber, int kodeExp)
        {
            var expedisi = await _context.Masterpengeluaran
                .Where(e => e.Kode == kodeExp)
                .FirstOrDefaultAsync();

            if (expedisi?.HarusInputNoHp == 0)
            {
                return true;
            }
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();

            try
            {
                PhoneNumber number = phoneNumberUtil.Parse(phoneNumber, phoneNumber.StartsWith("085") ? "ID" : null);
                return phoneNumberUtil.IsValidNumber(number);
            }
            catch (NumberParseException ex)
            {
                return false;
            }
        }
    }

}
