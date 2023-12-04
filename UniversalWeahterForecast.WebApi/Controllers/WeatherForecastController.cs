using Microsoft.AspNetCore.Mvc;
using UniversalWeahterForecast.BusinessLayer.Abstract;

namespace UniversalWeahterForecast.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;
        public WeatherForecastController(IWeatherForecastService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var values = _service.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _service.TGetByID(id);
            return Ok(values);
        }
    }
}