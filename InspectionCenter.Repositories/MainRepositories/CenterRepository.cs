using InspectionCenter.Domain.Entities;
using InspectionCenter.Infrastructure.Context;
using InspectionCenter.Repositories.MainRepositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.MainRepositories
{
    public class CenterRepository : GenericRepository<VehicleInspectionCenter>
    {
        public CenterRepository(InspectionDbContext dbContext) : base(dbContext)
        {
        }
    }
}
