using InspectionCenter.Domain.Entities;
using InspectionCenter.Repositories.MainRepositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.RepositoryInterface
{
    public interface ICityRepository : IGenericRepository<City>
    {
        Task<City?> GetCityByNameAsync(string cityName);

        Task<List<City>> GetCitiesByProvinceIdAsync(Guid provinceId);
    }
}
