using InspectionCenter.Domain.Entities;
using InspectionCenter.Repositories.MainRepositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Repositories.RepositoryInterface
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<bool> ExistAppointmentByCarIdAsync(Guid carId);

        Task<List<Appointment>> GetActiveAppointmentsAsync();

        Task<Appointment?> GetAppointmentByCarIdAsync(Guid carId);

        Task<Appointment?> GetAppointmentByScheduleIdAsync(Guid scheduleId);

        Task<List<Appointment>> GetAppointmentByCenterIdAsync(Guid centerId);

        Task<Appointment?> GetAppointmentWithSchedule(Guid scheduleId);

        Task<bool> IsReserveAsync(Guid Id);
    }
}
