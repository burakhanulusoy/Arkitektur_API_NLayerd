using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using Mapster;

namespace Arkitektur.Business.Services.AboutServices
{
    public class AboutService(IGenericRepository<About> _aboutRepository, IUnitOfWork _unitOfWork) : IAboutService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateAboutDto createAboutDto)
        {
            var about = createAboutDto.Adapt<About>();
           
            await _aboutRepository.CreateAsync(about);
           
            var result =await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
          
            var about = await _aboutRepository.GetByIdAsync(id);

            if(about is null)
            {
                return BaseResult<object>.Fail("About not found");
            }

            _aboutRepository.Delete(about);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");


        }

        public async Task<BaseResult<List<ResultAboutDto>>> GetAllAsync()
        {
            
            var abouts = await _aboutRepository.GetAllAsync();

            var mappedAbouts=abouts.Adapt<List<ResultAboutDto>>();

            return BaseResult<List<ResultAboutDto>>.Success(mappedAbouts);



        }

        public async Task<BaseResult<ResultAboutDto>> GetByIdAsync(int id)
        {
            var about = await _aboutRepository.GetByIdAsync(id);
              
            if(about is null)
            {
                return BaseResult<ResultAboutDto>.Fail("About not found");
            }
          
            var mappedAbout = about.Adapt<ResultAboutDto>();

            return BaseResult<ResultAboutDto>.Success(mappedAbout);

        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAboutDto updateAboutDto)
        {
            var about = updateAboutDto.Adapt<About>();

            _aboutRepository.Update(about);

            var result =await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update failed");





        }
    }
}
