using Arkitektur.DataAccess.Context;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.Entity.Entities;

namespace Arkitektur.DataAccess.Repositories.CategoryRepositories
{
    public class CategorryRepository : GenericRepository<Category>, ICategorryRepository
    {
        public CategorryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
