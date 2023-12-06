using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs;
using UniversalWeahterForecast.BusinessLayer.Queries;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.WebApi.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]s")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;
        public WeatherForecastController(IWeatherForecastService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public IActionResult Get([FromQuery] GetWeatherForeceastListQuery filters)
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

        [HttpGet("CelestalBodies/{id}")]
        public IActionResult GetByCelestalBodyId(int id, [FromQuery] GetWeatherForecastListQueryByCelestalBody filters)
        {
            try
            {
                var values = _service.TGetListByCelestalBodyId(id, filters);
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{Id}")]
        public IActionResult UpdateWithPatch(int Id, [FromBody] JsonPatchDocument<WeatherForecast> model)
        {
            try
            {
                _service.TUpdate(Id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}