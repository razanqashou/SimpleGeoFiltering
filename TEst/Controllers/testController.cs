using Microsoft.AspNetCore.Mvc;
using SimpleGeoFiltering;
using SimpleGeoFiltering.DTOs;
using TEst;
using SimpleGeoFiltering.Interfaces;



namespace testttt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase

        

    {


        private readonly IGeoFilterService _geoFilterService;

        public TestController(IGeoFilterService geoFilterService)
        {
            _geoFilterService = geoFilterService;
        }

    


        [HttpPost("filter")]
        public IActionResult FilterPoints([FromBody] FilterRequest request)
        {
            var result = _geoFilterService.FindWithinRadius(
            request.Center,
            request.Points,
            request.RadiusKm,         
            request.DisplayUnit,      
            request.Country,
            request.Region,
            request.Tags
        );

            return Ok(result);
        }

    }
}
