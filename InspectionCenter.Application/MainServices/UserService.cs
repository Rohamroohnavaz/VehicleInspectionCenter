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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProvinceRepository _provinceRepository;

        public UserService(IUserRepository userRepository ,IProvinceRepository provinceRepository)
        {
            _userRepository = userRepository;
            _provinceRepository = provinceRepository;
        }

        public Task AppointmentPipeline()
        {
            throw new NotImplementedException();
        }
    }
}
