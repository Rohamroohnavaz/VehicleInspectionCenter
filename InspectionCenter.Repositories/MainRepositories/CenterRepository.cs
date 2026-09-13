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
    public class CenterRepository : GenericRepository<VehicleInspectionCenter>, ICenterRepository
    {
        public CenterRepository(InspectionDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<VehicleInspectionCenter>> GetActiveCentersAsync()
        {
            return await _dbContext.Centers
                .AsQueryable()
                .Where(c => c.IsActive == true && c.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<VehicleInspectionCenter?> GetCenterByCityId(Guid cityId)
        {
            return await _dbContext.Centers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CityId == cityId);
        }

        public async Task<List<VehicleInspectionCenter>> GetCentersByCityId(Guid cityId)
        {
            return await _dbContext.Centers
                .AsNoTracking()
                .Where(c => c.CityId == cityId && c.IsActive == true)
                .ToListAsync();
        }
    }
}
