using InspectionCenter.Domain.Entities;
using InspectionCenter.Infrastructure.Context;
using InspectionCenter.Repositories.MainRepositories.GenericRepo;
using InspectionCenter.Repositories.RepoDtos;
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

        public async Task<GetCenterDto?> GetACenterByCityIdAsync(Guid cityId)
        {
            return await _dbContext.Centers
                .AsNoTracking()
                .Where(c => c.IsActive == true && c.IsDeleted == false && c.CityId == cityId)
                .Select(c => new GetCenterDto
                {
                    Name = c.CenterName,
                    Address = c.Address,
                    Capacity = c.Capacity,
                    LineCount = c.LineCount,
                    Report = c.Report
                }).FirstOrDefaultAsync();
                
        }

        public async Task<List<VehicleInspectionCenter>> GetCentersByCityIdAsync(Guid cityId)
        {
            return await _dbContext.Centers
                .AsNoTracking()
                .Where(c => c.CityId == cityId 
                       && c.IsDeleted == false
                       && c.IsActive == true)
                .ToListAsync();
        }
    }
}
