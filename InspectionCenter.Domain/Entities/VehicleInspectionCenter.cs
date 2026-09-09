using InspectionCenter.Domain.DomainExceptions;
using InspectionCenter.Domain.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Domain.Entities
{
    public class VehicleInspectionCenter : BaseEntity
    {
        public VehicleInspectionCenter() { }

        public VehicleInspectionCenter(string centerName, string address
            , int capacity, int lineCount, int durationMinutes
            , string report, int appointmentCount
            , TimeSpan startOfWorkTime, TimeSpan endOfWorkTime)
        {
            CenterName = centerName;
            Address = address;
            Capacity = capacity;
            LineCount = lineCount;
            Report = report;
            DurationMinutes = durationMinutes;
            AppointmentCount = appointmentCount;
            StartOfWorkTime = startOfWorkTime;
            EndOfWorkTime = endOfWorkTime;
            Validate();
        }

        public string CenterName { get; private set; }
        public string Address { get; private set; }
        public int Capacity { get; private set; }
        public int LineCount { get; private set; }
        public int DurationMinutes { get; private set; }
        public string Report { get; private set; }
        public int AppointmentCount { get; private set; }
        public bool IsActive { get; private set; } = true;
        public City? City { get; private set; }
        public Guid CityId { get; private set; }
        public TimeSpan StartOfWorkTime { get; private set; }
        public TimeSpan EndOfWorkTime { get; private set; }
        public List<Schedule> Schedules { get; set; } = new();

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(CenterName))
                throw new NullNameException("CenterName can't be null !");

            if (string.IsNullOrWhiteSpace(Address))
                throw new NullPropException("Location can't be null !");

            if (string.IsNullOrWhiteSpace(Report))
                throw new NullPropException("Report can't be null !");

            if (EndOfWorkTime >= StartOfWorkTime)
                throw new Exception("Logical Error !!");
        }
    }
}
