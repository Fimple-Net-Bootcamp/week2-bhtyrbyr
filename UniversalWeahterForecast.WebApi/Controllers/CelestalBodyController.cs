using Microsoft.AspNetCore.Mvc;
using UniversalWeahterForecast.BusinessLayer.Abstract;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.WebApi.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]s")]
    public class CelestalBodyController : ControllerBase
    {
        private readonly ICelestalBodyService _service;

        public CelestalBodyController(ICelestalBodyService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public IActionResult GetList()
        {
            return Ok(_service.TGetList());
        }

        [HttpGet("Planets")]
        public IActionResult GetPlanets()
        {
            var list = _service.TGetList();
            var planetList = list = list.Where(x => x.IsPlanet == true).ToList();
            return Ok(planetList);
        }

        [HttpGet("Satellites")]
        public IActionResult GetSatellites()
        {
            var list = _service.TGetList();
            var satellitesList = list = list.Where(x => x.IsPlanet == false).ToList();
            return Ok(satellitesList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _service.TGetByID(id);
            return Ok(item);
        }

        [HttpPost("")]
        public IActionResult Create(CelestalBody model)
        {
            _service.TInsert(model);
            return Ok();
        }
    }
}