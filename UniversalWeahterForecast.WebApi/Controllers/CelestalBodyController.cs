using Microsoft.AspNetCore.Mvc;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.BusinessLayer.DTOs.CelestalBodyDTOs;
using UniversalWeahterForecast.BusinessLayer.Queries;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.WebApi.Controllers
{
    [ApiController]
    [Route("/api/v1/CelestalBodies")]
    public class CelestalBodyController : ControllerBase
    {
        private readonly ICelestalBodyService _service;

        public CelestalBodyController(ICelestalBodyService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public IActionResult GetList([FromQuery] GetCelestalBodyQuery filter)
        {
            try
            {
                var list = _service.TGetList(filter);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var item = _service.TGetByID(id);
                return Ok(item);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("")]
        public IActionResult Create(CreateCelestalBodyDTO model)
        {
            try
            {
                var newİtemId = _service.TInsert(model);
                var newItem = _service.TGetByID(newİtemId);
                return CreatedAtAction(nameof(GetById), new { id = newİtemId }, newItem);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.TDelete(id);
                return NoContent();
            }catch
            (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}