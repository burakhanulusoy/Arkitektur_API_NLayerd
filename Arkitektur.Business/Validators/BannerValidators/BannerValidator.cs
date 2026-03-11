using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators.BannerValidators
{
    public class BannerValidator:AbstractValidator<Banner>
    {
        public BannerValidator()
        {
            RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("Baþlýk alaný boþ býrakýlamaz.")
                 .MinimumLength(3).WithMessage("Baþlýk alaný en az 3 karakter olmalýdýr.")
                 .MaximumLength(100).WithMessage("Baþlýk alaný en fazla 100 karakter olmalýdýr.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açýklama alaný boþ býrakýlamaz.")
                .MinimumLength(10).WithMessage("Açýklama alaný en az 10 karakter olmalýdýr.")
                .MaximumLength(500).WithMessage("Açýklama alaný en fazla 500 karakter olmalýdýr.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel baðlantýsý boþ býrakýlamaz.");

        }





    }
}
