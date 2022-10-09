using Haron.Application.Core.Identity.Options;
using Haron.Application.Core.Identity.ValidationModels;
using Haron.Domain.Core.Entities;
using Haron.Domain.Core.Interfaces.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Haron.Application.Core.Identity.Services
{
    public class UserManager
    {
        private readonly ICollection<Func<User, bool>> _requirments;
        private readonly UserOption _userOption;
        private readonly IUserRepository _userRepository;

        public UserManager(UserOption userOption, IUserRepository userRepository)
        {
            _requirments = Requirments(userOption);
            _userOption = userOption;
            _userRepository = userRepository;
        }

        public IReadOnlyCollection<Func<User, bool>> Requirment => (IReadOnlyCollection<Func<User, bool>>)_requirments;

        public ValidationModel ValidationUsername(User user)
        {
            var result = new ValidationModel();
            var isValid = _requirments.All(x => x(user));
            if (!isValid)
            {
                result.Message = "Username is out of the possible symbols";
                return result;
            }
            return result;
        }

        public async Task<ValidationModel> ValidationUsernameAndEmailAsync(User user)
        {
            var result = new ValidationModel();
            if (_userOption.RequireUniqueEmail || _userOption.RequireUniqueUsername)
            {
                var checkUser = _userRepository.GetAll();
                if (_userOption.RequireUniqueEmail)
                {
                    checkUser = checkUser.Where(x => x.NormalizedEmail == user.Email.ToUpper());
                }
                if (_userOption.RequireUniqueUsername)
                {
                    checkUser = checkUser.Where(x => x.NormalizedUsername == user.Username.ToUpper());
                }

                var userExist = await checkUser.FirstOrDefaultAsync();
                if (userExist is not null)
                {
                    result.Message = "Such user already exist in database";
                    return result;
                }
            }

            return result;
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