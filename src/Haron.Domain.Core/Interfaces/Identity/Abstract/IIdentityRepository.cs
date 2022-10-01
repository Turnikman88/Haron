using Haron.Domain.Core.Entities.Abstract;

namespace Haron.Domain.Core.Interfaces.Identity.Abstract
{
    public interface IIdentityRepository { }
    public interface IIdentityRepository<T> : IIdentityRepository where T : BaseDeletableModel<int>
    {
        Task<T> GetAsync(int id);

        IQueryable<T> GetAll();

        Task<T> AddAsync(T entity);

        Task AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        Task<int> DeleteAsync(int entityId);

        Task<int> DeleteRangeAsync(IEnumerable<int> entitiesId);

        Task<int> SaveChangesAsync();
    }
}