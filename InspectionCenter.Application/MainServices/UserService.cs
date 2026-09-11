using InspectionCenter.Application.ServiceDtos;
using InspectionCenter.Application.ServiceInterfaces;
using InspectionCenter.Domain.Entities;
using InspectionCenter.Repositories.RepoDtos;
using InspectionCenter.Repositories.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.MainServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProvinceRepository _provinceRepository;

        public UserService(IUserRepository userRepository ,IProvinceRepository provinceRepository)
        {
            _userRepository = userRepository;
            _provinceRepository = provinceRepository;
        }

        public async Task<Car?> AddCarsByChassisNumberAsync(string chassisNumber)
        {
            var newCar = await _userRepository.AddCarWithChassisNumberAsync(chassisNumber);
            await _userRepository.AddCarsAsync(newCar);

            return newCar;
        }

        public async Task AppointmentPipeline()
        {
            var provinces = await _userRepository.GetSpecificProvincesAsync();


        }

        //public Task<List<CarDto>> GetUserCarsByNameAsync(string firstName)
        //{

        //}
    }
}
