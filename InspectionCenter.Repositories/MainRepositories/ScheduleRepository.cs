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
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        private readonly InspectionDbContext _dbContext;

        public ScheduleRepository(InspectionDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Schedule>> GetSchedulsByCenterId(Guid centerId)
        {
            return await _dbContext.Schedules
                .Where(s => s.CenterId == centerId)
                .OrderByDescending(s => s.EndTime)
                .ToListAsync();
        }
    }
}
