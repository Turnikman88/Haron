using Haron.Domain.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haron.Domain.Core.Entities
{
    public class Permission : BaseModel<int>
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
