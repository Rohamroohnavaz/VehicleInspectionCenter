using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.MainRepositories.GenericRepo
{
    public interface IGenericRepository<T>
    {
        Task AddAsync(T item);

        Task<T?> GetByIdAsync(Guid id);

        Task<List<T>> GetAllAsync();

        Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, bool tracking = false);

        Task UpdateAsync(Guid id); 

        Task SoftDeleteAsync(Guid id);

        Task HardDeleteAsync(Guid id);
    }
}
