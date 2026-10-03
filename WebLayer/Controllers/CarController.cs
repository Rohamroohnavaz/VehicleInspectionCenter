using InspectionCenter.Application.ServiceInterfaces;
using InspectionCenter.Repositories.RepoDtos;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Models;

namespace WebLayer.Controllers
{
    [ApiController]
    [Route("/Inspection/Car")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("/CreateCarInSystem")]
        public async Task<IActionResult> CreateCarInSystem([FromBody] CarDto dto)
        {
            await _carService.AddCarByInfoAsync(dto);
            return Ok(ResponseDto.Success());
        }
    }
}
