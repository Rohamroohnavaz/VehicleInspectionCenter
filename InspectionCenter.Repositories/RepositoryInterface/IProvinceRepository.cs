using InspectionCenter.Domain.Entities;
using InspectionCenter.Repositories.MainRepositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.RepositoryInterface
{
    public interface IProvinceRepository : IGenericRepository<Province>
    {
        Task<Province?> FindByProvinceNameAsync(string provinceName);
    }
}
