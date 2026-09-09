using InspectionCenter.Domain.Entities;
using InspectionCenter.Infrastructure.Context;
using InspectionCenter.Repositories.MainRepositories.GenericRepo;
using InspectionCenter.Repositories.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.MainRepositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly InspectionDbContext _dbContext;

        public CityRepository(InspectionDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<City>> GetCitiesByProvinceIdAsync(Guid provinceId)
        {
            return await _dbContext.Cities
                .Where(c => c.ProvinceId == provinceId)
                .OrderByDescending(c => c.CityName)
                .ToListAsync();
        }

        public async Task<City?> GetCityByNameAsync(string cityName)
        {
            return await _dbContext.Cities
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CityName == cityName);
        }
    }
}
