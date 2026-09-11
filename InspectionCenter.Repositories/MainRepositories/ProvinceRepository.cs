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
    public class ProvinceRepository : GenericRepository<Province>, IProvinceRepository
    {
        public ProvinceRepository(InspectionDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Province?> FindByProvinceNameAsync(string provinceName)
        {
            return await _dbContext.Provinces
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProvinceName == provinceName);
        }
    }
}
