using InspectionCenter.Domain.Entities;
using InspectionCenter.Repositories.MainRepositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.RepositoryInterface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindByNameAsync(string firstName);

        Task<User?> FindByPhoneNumberAsync(string phoneNumber);

        Task<bool> ExistUserByEmailAsync(string email);

        Task<bool> ExistUserByPasswordAsync(string password);

        Task<List<User>> GetUsersByRoleAsync(string userRole);

        Task<List<User>> GetAllUsersAsync();
    }
}
