using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.Business.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService _projectService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var response = await _projectService.GetProjectsWithCategoryAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetProjectsWithCategories")]
        public async Task<IActionResult> GetAllSecond()
        {

            var response = await _projectService.GetProjectsWithCategorySecondMethodAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _projectService.GetByIdProjectWithCategoryAsync(id);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _projectService.DeleteAsync(id);

            return response.IsSuccessful ? NoContent() : BadRequest(response);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto createProject)
        {
            var response = await _projectService.CreateAsync(createProject);

            return response.IsSuccessful ? Created() : BadRequest(response);

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectDto updateProject)
        {
            var response = await _projectService.UpdateAsync(updateProject);

            return response.IsSuccessful ? NoContent() : BadRequest(response);

        }



    }
}
