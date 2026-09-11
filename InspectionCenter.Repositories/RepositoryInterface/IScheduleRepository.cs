using InspectionCenter.Domain.Entities;
using InspectionCenter.Repositories.MainRepositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.RepositoryInterface
{
    public interface IScheduleRepository : IGenericRepository<Schedule>
    {
        Task<List<Schedule>> GetSchedulsByCenterId(Guid centerId);
    }
}
