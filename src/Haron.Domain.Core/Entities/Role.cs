using Haron.Domain.Core.Entities.Abstract;

namespace Haron.Domain.Core.Entities
{
    public class Role : BaseModel<int>
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
            RolePermissions = new HashSet<RolePermission>();
        }
        public string? Name { get; set; }

        public ICollection<UserRole>? UserRoles { get; set; }
        public ICollection<RolePermission>? RolePermissions { get; set; }
    }
}