using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ProjectDtos;

namespace Arkitektur.Business.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategoryAsync();
        Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategorySecondMethodAsync();
        Task<BaseResult<ResultProjectDto>> GetByIdProjectWithCategoryAsync(int id);
        Task<BaseResult<object>>  DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateProjectDto updateProjectDto);
        Task<BaseResult<object>> CreateAsync(CreateProjectDto createProjectDto);


    }
}
