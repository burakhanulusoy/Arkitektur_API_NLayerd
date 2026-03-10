using Arkitektur.Business.DTOs.AppointmentDtos;
using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators
{
    public class AppointmentValidator:AbstractValidator<Appointment>
    {

        public AppointmentValidator()
        {

            RuleFor(x => x.NameSurname)
                 .NotEmpty().WithMessage("Ad ve soyad bilgisi boþ býrakýlamaz.")
                 .MaximumLength(100).WithMessage("Ad ve soyad bilgisi en fazla 100 karakter olmalýdýr.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boþ býrakýlamaz.")
                .EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.")
                .MaximumLength(100).WithMessage("E-posta adresi en fazla 100 karakter olmalýdýr.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarasý boþ býrakýlamaz.")
                .MaximumLength(20).WithMessage("Telefon numarasý en fazla 20 karakter olmalýdýr.");

            RuleFor(x => x.ServiceName)
                .NotEmpty().WithMessage("Lütfen ilgilendiðiniz hizmeti belirtiniz.")
                .MaximumLength(150).WithMessage("Hizmet adý en fazla 150 karakter olmalýdýr.");

            RuleFor(x => x.AppointmentDate)
                .NotEmpty().WithMessage("Randevu tarihi boþ býrakýlamaz.")
                .GreaterThan(DateTime.Now).WithMessage("Randevu tarihi geçmiþ bir zaman dilimi olamaz.");

            RuleFor(x => x.Message)
                .MaximumLength(500).WithMessage("Mesajýnýz en fazla 500 karakter olmalýdýr.");

            

        }



    }
}
