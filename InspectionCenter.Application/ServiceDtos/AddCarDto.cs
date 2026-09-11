using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.ServiceDtos
{
    public class AddCarDto
    {
        public Guid Id { get; set; }
        public string ChassisNumber { get; set; }
    }
}
