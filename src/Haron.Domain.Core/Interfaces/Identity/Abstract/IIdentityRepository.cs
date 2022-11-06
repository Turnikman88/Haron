using Haron.Domain.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Haron.Domain.Core.Interfaces.Identity.Abstract
{
    public interface IIdentityRepository { }
    public interface IIdentityRepository<TObj, TContext> : IIdentityRepository
        where TObj : BaseDeletableModel<int>
        where TContext : DbContext
    {
        Task<TObj> GetAsync(int id);

        IQueryable<TObj> GetAll();

        Task<TObj> AddAsync(TObj entity);

        Task AddRange(IEnumerable<TObj> entities);

        void Update(TObj entity);

        void UpdateRange(IEnumerable<TObj> entities);

        Task<int> DeleteAsync(int entityId);

        Task<int> DeleteRangeAsync(IEnumerable<int> entitiesId);

        Task<int> SaveChangesAsync();
    }
}