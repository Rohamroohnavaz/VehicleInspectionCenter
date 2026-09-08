using InspectionCenter.Domain.Entities.Abstraction;
using InspectionCenter.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.MainRepositories.GenericRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly InspectionDbContext _dbContext;

        public GenericRepository(InspectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
