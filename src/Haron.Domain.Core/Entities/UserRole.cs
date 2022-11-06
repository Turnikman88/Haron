﻿using Haron.Domain.Core.Entities.Abstract.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Haron.Domain.Core.Entities
{
    public class UserRole : IdentityUserRole<int>, IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastModifiedOn { get; set; }
    }
}