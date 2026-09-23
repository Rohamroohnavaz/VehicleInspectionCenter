using InspectionCenter.Domain.Entities;
using InspectionCenter.Repositories.MainRepositories.GenericRepo;
using InspectionCenter.Repositories.RepoDtos;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.RepositoryInterface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        //Task<Guid> RegisterUser(string email, string password, string phoneNumber);

        //Task AddCarWithChassisNumberAsync(Car entity);

        Task<User> FindByNameAsync(string firstName);

        Task<User> FindByEmailAsync(string email);

        Task<User> FindByPhoneNumberAsync(string phoneNumber);

        Task<bool> ExistUserByEmailAsync(string email);

        Task<bool> ExistUserByPasswordAsync(string password);

        Task<bool> ExistUserByPhoneNumberAsync(string phoneNumber);

        Task<List<User>> GetUsersByRoleAsync(string userRole);

        Task<List<UserInfoDto>> GetAllUsersAsync();
    }
}
