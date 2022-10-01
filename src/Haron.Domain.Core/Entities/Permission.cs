using Haron.Domain.Core.Entities.Abstract;

namespace Haron.Domain.Core.Entities
{
    public class Permission : BaseDeletableModel<int>
    {
        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }

        public string? Name { get; set; }
        public long AccessLevel { get; set; }

        public ICollection<RolePermission>? RolePermissions { get; set; }
    }
}