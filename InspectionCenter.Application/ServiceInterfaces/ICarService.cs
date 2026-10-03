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
    public interface ICarService
    {
        Task AddCarByInfoAsync(CarDto dto);

        Task AddCarWithChassisNumber(AddCarDto dto, Guid userId);

        Task<List<CarDto>> GetCarsForUserAsync(Guid ownerId);
    }
}
