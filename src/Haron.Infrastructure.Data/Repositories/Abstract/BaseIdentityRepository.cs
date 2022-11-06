using Haron.Domain.Core.Entities.Abstract;
using Haron.Domain.Core.Interfaces.Identity.Abstract;
using Haron.Infrastructure.Data.Identity.DBContext;

namespace Haron.Infrastructure.Data.Identity.Repositories.Abstract
{
    public abstract class BaseIdentityRepository : IIdentityRepository { }
    public abstract class BaseIdentityRepository<TObj> : BaseIdentityRepository, IIdentityRepository<TObj> where TObj : BaseDeletableModel<int>
    {
        protected readonly IdentityContext _context;

        protected BaseIdentityRepository(IdentityContext context)
        {
            _context = context;
        }

        public async Task<TObj> AddAsync(TObj entity)
        {
            await _context.AddAsync<TObj>(entity);
            return entity;
        }

        public async Task AddRange(IEnumerable<TObj> entities)
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

        public IQueryable<TObj> GetAll()
        {
            return _context.Set<TObj>();
        }

        public async Task<TObj> GetAsync(int id)
        {
            var result = await _context.FindAsync<TObj>(id);
            return result;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(TObj entity)
        {
            _context.Update<TObj>(entity);
        }

        public void UpdateRange(IEnumerable<TObj> entities)
        {
            _context.UpdateRange(entities);
        }
    }
}