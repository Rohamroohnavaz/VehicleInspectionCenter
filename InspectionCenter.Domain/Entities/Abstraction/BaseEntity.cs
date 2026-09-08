using SequentialGuid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Domain.Entities.Abstraction
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; } = new SequentialGuid.SequentialGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public void SetDelete(Guid id)
        {
            IsDeleted = true;
        }

        public abstract void Validate();
    }
}
