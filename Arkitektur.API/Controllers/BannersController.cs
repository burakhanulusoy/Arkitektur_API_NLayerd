using Arkitektur.Business.DTOs.BannerDtos;
using Arkitektur.Business.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IBannerService _bannerService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var banners = await _bannerService.GetAllAsync();

            return banners.IsSuccessful ? Ok(banners) : BadRequest(banners);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultBannerDto>> GetById(int id)
        {
            var banner =await _bannerService.GetByIdAsync(id);

            return banner.IsSuccessful ? Ok(banner) : BadRequest(banner);

        }







        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _bannerService.DeleteAsync(id);

            return response.IsSuccessful ? NoContent() : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto createBannerDto)
        {
            var response = await _bannerService.CreateAsync(createBannerDto);

            return response.IsSuccessful ? Created() :BadRequest(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerDto updateBannerDto)
        {
            var response = await _bannerService.UpdateAsync(updateBannerDto);

            return response.IsSuccessful ? NoContent() : BadRequest(response);


        }






    }
}
