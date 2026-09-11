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
        Task<Guid> RegisterUser(string email, string password, string phoneNumber);

        Task<Car?> AddCarWithChassisNumberAsync(string chassisNumber);

        Task<User> FindByNameAsync(string firstName);

        Task<User?> FindByPhoneNumberAsync(string phoneNumber);

        Task<bool> ExistUserByEmailAsync(string email);

        Task<bool> ExistUserByPasswordAsync(string password);

        Task<List<User>> GetUsersByRoleAsync(string userRole);

        Task<List<User>> GetAllUsersAsync();

        Task AddCarsAsync(Car? car);

        Task<List<Appointment>> GetActiveAppointmentsAsync();

        Task<List<Province>> GetSpecificProvincesAsync();
    }
}
