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
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<List<CarDto>> GetCarsAsync();
        
        Task<Car?> GetCarByOwnerIdAsync(Guid ownerId);

        Task<Car?> GetCarByChassisNumberAsync(string chassisNumber);

        Task<Car?> GetCarByPlateNumberAsync(string plateNumber);

        Task<int> GetCarCountAsync(Guid ownerId);
    }
}
