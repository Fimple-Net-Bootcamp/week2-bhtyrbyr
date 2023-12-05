using Microsoft.AspNetCore.Mvc;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.BusinessLayer.Queries;
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
        public IActionResult Get([FromQuery] WeatherForecastGelAllQueries filters)
        {
            var values = _service.TGetList(filters);
            return Ok(values);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var values = _service.TGetById(Id);
            return Ok(values);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteById(int Id)
        {
            _service.TDelete(Id);
            return Ok();
        }
    }
}