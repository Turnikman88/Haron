using Haron.Domain.Core.Entities.Abstract.Contracts;

namespace Haron.Domain.Core.Entities.Abstract
{
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}