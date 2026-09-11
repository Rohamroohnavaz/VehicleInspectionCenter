using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.RepoDtos
{
    public class CarDto
    {
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string ChassisNumber { get; set; }
        public string PlateNumber { get; set; }
        public Guid OwnerId { get; set; }
    }
}
