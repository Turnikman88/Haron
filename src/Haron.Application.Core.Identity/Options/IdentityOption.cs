namespace Haron.Application.Core.Identity.Options
{
    public class IdentityOption
    {
        public UserOption? User { get; set; }

        public SignInOption? SignIn { get; set; }

        public PasswordOption? Password { get; set; }
    }
}