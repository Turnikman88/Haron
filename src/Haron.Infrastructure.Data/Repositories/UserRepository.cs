using Haron.Domain.Core.Entities;
using Haron.Domain.Core.Interfaces.Identity;
using Haron.Infrastructure.Data.Identity.DBContext;
using Haron.Infrastructure.Data.Identity.Repositories.Abstract;

namespace Haron.Infrastructure.Data.Identity.Repositories
{
    public class UserRepository : BaseIdentityRepository<User>, IUserRepository
    {
        public UserRepository(IdentityContext context)
            : base(context)
        {
        }
    }
}