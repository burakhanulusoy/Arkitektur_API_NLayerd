using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.BannerDtos;

namespace Arkitektur.Business.Services.BannerServices
{
    public interface IBannerService
    {

        Task<BaseResult<List<ResultBannerDto>>> GetAllAsync();
        Task<BaseResult<ResultBannerDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateBannerDto updateBannerDto);
        Task<BaseResult<object>> CreateAsync(CreateBannerDto createBannerDto);




    }
}
