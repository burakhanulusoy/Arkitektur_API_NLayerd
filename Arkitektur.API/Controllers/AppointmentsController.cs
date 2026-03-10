using Arkitektur.Business.DTOs.AppointmentDtos;
using Arkitektur.Business.Services.AppointmentService;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController(IAppointmnetService _appointmnetService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentDto createAppointmentDto)
        {
            var response = await _appointmnetService.CreateAsync(createAppointmentDto);

            return response.IsSuccessful ? Created() : BadRequest(response);


        }

        [HttpPut]
        public  async Task<IActionResult> Update(UpdateAppointmentDto updateAppointmentDto)
        {
            var response = await _appointmnetService.UpdateAsync(updateAppointmentDto);

            return response.IsSuccessful ? NoContent() : BadRequest(response);


        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var response=await _appointmnetService.GetAllAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);


        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var response = await _appointmnetService.GetByIdAsync(id);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response =await _appointmnetService.DeleteAsync(id);

            return response.IsSuccessful ? NoContent() : BadRequest(response);


        }








    }
}
