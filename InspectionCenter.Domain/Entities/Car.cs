using InspectionCenter.Domain.DomainExceptions;
using InspectionCenter.Domain.Entities.Abstraction;
using InspectionCenter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Domain.Entities
{
    public class Car : BaseEntity
    {
        public Car()
        {
            
        }

        public Car(string carName, string carModel, string chassisNumber,string plateNumber)
        {
            CarName = carName;
            CarModel = carModel;
            ChassisNumber = chassisNumber;
            PlateNumber = plateNumber;
            Validate();
        }

        public string CarName { get; private set; }
        public string CarModel { get; private set; }
        public string ChassisNumber { get; private set; }
        public string PlateNumber { get; private set; }
        public bool IsActive { get; private set; } = true;
        public User Owner { get; private set; }
        public Guid OwnerId { get; private set; }
        public List<Appointment> Appointments { get; set; } = new();

        public void SetCarName(string carName)
        {
            CarName = CarName;
        }

        public void SetCarModel(string carModel)
        {
            CarModel = carModel;
        }

        public void SetChassisNumber(string chassisNumber)
        {
            ChassisNumber = chassisNumber;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
        
        public void SetIsActive()
        {
            IsActive = true;
        }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(CarName))
                throw new NullNameException("CarName can't be null !");

            if (string.IsNullOrWhiteSpace(CarModel))
                throw new NullNameException("CarModel can't be null !");

            if (string.IsNullOrWhiteSpace(ChassisNumber))
                throw new NullNameException("ChassisNumber can't be null !");

            if (string.IsNullOrWhiteSpace(PlateNumber))
                throw new NullNameException("PlateNumber can't be null !");
        }
    }
}
