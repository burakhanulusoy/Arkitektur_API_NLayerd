using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators.CategoryValidators
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {

            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adý boþ býrakýlamaz")
                                        .MinimumLength(3).WithMessage("Kategori adý minumum 3 karakterli olabilir")
                                        .MaximumLength(200).WithMessage("Kategori adý maximum 200 karakterli olabilir");

          

        }




    }
}
