using Arkitektur.DataAccess.Context;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.DataAccess.Repositories.ProjectRepository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Project> GetByIdProjectWithCategory(int id)
        {
            return await _table.Include(x => x.Category).Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<Project>> GetProjectsWithCategory()
        {
            return await _table.Include(x => x.Category).AsNoTracking().ToListAsync();
        }
    }
}
