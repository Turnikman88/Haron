using Haron.Domain.Core.Entities.Abstract.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Haron.Domain.Core.Entities
{
    public class Role : IdentityRole<int>, IAuditInfo, IDeletableEntity
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}