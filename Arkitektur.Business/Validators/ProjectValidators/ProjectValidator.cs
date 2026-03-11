using Arkitektur.Entity.Entities;
using FluentValidation;
using FluentValidation.Validators;

namespace Arkitektur.Business.Validators.ProjectValidators
{
    public class ProjectValidator:AbstractValidator<Project>
    {

        public ProjectValidator()
        {
            RuleFor(x => x.Title)
                            .NotEmpty().WithMessage("Baþlýk alaný boþ býrakýlamaz.")
                            .MinimumLength(3).WithMessage("Baþlýk alaný en az 3 karakter olmalýdýr.")
                            .MaximumLength(150).WithMessage("Baþlýk alaný en fazla 150 karakter olmalýdýr.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açýklama alaný boþ býrakýlamaz.")
                .MinimumLength(10).WithMessage("Açýklama alaný en az 10 karakter olmalýdýr.")
                .MaximumLength(1000).WithMessage("Açýklama alaný en fazla 1000 karakter olmalýdýr.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel baðlantýsý boþ býrakýlamaz.");

            RuleFor(x => x.Item1)
                 .NotEmpty().WithMessage("1. Madde alaný boþ býrakýlamaz.")
                 .MaximumLength(100).WithMessage("1. Madde alaný en fazla 100 karakter olmalýdýr.");

            RuleFor(x => x.Item2)
                .NotEmpty().WithMessage("2. Madde alaný boþ býrakýlamaz.")
                .MaximumLength(100).WithMessage("2. Madde alaný en fazla 100 karakter olmalýdýr.");

            RuleFor(x => x.Item3)
                .NotEmpty().WithMessage("3. Madde alaný boþ býrakýlamaz.")
                .MaximumLength(100).WithMessage("3. Madde alaný en fazla 100 karakter olmalýdýr.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Lütfen proje için geçerli bir kategori seçiniz.")
                .NotEmpty().WithMessage("Lütfen kategori seçiniz");


        }


    }
}
