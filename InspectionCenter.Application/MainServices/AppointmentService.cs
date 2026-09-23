using InspectionCenter.Application.ServiceDtos;
using InspectionCenter.Application.ServiceInterfaces;
using InspectionCenter.Domain.Entities;
using InspectionCenter.Domain.Enums;
using InspectionCenter.Repositories.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.MainServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICenterRepository _centerRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository
            , ICenterRepository centerRepository
            , IScheduleRepository scheduleRepository)
        {
            _appointmentRepository = appointmentRepository;
            _centerRepository = centerRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task CreateAppointmentAsync(CreateAppointmentDto request, Guid userId, Guid scheduleId)
        {
            var car = await _appointmentRepository.GetByIdAsync(request.CarId);
            if (car is null)
                return;

            var center = await _centerRepository.GetByIdAsync(request.CenterId);
            if (center is null)
                return;

            var appointmentReserve = await _appointmentRepository.IsReserveAsync(scheduleId);
            if (appointmentReserve)
                return;

            if (request.CarId == Guid.Empty || request.ScheduleId == Guid.Empty)
                throw new ArgumentException("Invalid request details !");

            var appointment = new Appointment
                (
                  request.ResultText,
                  request.Capacity,
                  request.CarId,
                  request.CenterId,
                  request.ScheduleId,
                  request.ExpireTime
                );

            appointment.ReserveStatus = ReserveStatus.IsReserve;

            await _appointmentRepository.AddAsync(appointment);
        }

        public async Task<List<AppointmentDto>> GetAvailableAppointments(Guid centerId)
        {
            var appointments = await _appointmentRepository.GetActiveAppointmentsAsync();

            return appointments.Select(x => new AppointmentDto
            {
                ResultText = x.ResultText,
                Capacity = x.Capacity,
                CenterId = centerId,
                CarId = x.CarId,
                ExpireTime = x.ExpireTime
            }).ToList();
        }
    }
}
