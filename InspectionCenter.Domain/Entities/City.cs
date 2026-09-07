using InspectionCenter.Domain.DomainExceptions;
using InspectionCenter.Domain.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Domain.Entities
{
    public class City : BaseEntity
    {
        public City()
        {
            
        }

        public City(string cityName)
        {
            CityName = cityName;
            Validate();
        }

        public string CityName { get; private set; }
        public Province Province { get; private set; }
        public Guid ProvinceId { get; private set; }
        public List<VehicleInspectionCenter> Centers { get; set; } = new();

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(CityName))
                throw new NullNameException("CityName can't be null !");
        }
    }
}
