using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Domain.Entities.Abstraction
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }

        public void SetDelete(Guid id)
        {
            IsDeleted = true;
        }

        public abstract void Validate();
    }
}
