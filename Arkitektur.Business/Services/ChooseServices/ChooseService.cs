using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ChooseDtos;
using Arkitektur.DataAccess.Repositories.ChooseRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.ChooseServices
{
    public class ChooseService(IChooeseRepository _chooeseRepository
                              ,IUnitOfWork _unitOfWork
                              ,IValidator<Choose> _validator): IChooseService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateChooseDto createChooseDto)
        {

            var mappedChoose = createChooseDto.Adapt<Choose>();

            var resultValidation=await _validator.ValidateAsync(mappedChoose);

            if(!resultValidation.IsValid)
            {
                return BaseResult<object>.Fail(resultValidation.Errors);
            }

            await _chooeseRepository.CreateAsync(mappedChoose);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Create Failed");


        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {

            var choose = await _chooeseRepository.GetByIdAsync(id);

            if (choose is null)
            {
                return BaseResult<object>.Fail("Choose not Found");
            }

            _chooeseRepository.Delete(choose);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");

        }

        public async Task<BaseResult<List<ResultChooseDto>>> GetAllAsync()
        {
           
            var chooess=await _chooeseRepository.GetAllAsync();

            var mappedChooess = chooess.Adapt<List<ResultChooseDto>>();

            return BaseResult<List<ResultChooseDto>>.Success(mappedChooess);
        }

        public async Task<BaseResult<ResultChooseDto>> GetByIdAsync(int id)
        {

            var choose = await _chooeseRepository.GetByIdAsync(id);

            if(choose is null)
            {
                return BaseResult<ResultChooseDto>.Fail("Choose Not Found");
            }

            var mappedChoose=choose.Adapt<ResultChooseDto>();

            return BaseResult<ResultChooseDto>.Success(mappedChoose);



        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateChooseDto updateChooseDto)
        {
          
            var mappedChoose=updateChooseDto.Adapt<Choose>();

            var resultValidation = await _validator.ValidateAsync(mappedChoose);

            if(!resultValidation.IsValid)
            {
                return BaseResult<object>.Fail(resultValidation.Errors);
            }

            _chooeseRepository.Update(mappedChoose);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");







        }
    }
}
