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
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(InspectionDbContext dbContext) : base(dbContext)
        {
        }
    }
}
