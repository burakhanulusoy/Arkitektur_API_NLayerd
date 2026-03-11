using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.DataAccess.Repositories.ProjectRepository;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.ProjectServices
{
    public class ProjectService(IProjectRepository _projectRepository,
                                IUnitOfWork _unitOfWork
                                ,IValidator<Project> _validator) : IProjectService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateProjectDto createProjectDto)
        {
            var mappedProject = createProjectDto.Adapt<Project>();

            var resultValidation = await _validator.ValidateAsync(mappedProject);

            if (!resultValidation.IsValid)
            {
                return BaseResult<object>.Fail(resultValidation.Errors);
            }

            await _projectRepository.CreateAsync(mappedProject);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {

            var project = await _projectRepository.GetByIdAsync(id);

            if(project is null)
            {
                return BaseResult<object>.Fail("Project Not Found");
            }

            _projectRepository.Delete(project);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<ResultProjectDto>> GetByIdProjectWithCategoryAsync(int id)
        {
            
            var project = await _projectRepository.GetByIdProjectWithCategory(id);

            if(project is null)
            {
                return BaseResult<ResultProjectDto>.Fail("Project Not Found");

            }

            var mappedProject = project.Adapt<ResultProjectDto>();

            return BaseResult<ResultProjectDto>.Success(mappedProject);

        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategoryAsync()
        {

            var projects = await _projectRepository.GetProjectsWithCategory();

            var mappedProjects = projects.Adapt<List<ResultProjectDto>>();

            return BaseResult<List<ResultProjectDto>>.Success(mappedProjects);


        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategorySecondMethodAsync()
        {
            //EAGER LOADÝNG
            var queryable = _projectRepository.GetQueryable();

            var projects =await queryable.Include(x => x.Category).ToListAsync();

            var mappedProjects = projects.Adapt<List<ResultProjectDto>>();

            return BaseResult<List<ResultProjectDto>>.Success(mappedProjects);



        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateProjectDto updateProjectDto)
        {

            var mappedProject = updateProjectDto.Adapt<Project>();

            var resultValidation =await _validator.ValidateAsync(mappedProject);

            if(!resultValidation.IsValid)
            {
                return BaseResult<object>.Fail(resultValidation.Errors);
            }

            _projectRepository.Update(mappedProject);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");


        }
    }
}
