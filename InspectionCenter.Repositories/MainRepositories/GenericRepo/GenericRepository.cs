using InspectionCenter.Domain.Entities.Abstraction;
using InspectionCenter.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.MainRepositories.GenericRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly InspectionDbContext _dbContext;

        public GenericRepository(InspectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T item)
        {
            await _dbContext.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var query = _dbContext.Set<T>()
                .AsQueryable().Where(x => x.IsDeleted == false);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, bool tracking = false)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();

        }

        public async Task UpdateAsync(Guid id)
        {
            _dbContext.Update(id);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity is null)
                return;

            entity.SetDelete(id);
            await _dbContext.SaveChangesAsync();
        }

        public async Task HardDeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if(entity is null) return;

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
