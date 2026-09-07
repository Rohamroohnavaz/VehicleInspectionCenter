using InspectionCenter.Domain.DomainExceptions;
using InspectionCenter.Domain.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Domain.Entities
{
    public class Province : BaseEntity
    {
        public Province()
        {
            
        }

        public Province(string provinceName)
        {
            ProvinceName = provinceName;
            Validate();
        }

        public string ProvinceName { get; private set; }
        public List<City> Cities { get; set; } = new();

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(ProvinceName))
                throw new NullNameException("ProvinceName is null !!");
        }
    }
}
