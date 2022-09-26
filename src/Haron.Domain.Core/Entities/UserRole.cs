using Haron.Domain.Core.Entities.Abstract;

namespace Haron.Domain.Core.Entities
{
    public class UserRole : BaseModel<int>
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}