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
    public class Appointment : BaseEntity
    {
        public Appointment()
        {

        }

        public Appointment(string resultText, int capacity, Car car, Guid carId, 
            Schedule schedule, Guid scheduleId, DateTime expireTime)
        {
            ResultText = resultText;
            Capacity = capacity;
            Car = car;
            CarId = carId;
            Schedule = schedule;
            ScheduleId = scheduleId;
            ExpireTime = expireTime;
            Validate();
        }

        public string ResultText { get; private set; }
        public int Capacity { get; private set; }
        public bool? IsPassed { get; private set; }
        public Car Car { get; private set; }
        public Guid CarId { get; private set; }
        public Schedule? Schedule { get; private set; }
        public Guid? ScheduleId { get; private set; }
        public DateTime ExpireTime { get; private set; }
        public DateTime? CompeletedAt { get; private set; }
        public Status Status { get; set; } = Status.Active;
        public ReserveStatus ReserveStatus { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(ResultText))
                throw new NullPropException("ResultText can't be null !!");
        }
    }
}
