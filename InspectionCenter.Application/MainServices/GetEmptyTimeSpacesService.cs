using InspectionCenter.Application.ServiceDtos;
using InspectionCenter.Application.ServiceInterfaces;
using InspectionCenter.Repositories.RepositoryInterface;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.MainServices
{
    public class GetEmptyTimeSpacesService : IGetEmptyTimeSpacesService
    {
        private readonly ICenterRepository _centerRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public GetEmptyTimeSpacesService(ICenterRepository centerRepository 
            ,IAppointmentRepository appointmentRepository)
        {
            _centerRepository = centerRepository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<ScheduleDto>> GetEmptyTimeSpaceAsync(Guid centerId ,DateTime date)
        {
            var center = await _centerRepository.GetByIdAsync(centerId);

            if (center == null && !center.IsActive)
                throw new Exception("Invalid Center !");

            var appointments = await _appointmentRepository.GetAppointmentByCenterIdAsync(centerId);

            var schedules = new List<ScheduleDto>();
            return schedules.Select(x => new ScheduleDto
            {
                ReservedCount = x.ReservedCount,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                CenterId = centerId,
            }).ToList();
        }
    }
}
