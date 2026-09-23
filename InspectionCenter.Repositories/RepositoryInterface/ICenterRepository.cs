using InspectionCenter.Domain.Entities;
using InspectionCenter.Repositories.MainRepositories.GenericRepo;
using InspectionCenter.Repositories.RepoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.RepositoryInterface
{
    public interface ICenterRepository : IGenericRepository<VehicleInspectionCenter>
    {
        Task<List<VehicleInspectionCenter>> GetActiveCentersAsync();

        Task<GetCenterDto?> GetACenterByCityIdAsync(Guid cityId);

        Task<List<VehicleInspectionCenter>> GetCentersByCityIdAsync(Guid cityId);
    }
}
