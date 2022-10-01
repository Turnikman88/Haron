using Haron.Domain.Core.Entities.Abstract;
using Haron.Domain.Core.Interfaces.Identity.Abstract;
using Haron.Infrastructure.Data.Identity.DBContext;

namespace Haron.Infrastructure.Data.Identity.Repositories.Abstract
{
    public abstract class BaseIdentityRepository : IIdentityRepository { }
    public abstract class BaseIdentityRepository<T> : BaseIdentityRepository, IIdentityRepository<T> where T : BaseDeletableModel<int>
    {
        protected readonly IdentityContext _context;

        protected BaseIdentityRepository(IdentityContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync<T>(entity);
            return entity;
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public Task<int> DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteRangeAsync(IEnumerable<int> entitiesId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetAsync(int id)
        {
            var result = await _context.FindAsync<T>(id);
            return result;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Update<T>(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);
        }
    }
}