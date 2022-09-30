namespace Haron.Application.Core.Identity.Options
{
    public class IdentityOption
    {
        public IdentityOption()
        {
            UserRequrments = new UserOption();
            SignInRequrments = new SignInOption();
            PasswordRequrments = new PasswordOption();
        }

        public UserOption? UserRequrments { get; set; }

        public SignInOption? SignInRequrments { get; set; }

        public PasswordOption? PasswordRequrments { get; set; }
    }
}