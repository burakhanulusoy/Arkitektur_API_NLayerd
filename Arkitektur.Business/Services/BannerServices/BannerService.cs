using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.BannerDtos;
using Arkitektur.DataAccess.Repositories.BannerRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.BannerServices
{
    public class BannerService(IBannerRepository _bannerRepository,
                               IUnitOfWork _unitOfWork,
                               IValidator<Banner> _validator) : IBannerService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateBannerDto createBannerDto)
        {
           
            var banner=createBannerDto.Adapt<Banner>();

            var validationResult = await _validator.ValidateAsync(banner);

            ///fAST Fail
            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _bannerRepository.CreateAsync(banner);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Create Failed");

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
           var banner = await _bannerRepository.GetByIdAsync(id);

            if(banner is  null)
            {
                return BaseResult<object>.Fail("Banner Not Found");

            }

            _bannerRepository.Delete(banner);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");



        }

        public async Task<BaseResult<List<ResultBannerDto>>> GetAllAsync()
        {
            
            var banners = await _bannerRepository.GetAllAsync();

            var mappedBanners=banners.Adapt<List<ResultBannerDto>>();

            return BaseResult<List<ResultBannerDto>>.Success(mappedBanners);


        }

        public async Task<BaseResult<ResultBannerDto>> GetByIdAsync(int id)
        {
            var banner = await _bannerRepository.GetByIdAsync(id);

            if(banner is null)
            {

                return BaseResult<ResultBannerDto>.Fail("Banner Not Found");

            }

            var mappedBanner = banner.Adapt<ResultBannerDto>();

            return BaseResult<ResultBannerDto>.Success(mappedBanner);


        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateBannerDto updateBannerDto)
        {

            var banner = updateBannerDto.Adapt<Banner>();

            var validationResult=await _validator.ValidateAsync(banner);

            if(!validationResult.IsValid)
            {

                return BaseResult<object>.Fail(validationResult.Errors);
            }


            _bannerRepository.Update(banner);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Updated Failed");



        }
    }
}
