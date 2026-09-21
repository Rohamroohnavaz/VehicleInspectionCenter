using InspectionCenter.Application.ServiceDtos;
using InspectionCenter.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Models;

namespace WebLayer.Controllers
{
    [ApiController]
    [Route("/Inspection/Appointment")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("/CreateAppointment")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDto dto)
        {
            await _appointmentService.CreateAppointmentAsync(dto);
            return Ok(ResponseDto.Success());
        }

        [HttpGet("/GetAppointments")]
        public async Task<IActionResult> GetAllAppointments([FromRoute] Guid centerId)
        {
            var appointments = await _appointmentService.GetAvailableAppointments(centerId);
            return Ok(appointments);
        }
    }
}
