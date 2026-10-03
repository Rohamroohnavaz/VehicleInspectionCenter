using InspectionCenter.Application.ServiceDtos;
using InspectionCenter.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Models;

namespace WebLayer.Controllers
{
    [ApiController]
    [Route("/Inspection/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpPost("/AddCar")]
        //public async Task<IActionResult> AddCarWithChassisNumber([FromQuery] string chassisNumber)
        //{
        //    await _userService.AddCarsByChassisNumberAsync(chassisNumber);
        //    return Ok(ResponseDto.Success());
        //}

        [HttpPost("/ApplyAppointment")]
        public async Task<IActionResult> ApplyAppointment([FromBody] CreateAppointmentDto dto
            , [FromRoute] Guid userId, [FromRoute] Guid scheduleId)
        {
            await _userService.ApplyAppointmentAsync(dto ,userId, scheduleId);
            return Ok(ResponseDto.Success());
        }
    }
}
