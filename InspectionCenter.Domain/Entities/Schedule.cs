using InspectionCenter.Domain.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public Schedule()
        {
            
        }

        public Schedule(int reservedCount, DateTime startTime ,DateTime endTime)
        {
            ReservedCount = reservedCount;
            StartTime = startTime;
            EndTime = endTime;
            Validate();
        }

        public int ReservedCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public VehicleInspectionCenter Centers{ get; private set; }
        public Guid CenterId { get; set; }
        public List<Appointment> Appointments { get; set; } = new();

        public override void Validate()
        {
            if (StartTime >= EndTime)
                throw new Exception("Time Managing is not match !");
        }
    }
}
