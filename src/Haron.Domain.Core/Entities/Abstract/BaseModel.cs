using Haron.Domain.Core.Entities.Abstract.Contracts;

namespace Haron.Domain.Core.Entities.Abstract
{
    public abstract class BaseModel<TKey> : IAuditInfo
    {
        protected BaseModel()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastModifiedOn { get; set; }
    }
}