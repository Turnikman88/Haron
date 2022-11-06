﻿using Haron.Domain.Core.Entities.Abstract.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Haron.Domain.Core.Entities
{
    public class UserToken : IdentityUserToken<int>, IAuditInfo, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastModifiedOn { get; set; }
    }
}