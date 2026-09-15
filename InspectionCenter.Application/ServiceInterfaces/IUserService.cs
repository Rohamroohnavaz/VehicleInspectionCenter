using InspectionCenter.Application.ServiceDtos;
using InspectionCenter.Domain.Entities;
using InspectionCenter.Repositories.RepoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<Car?> AddCarsByChassisNumberAsync(string chassisNumber);

        Task<List<Province>> GetProvincesForUserAsync();

        Task<Guid> RegisterUserAsync(CreateUserDto dto);

        Task UpdateUserInfoAsync(UpdateUserDto dto, Guid id);

        Task<List<ScheduleDto>> GetSchedulesWithCenterId(Guid centerId);

        Task<List<CenterDto>> GetActiveCentersAsync();

        Task ApplyAppointmentAsync(CreateAppointmentDto request);

        Task<List<AppointmentDto>> GetAvailableAppointmentsAsync();
    }
}
