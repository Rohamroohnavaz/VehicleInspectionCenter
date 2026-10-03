using InspectionCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Application.ServiceInterfaces
{
    public interface ITokenService
    {
        (string token, DateTime expires) CreateToken(User user);
    }
}
