using InspectionCenter.Domain.Entities;
using InspectionCenter.Infrastructure.Context;
using InspectionCenter.Repositories.MainRepositories.GenericRepo;
using InspectionCenter.Repositories.RepoDtos;
using InspectionCenter.Repositories.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.MainRepositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(InspectionDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ExistCarByChassisNumber(string chassisNumber)
        {
            return await _dbContext.Cars
                .AsNoTracking()
                .AnyAsync(c => c.ChassisNumber == chassisNumber);
        }

        public async Task<Car?> GetCarByChassisNumberAsync(string chassisNumber)
        {
            return await _dbContext.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ChassisNumber == chassisNumber);
        }

        public async Task<Car?> GetCarByOwnerIdAsync(Guid ownerId)
        {
            return await _dbContext.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(c =>  c.OwnerId == ownerId);
        }

        public async Task<Car?> GetCarByPlateNumberAsync(string plateNumber)
        {
            return await _dbContext.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.PlateNumber == plateNumber);
        }

        public async Task<int> GetCarCountAsync(Guid ownerId)
        {
            return await _dbContext.Cars
                .AsNoTracking()
                .CountAsync(c => c.OwnerId == ownerId);
        }

        public async Task<List<CarDto>> GetCarsAsync()
        {
            return await _dbContext.Cars.Select(c => new CarDto
            {
                CarName = c.CarName,
                CarModel = c.CarModel,
                ChassisNumber = c.ChassisNumber,
                PlateNumber = c.PlateNumber,
                OwnerId = c.OwnerId,
            }).ToListAsync();
        }
    }
}
