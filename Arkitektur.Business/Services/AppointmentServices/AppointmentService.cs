using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AppointmentDtos;
using Arkitektur.Business.Services.AppointmentService;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.AppointmentServices
{
    public class AppointmentService(IGenericRepository<Appointment> _appointmentRepository,
                                    IUnitOfWork _unitOfWork,
                                    IValidator<Appointment> _appointmnetValidator
                                    ) : IAppointmnetService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateAppointmentDto appointmentDto)
        {
            
            var appointment = appointmentDto.Adapt<Appointment>();

            var validationResult = await _appointmnetValidator.ValidateAsync(appointment);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);

            }

            await _appointmentRepository.CreateAsync(appointment);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if(appointment is null)
            {
                return BaseResult<object>.Fail("Appointment not found");
            }

            _appointmentRepository.Delete(appointment);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");



        }

        public async Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync()
        {
           
            var appointments = await _appointmentRepository.GetAllAsync();

            var mappedAppointmemts = appointments.Adapt<List<ResultAppointmentDto>>();
            
            return BaseResult<List<ResultAppointmentDto>>.Success(mappedAppointmemts);

        }

        public async Task<BaseResult<ResultAppointmentDto>> GetByIdAsync(int id)
        {
            
            var appointmnet = await _appointmentRepository.GetByIdAsync(id);

            if(appointmnet is null)
            {

                return BaseResult<ResultAppointmentDto>.Fail("Appointment Not Found");

            }


            var mappedAppointmnet = appointmnet.Adapt<ResultAppointmentDto>();

            return BaseResult<ResultAppointmentDto>.Success(mappedAppointmnet);


        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto appointmentDto)
        {
            var appointment = appointmentDto.Adapt<Appointment>();

            var validationResult = await _appointmnetValidator.ValidateAsync(appointment);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);

            }



            _appointmentRepository.Update(appointment);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update failed");





        }
    }
}
