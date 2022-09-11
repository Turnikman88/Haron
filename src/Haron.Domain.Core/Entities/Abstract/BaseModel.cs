using Haron.Domain.Core.Entities.Abstract.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haron.Domain.Core.Entities.Abstract
{
    public abstract class BaseModel<TKey> : IAuditInfo
    {
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? LastModifiedOn { get; set; }
    }
}
