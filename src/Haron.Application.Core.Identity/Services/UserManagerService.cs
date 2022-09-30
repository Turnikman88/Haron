using Haron.Application.Core.Identity.Options;

namespace Haron.Application.Core.Identity.Services
{
    public class UserManagerService
    {
        private readonly PasswordManager _passwordManager;
        private readonly SignInManager _signInManager;
        private readonly UserManager _userManager;

        public UserManagerService(IdentityOption identityOption)
        {
            _passwordManager = new PasswordManager(identityOption.PasswordRequrments);
            _signInManager = new SignInManager(identityOption.SignInRequrments);
            _userManager = new UserManager(identityOption.UserRequrments);
        }
    }
}