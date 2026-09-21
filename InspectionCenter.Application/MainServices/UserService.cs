using InspectionCenter.Application.ServiceDtos;
using InspectionCenter.Application.ServiceInterfaces;
using InspectionCenter.Domain.Entities;
using InspectionCenter.Domain.Enums;
using InspectionCenter.Repositories.RepoDtos;
using InspectionCenter.Repositories.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.MainServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IAppointmentService _appointmentService;

        public UserService(IUserRepository userRepository
            , IProvinceRepository provinceRepository
            , IScheduleRepository scheduleRepository
            , IAppointmentService appointmentService)
        {
            _userRepository = userRepository;
            _provinceRepository = provinceRepository;
            _scheduleRepository = scheduleRepository;
            _appointmentService = appointmentService;
        }

        public async Task ApplyAppointmentAsync(CreateAppointmentDto request)
        {
            var appointmentRequest = await _appointmentService.CreateAppointmentAsync(request);

            if(appointmentRequest == Guid.Empty)
                return;

            if (request.Capacity < 1)
                throw new ArgumentException("We don't have capacity for this appointment");
        }

        //public async Task<List<CenterDto>> GetActiveCentersAsync()
        //{
        //    var centers = await _userRepository.GetActiveAndAvailableCentersAsync();

        //    if (centers.Count == 0)
        //        return null;

        //    return centers.Select(x => new CenterDto
        //    {
        //        Name = x.CenterName,
        //        Address = x.Address,
        //        Capacity = x.Capacity,
        //        LineCount = x.LineCount,
        //        Report = x.Report
        //    }).ToList();
        //}

        //public async Task<List<AppointmentDto>> GetAvailableAppointmentsAsync()
        //{
        //    var appointments = await _userRepository.GetActiveAppointmentsAsync();

        //    return appointments.Select(x => new AppointmentDto
        //    {
        //        ResultText = x.ResultText,
        //        Capacity = x.Capacity,
        //        CarId = x.CarId,
        //        CenterId = x.CenterId,
        //        ExpireTime = x.ExpireTime
        //    }).ToList();
        //}

        //public async Task<List<Province>> GetProvincesForUserAsync()
        //{
        //    var provinces = await _userRepository.GetSpecificProvincesAsync();
        //    return provinces;
        //}

        public async Task<List<ScheduleDto>> GetSchedulesWithCenterId(Guid centerId)
        {
            var schedules = await _scheduleRepository.GetSchedulsByCenterIdAsync(centerId);

            return schedules.Select(x => new ScheduleDto
            {
                ReservedCount = x.ReservedCount,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                CenterId = centerId
            }).ToList();
        }

        public async Task<Guid> RegisterUserAsync(CreateUserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email)
                || string.IsNullOrWhiteSpace(dto.Password)
                || string.IsNullOrWhiteSpace(dto.PhoneNumber))
            {
                throw new Exception("Register data is required !");
            }

            var emailExist = await _userRepository.ExistUserByEmailAsync(dto.Email);

            if (emailExist)
                throw new Exception("This email already exist !");

            var passwordExist = await _userRepository.ExistUserByPasswordAsync(dto.Password);

            if (passwordExist)
                throw new Exception("This password already exist !");

            var phoneNumber = await _userRepository.ExistUserByPhoneNumberAsync(dto.PhoneNumber);

            if (phoneNumber)
                throw new Exception("This phoneNumber already exist !");

            var user = new User(
                dto.FirstName,
                dto.LastName,
                dto.PhoneNumber,
                dto.Email,
                dto.Password,
                dto.Age);

            await _userRepository.AddAsync(user);

            return user.Id;
        }

        public async Task UpdateUserInfoAsync(UpdateUserDto dto, Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if(user is null)
                throw new ArgumentNullException(nameof(user));

            user.UpdateUserInfo(dto.Email, dto.Password, dto.PhoneNumber, dto.UserRole);
            await _userRepository.UpdateAsync(user.Id);
        }
    }
}
