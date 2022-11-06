using Haron.Application.Core.Identity.Options;
using Haron.Application.Core.Identity.Validators.Contracts;
using Haron.Domain.Core.Entities;

namespace Haron.Application.Core.Identity.Validators
{
    public class UserManager : IUserManager
    {
        private readonly UserOption _userOption;

        public UserManager(UserOption userOption)
        {
            _userOption = userOption;
        }

        private ICollection<Func<User, bool>> Requirments(UserOption passwordOption)
        {
            List<Func<User, bool>> requirments = new();
            if (passwordOption is null)
            {
                throw new ArgumentNullException($"{nameof(PasswordOption)} is null");
            }

            Func<User, bool> allowedSymbos = x => Containes(x.Username, passwordOption.AllowedUserNameCharacters);
            requirments.Add(allowedSymbos);

            return requirments;
        }

        private bool Containes(string userName, string allowedSymbols)
        {
            if (userName is null)
            {
                return false;
            }

            foreach (var chr in userName)
            {
                string symbol = chr.ToString();
                if (!symbol.Contains(allowedSymbols))
                {
                    return false;
                }
            }

            return true;
        }
    }
}