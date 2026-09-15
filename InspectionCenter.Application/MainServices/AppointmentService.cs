using InspectionCenter.Application.ServiceDtos;
using InspectionCenter.Application.ServiceInterfaces;
using InspectionCenter.Domain.Entities;
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

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Guid> CreateAppointmentAsync(CreateAppointmentDto request)
        {
            if(request is null)
                throw new ArgumentNullException(nameof(request));

            if (request.CarId == Guid.Empty || request.ScheduleId == Guid.Empty)
                throw new ArgumentException("Invalid request details !");

            var existCar = await _appointmentRepository.ExistAppointmentByCarIdAsync(request.CarId);

            if (existCar)
                throw new Exception("That car is already exist at this appointment !");

            var appointment = new Appointment
                (
                  request.ResultText,
                  request.Capacity,
                  request.Car,
                  request.CarId,
                  request.Schedule,
                  request.ScheduleId,
                  request.ExpireTime
                );

            await _appointmentRepository.AddAsync(appointment);

            return request.CarId;
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
