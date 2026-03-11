using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.CategoryDtos;
using Arkitektur.DataAccess.Repositories.CategoryRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.CategoryServices
{
    public class CategoryService(ICategorryRepository _categorryRepository,
                                 IUnitOfWork _unitOfWork,
                                 IValidator<Category> _validator) : ICategoryService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateCategoryDto createCategory)
        {
            var category = createCategory.Adapt<Category>();

            var resultValidation = await _validator.ValidateAsync(category);

            if(!resultValidation.IsValid)
            {
                return BaseResult<object>.Fail(resultValidation.Errors);
            }

            await _categorryRepository.CreateAsync(category);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Created Failed");

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
          
            var category = await _categorryRepository.GetByIdAsync(id);

            if(category is null)
            {
                return BaseResult<object>.Fail("Category Not Found");
            }

            _categorryRepository.Delete(category);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Deleted Failed");


        }

        public async Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync()
        {
            var categories = await _categorryRepository.GetAllAsync();

            var mappedCategories = categories.Adapt<List<ResultCategoryDto>>();

            return  BaseResult<List<ResultCategoryDto>>.Success(mappedCategories);

        }

        public async Task<BaseResult<ResultCategoryDto>> GetByIdAsync(int id)
        {

            var category = await _categorryRepository.GetByIdAsync(id);

            if(category is null)
            {
                return BaseResult<ResultCategoryDto>.Fail("Category Not Found");
            }

            var mappedCategory = category.Adapt<ResultCategoryDto>();

            return BaseResult<ResultCategoryDto>.Success(mappedCategory);

        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto updateCategory)
        {

            var mappedCategory = updateCategory.Adapt<Category>();

            var resultValidation = await _validator.ValidateAsync(mappedCategory);
            
            if(!resultValidation.IsValid)
            {
                return BaseResult<object>.Fail("Updated Failed");
            }

            _categorryRepository.Update(mappedCategory);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Updated Failed");

        }
    }
}
