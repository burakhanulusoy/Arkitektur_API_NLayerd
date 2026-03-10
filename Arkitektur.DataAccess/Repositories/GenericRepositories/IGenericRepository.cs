using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.DataAccess.Repositories.GenericRepositories
{
    public interface IGenericRepository<TEntity> where TEntity :BaseEntity
    {

        Task<List<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetQueryable();//içinde filtereleme işlemi
        Task<TEntity> GetByIdAsync(int id);
        void Delete(TEntity entity);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);




    }
}
