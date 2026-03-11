using Arkitektur.Entity.Entities;
using FluentValidation;
using Microsoft.Identity.Client.Extensibility;

namespace Arkitektur.Business.Validators.ChooseValidators
{
    public class ChooseValidator:AbstractValidator<Choose>
    {
        public ChooseValidator()
        {

            RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("Baþlýk alaný boþ býrakýlamaz.")
                 .MinimumLength(3).WithMessage("Baþlýk en az 3 karakter olmalýdýr.")
                 .MaximumLength(100).WithMessage("Baþlýk en fazla 100 karakter olabilir.");

            // Açýklama (Description) Kurallarý
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açýklama alaný boþ býrakýlamaz.")
                .MinimumLength(10).WithMessage("Lütfen daha detaylý bir açýklama giriniz (En az 10 karakter).")
                .MaximumLength(500).WithMessage("Açýklama en fazla 500 karakter olabilir.");

            // Ýkon (Icon) Kurallarý
            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Ýkon alaný boþ býrakýlamaz.");

        }
    }
}
