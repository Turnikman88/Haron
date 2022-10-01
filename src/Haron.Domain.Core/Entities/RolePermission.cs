using Haron.Domain.Core.Entities.Abstract;

namespace Haron.Domain.Core.Entities
{
    public class RolePermission : BaseDeletableModel<int>
    {
        public int RoleId { get; set; }
        public Role? Role { get; set; }

        public int PermissionId { get; set; }
        public Permission? Permission { get; set; }
    }
}