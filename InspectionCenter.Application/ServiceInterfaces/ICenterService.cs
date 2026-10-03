using InspectionCenter.Application.ServiceDtos;
using InspectionCenter.Repositories.RepoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.ServiceInterfaces
{
    public interface ICenterService
    {
        Task<List<CenterDto>> GetCentersByCityIdAsync(Guid cityId);

        Task<List<CenterDto>> GetActiveCentersAsync();

        Task<GetCenterDto?> GetActiveCenterByIdAsync(Guid cityId);
    }
}
