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
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task AddCarWithChassisNumber(AddCarDto dto ,Guid userId)
        {
            var existCar = await _carRepository.ExistCarByChassisNumber(dto.ChassisNumber);

            if (existCar)
            {
                Console.WriteLine("This car is already exist !");
                return;
            }

            var car = new Car();

            car.SetId(dto.Id);
            car.SetChassisNumber(dto.ChassisNumber);
            car.SetIsActive();

            await _carRepository.AddAsync(car);

            Console.WriteLine("Car Added Successfuly !");
        }

        public async Task<List<CarDto>> GetCarForUserAsync(Guid ownerId)
        {
            var cars = await _carRepository.GetCarByOwnerIdAsync(ownerId);

            return cars.Select(x => new CarDto
            {
                Id = x.Id,
                CarName = x.CarName,
                CarModel = x.CarModel,
                ChassisNumber = x.ChassisNumber,
                PlateNumber = x.PlateNumber,
            }).ToList();
        }
    }
}
