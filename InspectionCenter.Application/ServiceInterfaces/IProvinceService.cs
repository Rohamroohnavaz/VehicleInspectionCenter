using InspectionCenter.Application.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.ServiceInterfaces
{
    public interface IProvinceService
    {
        Task<List<ProvincesDto>> GetAllOfProvincesAsync();
    }
}
