using InspectionCenter.Application.ServiceDtos.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.ServiceInterfaces
{
    public interface IAuthService
    {
        Task Register(RegisterDto dto);

        Task<AuthResponseDto> Login(LoginDto dto);
    }
}
