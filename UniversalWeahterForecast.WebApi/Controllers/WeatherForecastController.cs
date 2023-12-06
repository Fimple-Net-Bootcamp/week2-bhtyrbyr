using Microsoft.AspNetCore.Mvc;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs;
using UniversalWeahterForecast.BusinessLayer.Queries;

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
        public IActionResult Get([FromQuery] WeatherForecastGetQueries filters)
        {
            try
            {
                var values = _service.TGetList(filters);
                return Ok(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                var values = _service.TGetById(Id);
                return Ok(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _service.TDelete(Id);
                return NoContent();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("")]
        public IActionResult Create([FromBody] CreateWeatherForecastDTO model)
        {
            try
            {
                var modelId = _service.TInsert(model);
                var newModel = _service.TGetById(modelId);
                return CreatedAtAction(nameof(GetById), new { id = modelId }, newModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateWithDTO(int Id, UpdateWeatherForecastDTO model)
        {
            try
            {
                _service.TUpdate(Id, model);
                return Ok();
                //return CreatedAtAction(nameof(GetById), new { id = modelId }, newModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{Id}")]
        public IActionResult UpdateWithPatch(int Id, UpdateWeatherForecastDTO model)
        {
            _service.TUpdate(Id, model);
            return Ok();
        }
    }
}