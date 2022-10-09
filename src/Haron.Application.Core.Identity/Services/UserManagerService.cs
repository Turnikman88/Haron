using AutoMapper;
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
        private readonly IMapper _autoMapper;

        public UserManagerService(IdentityOption identityOption, IUserRepository userRepository, IMapper autoMapper)
        {
            _passwordManager = new PasswordManager(identityOption.PasswordRequrments);
            _signInManager = new SignInManager(identityOption.SignInRequrments);
            _userManager = new UserManager(identityOption.UserRequrments, userRepository);
            _userRepository = userRepository;
            _autoMapper = autoMapper;
        }

        public async Task<ValidationModel> RegisterUser(UserRegisterModel inputModel)
        {
            ValidationModel result = new ValidationModel();
            if (inputModel is null)
            {
                result.Message = "Mission input information";
                return result;
            }
            var user = _autoMapper.Map<User>(inputModel);

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


            return result;
        }
    }
}