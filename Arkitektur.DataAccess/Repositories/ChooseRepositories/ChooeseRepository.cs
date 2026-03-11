using Arkitektur.DataAccess.Context;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.Entity.Entities;

namespace Arkitektur.DataAccess.Repositories.ChooseRepositories
{
    public class ChooeseRepository : GenericRepository<Choose>, IChooeseRepository
    {
        public ChooeseRepository(AppDbContext context) : base(context)
        {
        }
    }
}
