using Haron.Domain.Core.Entities;
using Haron.Domain.Core.Interfaces.Identity.Abstract;

namespace Haron.Domain.Core.Interfaces.Identity
{
    public interface IUserRepository : IIdentityRepository<User>
    {
    }
}