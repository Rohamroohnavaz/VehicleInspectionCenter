using InspectionCenter.Domain.Entities;
using InspectionCenter.Domain.Enums;
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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly InspectionDbContext _dbContext;

        public UserRepository(InspectionDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExistUserByEmailAsync(string email)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .AnyAsync(u => u.Email == email);
        }

        public async Task<bool> ExistUserByPasswordAsync(string password)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .AnyAsync(u => u.Password == password);
        }

        public async Task<User> FindByNameAsync(string firstName)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.FirstName == firstName);

            if (user == null)
                throw new ArgumentNullException($"{nameof(user)} can't be null");

            return user;
        }

        public async Task<User?> FindByPhoneNumberAsync(string phoneNumber)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
            
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users
                .Where(u => u.UserRole.ToString() == "NormalUser" 
                         && u.UserRole.ToString() == "Admin")
                .OrderByDescending(u => u.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<User>> GetUsersByRoleAsync(string userRole)
        {
            if(Enum.TryParse<Role>(userRole, true, out Role role))
            {
                return await _dbContext.Users
                    .Where(u => u.UserRole == role)
                    .ToListAsync();
            }

            return new List<User>();
        }
    }
}
