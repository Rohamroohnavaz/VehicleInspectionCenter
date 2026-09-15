using InspectionCenter.Application.ServiceDtos;
using InspectionCenter.Application.ServiceInterfaces;
using InspectionCenter.Repositories.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.MainServices
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<GetCityDto>> GetAllOfCitiesOfProvinceAsync(Guid provinceId)
        {
            var cities = await _cityRepository.GetCitiesByProvinceIdAsync(provinceId);

            return cities.Select(x => new GetCityDto
            {
                Id = x.Id,
                Name = x.CityName,
                ProvinceId = provinceId,
            }).ToList();
        }
    }
}
