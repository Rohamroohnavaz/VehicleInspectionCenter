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
        private readonly InspectionDbContext _dbContext;

        public AppointmentRepository(InspectionDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Appointment>> GetActiveAppointmentsAsync()
        {
            return await _dbContext.Appointments
                .OrderByDescending(a => a.CreatedAt)
                .Where(a => a.Status == Status.Active)
                .ToListAsync();
        }

        public async Task<Appointment?> GetAppointmentByCarIdAsync(Guid carId)
        {
            return await _dbContext.Appointments
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.CarId == carId);
        }

        public async Task<Appointment?> GetAppointmentByScheduleIdAsync(Guid scheduleId)
        {
            return await _dbContext.Appointments
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.ScheduleId == scheduleId);
        }
    }
}
