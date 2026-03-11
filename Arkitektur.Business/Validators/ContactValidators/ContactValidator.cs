using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators.ContactValidators
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres alaný boþ býrakýlamaz.")
                .MinimumLength(10).WithMessage("Lütfen daha detaylý bir adres giriniz (En az 10 karakter).")
                .MaximumLength(500).WithMessage("Adres bilgisi en fazla 500 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boþ býrakýlamaz.")
                .EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi formatý giriniz. (Örn: adiniz@sirket.com)")
                .MaximumLength(100).WithMessage("E-posta adresi en fazla 100 karakter olabilir.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarasý boþ býrakýlamaz.")
                .Matches(@"^\+?[0-9\s\-\(\)]+$").WithMessage("Lütfen geçerli bir telefon numarasý giriniz. Sadece rakam ve + - ( ) kullanabilirsiniz.")
                .MinimumLength(10).WithMessage("Telefon numarasý en az 10 karakter olmalýdýr.")
                .MaximumLength(20).WithMessage("Telefon numarasý en fazla 20 karakter olabilir.");

            RuleFor(x => x.MapUrl)
                .NotEmpty().WithMessage("Harita linki boþ býrakýlamaz.");
              }





    }
}
