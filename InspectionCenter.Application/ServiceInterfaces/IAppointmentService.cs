using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.ServiceInterfaces
{
    public interface IAppointmentService
    {
        Task<bool> ApplyAppointmentForCarAsync();
    }
}
