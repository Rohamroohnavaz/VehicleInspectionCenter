using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.MainRepositories.GenericRepo
{
    public interface IGenericRepository<T>
    {
        Task<T> FindByNameAsync(string name);

        Task AddAsync(T item);

        Task<T> GetByIdAsync(Guid id);

        Task<List<T>> GetAllAsync();

        Task UpdateAsync(Guid id); 

        Task SoftDeleteAsync(Guid id);

        Task HardDeleteAsync(Guid id);
    }
}
