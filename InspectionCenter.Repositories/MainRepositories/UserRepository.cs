using InspectionCenter.Domain.Entities;
using InspectionCenter.Domain.Enums;
using InspectionCenter.Infrastructure.Context;
using InspectionCenter.Repositories.MainRepositories.GenericRepo;
using InspectionCenter.Repositories.RepoDtos;
using InspectionCenter.Repositories.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.MainRepositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(InspectionDbContext dbContext) : base(dbContext)
        {
        }

        //public async Task AddCarsAsync(Car? car)
        //{
        //    await _dbContext.AddAsync(car);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task AddCarWithChassisNumberAsync(Car entity)
        //{
        //    var car = new Car(entity.CarName, entity.CarModel, entity.ChassisNumber, entity.PlateNumber);

        //    await _dbContext.AddAsync(car);
        //}

        public async Task<bool> ExistUserByEmailAsync(string email)
        {
            return await _dbContext.Users
                .AnyAsync(u => u.Email == email);
        }

        public async Task<bool> ExistUserByPasswordAsync(string password)
        {
            return await _dbContext.Users
                .AnyAsync(u => u.Password == password);
        }

        public async Task<bool> ExistUserByPhoneNumberAsync(string phoneNumber)
        {
            return await _dbContext.Users
                .AnyAsync(u => u.PhoneNumber == phoneNumber);
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

        public async Task<List<VehicleInspectionCenter>> GetActiveAndAvailableCentersAsync()
        {
            return await _dbContext.Centers
                .AsNoTracking()
                .Where(c => c.IsActive == true && c.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<List<Appointment>> GetActiveAppointmentsAsync()
        {
            var activeAppointments = await _dbContext.Appointments
                .AsNoTracking()
                .Where(a => a.Status.ToString() == Status.Active.ToString()
                    && a.IsDeleted == false
                    && a.IsPassed == true
                    && a.ReserveStatus == ReserveStatus.IsNotReserve)
                .ToListAsync();

            if (activeAppointments is null)
                throw new ArgumentNullException("Active appointments not found !");

            return activeAppointments;
        }

        public async Task<List<UserInfoDto>> GetAllUsersAsync()
        {
            return await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.UserRole.ToString() == "NormalUser"
                         && u.UserRole.ToString() == "Admin")
                .Select(x => new UserInfoDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    CreatedAt = x.CreatedAt
                })
                .OrderByDescending(u => u.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Province>> GetSpecificProvincesAsync()
        {
            var specificProvinces = await _dbContext.Provinces
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                .OrderBy(p => p.ProvinceName)
                .ToListAsync();

            return specificProvinces;
        }

        public async Task<List<User>> GetUsersByRoleAsync(string userRole)
        {
            if (Enum.TryParse<Role>(userRole, true, out Role role))
            {
                return await _dbContext.Users
                    .Where(u => u.UserRole == role)
                    .ToListAsync();
            }

            return new List<User>();
        }

        //public async Task<Guid> RegisterUser(string email ,string password ,string phoneNumber)
        //{
        //    var user = await _dbContext.Users
        //        .AnyAsync(u => u.Email == email
        //              && u.Password == password
        //              && u.PhoneNumber == phoneNumber);

        //    var newUser = new User();

        //    newUser.SetEmail(email);
        //    newUser.SetPassword(password);
        //    newUser.SetPhoneNumber(phoneNumber);
        //    newUser.SetRole(Role.NormalUser);

        //    await _dbContext.AddAsync(newUser);
        //    await _dbContext.SaveChangesAsync();

        //    return newUser.Id;
        //}
    }
}
