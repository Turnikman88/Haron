using Haron.Application.Core.Identity.Options;
using Haron.Domain.Core.Entities;

namespace Haron.Application.Core.Identity.Services
{
    public class SignInManager
    {
        private readonly ICollection<Func<User, bool>> _registerRequirments;
        private readonly ICollection<Func<User, bool>> _signInRequirments;

        public SignInManager(SignInOption signInOption)
        {
            _registerRequirments = RegisterRequirments(signInOption);
            _signInRequirments = SignInRequirments(signInOption);
        }

        public IReadOnlyCollection<Func<User, bool>> RegisterRequirment => (IReadOnlyCollection<Func<User, bool>>)_registerRequirments;

        public IReadOnlyCollection<Func<User, bool>> SignInRequirment => (IReadOnlyCollection<Func<User, bool>>)_signInRequirments;


        private ICollection<Func<User, bool>> RegisterRequirments(SignInOption signInOption)
        {
            List<Func<User, bool>> requirments = new();
            if (signInOption is null)
            {
                throw new ArgumentNullException($"{nameof(PasswordOption)} is null");
            }

            if (signInOption.RequireConfirmedEmail)
            {
                Func<User, bool> requirment = x => string.IsNullOrWhiteSpace(x.Email);
                requirments.Add(requirment);
            }

            return requirments;
        }

        private ICollection<Func<User, bool>> SignInRequirments(SignInOption signInOption)
        {
            List<Func<User, bool>> requirments = new();
            if (signInOption is null)
            {
                throw new ArgumentNullException($"{nameof(PasswordOption)} is null");
            }

            if (signInOption.RequireConfirmedEmail)
            {
                Func<User, bool> requirment = x => x.EmailConfirmed == true;
                requirments.Add(requirment);
            }

            return requirments;
        }
    }
}