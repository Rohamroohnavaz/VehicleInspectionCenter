using InspectionCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.ServiceDtos
{
    public class CreateAppointmentDto
    {
        public string ResultText { get; set; }
        public int Capacity { get; set; }
        public Guid CarId { get; set; }
        public Guid CenterId { get; set; }
        public Guid ScheduleId { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
