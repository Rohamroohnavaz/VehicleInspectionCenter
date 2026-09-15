using InspectionCenter.Application.ServiceDtos;
using InspectionCenter.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebLayer.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/AddCar")]
        public async Task<IActionResult> AddCarWithChassisNumber([FromQuery] string chassisNumber)
        {
            var car = await _userService.AddCarsByChassisNumberAsync(chassisNumber);
            return Ok(car);
        }

        [HttpPost("/ApplyAppointment")]
        public async Task<IActionResult> ApplyAppointment([FromBody] CreateAppointmentDto dto)
        {
            var appointment = _userService.ApplyAppointmentAsync(dto);
            return Ok(appointment);
        }
    }
}
