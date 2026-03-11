using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.Entity.Entities;

namespace Arkitektur.DataAccess.Repositories.ProjectRepository
{
    public interface IProjectRepository :IGenericRepository<Project>
    {
        Task<List<Project>> GetProjectsWithCategory();
        Task<Project> GetByIdProjectWithCategory(int id);


    }
}
