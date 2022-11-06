using Haron.Domain.Core.Entities.Abstract.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Haron.Domain.Core.Entities
{
    public class User : IdentityUser<int>, IAuditInfo, IDeletableEntity
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string AvatarUrl { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}