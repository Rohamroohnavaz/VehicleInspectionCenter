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
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task<List<ProvincesDto>> GetAllOfProvincesAsync()
        {
            var provinces = await _provinceRepository.GetAllAsync();

            return provinces.Select(x => new ProvincesDto
            {
                Name = x.ProvinceName
            }).ToList();
        }
    }
}
