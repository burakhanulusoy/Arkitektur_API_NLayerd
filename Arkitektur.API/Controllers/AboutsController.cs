using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAboutService _aboutService) : ControllerBase
    {

        //güzelmiş
        [HttpGet]
        public async Task<ActionResult<List<ResultAboutDto>>> GetAll()
        {

            var response =  await _aboutService.GetAllAsync();
        
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        
        }


        [HttpGet("{id}")]//api/abouts/id
        public async Task<IActionResult> GetById(int id)
        {

            var response = await _aboutService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto dto)
        {
            var response = await _aboutService.CreateAsync(dto);

            return response.IsSuccessful ? Created() : BadRequest(response);//201 kodu döner başarılı ise


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _aboutService.DeleteAsync(id);
            return response.IsSuccessful ? NoContent() : BadRequest(response);


        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDto dto)
        {

            var response = await _aboutService.UpdateAsync(dto);

            return response.IsSuccessful ? NoContent() : BadRequest(response);




        }




    }
}
