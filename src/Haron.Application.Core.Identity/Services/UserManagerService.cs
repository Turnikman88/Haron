using Haron.Application.Core.Identity.Options;
using Haron.Application.Core.Identity.Users.Models;
using Haron.Application.Core.Identity.ValidationModels;
using Haron.Domain.Core.Entities;
using Haron.Domain.Core.Interfaces.Identity;

namespace Haron.Application.Core.Identity.Services
{
    public class UserManagerService
    {
        private readonly PasswordManager _passwordManager;
        private readonly SignInManager _signInManager;
        private readonly UserManager _userManager;
        private readonly IUserRepository _userRepository;

        public UserManagerService(IdentityOption identityOption, IUserRepository userRepository)
        {
            _passwordManager = new PasswordManager(identityOption.PasswordRequrments);
            _signInManager = new SignInManager(identityOption.SignInRequrments);
            _userManager = new UserManager(identityOption.UserRequrments, userRepository);
            _userRepository = userRepository;
        }

        public async Task<ValidationModel> RegisterUser(UserRegisterModel inputModel)
        {
            ValidationModel result = new ValidationModel();
            if (inputModel is null)
            {
                result.Message = "Mission input information";
                return result;
            }
            var user = CreateUserRegisterModel(inputModel);

            var isUsernameValid = _userManager.ValidationUsername(user);
            if (!isUsernameValid.Succeeded)
            {
                return isUsernameValid;
            }

            var isPasswordValid = _passwordManager.ValidationPassword(inputModel.Password);
            if (!isPasswordValid.Succeeded)
            {
                return isPasswordValid;
            }

            var isSuchUserExist = await _userManager.ValidationUsernameAndEmailAsync(user);
            if (!isSuchUserExist.Succeeded)
            {
                return isSuchUserExist;
            }

            user.PasswordHash = _passwordManager.HashPassoword(inputModel.Password);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return result;
        }

        private User CreateUserRegisterModel(UserRegisterModel inputModel)
        {
            return new User
            {
                FirstName = inputModel.FirstName,
                LastName = inputModel.LastName,
                Email = inputModel.Email,
                Username = inputModel.Username,
                PhoneNumber = inputModel.PhoneNumber
            };
        }
    }
}