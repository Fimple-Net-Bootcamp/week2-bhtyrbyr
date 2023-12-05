using Microsoft.AspNetCore.Mvc;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.EntityLayer.Entitys;

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
        public IActionResult Get([FromQuery] Dictionary<string, string> filters)
        {
            var values = _service.TGetList(filters);
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