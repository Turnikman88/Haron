using Haron.Domain.Core.Entities.Abstract;

namespace Haron.Domain.Core.Entities
{
    public class User : BaseDeletableModel<int>
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();   
        }

        public string? Email { get; set; }

        public string? NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        public string? Username { get; set; }

        public string? NormalizedUsername { get; set; }

        public string? PasswordHash { get; set; }

        public string? PhoneNumber { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? AvatarUrl { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public ICollection<UserRole>? UserRoles { get; set; }
    }
}