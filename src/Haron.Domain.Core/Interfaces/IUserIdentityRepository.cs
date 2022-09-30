using Haron.Domain.Core.Entities;

namespace Haron.Domain.Core.Interfaces
{
    public interface IUserIdentityRepository
    {
        Task<User> GetByAsync(int id);

        Task<User> GetByAsync(string value, bool email = true);

        Task<bool> EmailOrUsernameExist(string value, bool email = true);

        Task<bool> EmailAndUsernameExist(string value);
    }
}