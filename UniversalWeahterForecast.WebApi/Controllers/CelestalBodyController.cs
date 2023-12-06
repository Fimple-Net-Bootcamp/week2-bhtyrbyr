using Microsoft.AspNetCore.Mvc;
using UniversalWeahterForecast.BusinessLayer.Abstract;

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
    }
}