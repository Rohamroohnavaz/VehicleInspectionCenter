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
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(InspectionDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ExistAppointmentByCarIdAsync(Guid carId)
        {
            return await _dbContext.Appointments
                .AnyAsync(a => a.CarId == carId);
        }

        public async Task<List<Appointment>> GetActiveAppointmentsAsync()
        {
            return await _dbContext.Appointments
                .AsNoTracking()
                .OrderByDescending(a => a.CreatedAt)
                .Where(a => a.Status == Status.Active 
                      && a.IsDeleted == false
                      && a.IsPassed == true
                      && a.ReserveStatus == ReserveStatus.IsNotReserve)
                .ToListAsync();
        }

        public async Task<Appointment?> GetAppointmentByCarIdAsync(Guid carId)
        {
            return await _dbContext.Appointments
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.CarId == carId);
        }

        public async Task<List<Appointment>> GetAppointmentByCenterIdAsync(Guid centerId)
        {
            return await _dbContext.Appointments
                .AsNoTracking()
                .Where(a => a.CenterId == centerId)
                .ToListAsync();
        }

        public async Task<Appointment?> GetAppointmentByScheduleIdAsync(Guid scheduleId)
        {
            return await _dbContext.Appointments
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.ScheduleId == scheduleId);
        }
    }
}
