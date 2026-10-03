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
    public class CenterService : ICenterService
    {
        private readonly ICenterRepository _centerRepository;

        public CenterService(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }

        public async Task<GetCenterDto?> GetActiveCenterByIdAsync(Guid cityId)
        {
            var activeCenter = await _centerRepository.GetACenterByCityIdAsync(cityId);
            return activeCenter;
        }

        public async Task<List<CenterDto>> GetActiveCentersAsync()
        {
            var centers = await _centerRepository.GetActiveCentersAsync();

            return centers.Select(x => new CenterDto
            {
                Name = x.CenterName,
                Address = x.Address,
                Capacity = x.Capacity,
                LineCount = x.LineCount,
                Report = x.Report
            }).ToList();
        }

        public async Task<List<CenterDto>> GetCentersByCityIdAsync(Guid cityId)
        {
            var centers = await _centerRepository.GetCentersByCityIdAsync(cityId);

            return centers.Select(x => new CenterDto
            {
                Name = x.CenterName,
                Address = x.Address,
                Capacity = x.Capacity,
                LineCount = x.LineCount,
                Report = x.Report
            }).ToList();
        }
    }
}
