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

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(_service.TGetList());
        }
    }
}