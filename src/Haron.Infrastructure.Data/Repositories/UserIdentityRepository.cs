using Haron.Domain.Core.Entities;
using Haron.Domain.Core.Interfaces;
using Haron.Infrastructure.Data.Identity.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Haron.Infrastructure.Data.Identity.Repositories
{
    public class UserIdentityRepository : IUserIdentityRepository
    {
        private readonly IdentityContext _context;

        public UserIdentityRepository(IdentityContext context)
        {
            _context = context;
        }

        public async Task<bool> EmailAndUsernameExist(string value)
        {
            var result = await _context.Users.AnyAsync(x => x.NormalizedUsername == value.ToUpper() && x.NormalizedEmail == value.ToUpper());
            return result;
        }

        public async Task<bool> EmailOrUsernameExist(string value, bool email = true)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByAsync(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<User> GetByAsync(string value, bool email = true)
        {
            var query = _context.Users.AsQueryable();
            if (email)
            {
                query = query.Where(x => x.NormalizedEmail == value.ToUpper());
            }
            else
            {
                query = query.Where(x => x.NormalizedUsername == value.ToUpper());
            }

            var result = await query.FirstOrDefaultAsync();
            return result;
        }
    }
}