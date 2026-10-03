using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.RepoDtos
{
    public class GetCenterDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public int LineCount { get; set; }
        public string Report { get; set; }
    }
}
