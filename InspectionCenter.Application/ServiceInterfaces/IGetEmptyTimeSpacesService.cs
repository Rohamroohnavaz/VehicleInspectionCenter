using InspectionCenter.Application.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.ServiceInterfaces
{
    public interface IGetEmptyTimeSpacesService
    {
        Task<List<ScheduleDto>> GetEmptyTimeSpaceAsync(Guid centerId ,DateTime date);
    }
}
