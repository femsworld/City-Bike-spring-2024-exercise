using cityBikeApp.Business.src.Services.Abstractions;
using cityBikeApp.Domain.src.Entities;
using Microsoft.AspNetCore.Mvc;

namespace cityBikeApp.Controller.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StationsController : ControllerBase
    {
        private readonly IStationService _stationService;
        public StationsController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Station>>> GetAllStations()
        {
            try
            {
                var stations = await _stationService.GetAllStationAsync();
                return Ok(stations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStationById(int id)
        {
            var station = await _stationService.GetOneStationAsync(id);
            if(station == null)
            {
                return NotFound("Staion not found");
            }
            return Ok(station);
        }
    }
}