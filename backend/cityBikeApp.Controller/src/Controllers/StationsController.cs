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
        public async Task<ActionResult<GetAllStaionResponse>> GetAllStations([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                if (page < 0 || pageSize <= 0)
                {
                    return BadRequest("page and pageSize must be positive integers.");
                }

                GetAllStaionResponse response;

                if (page == 0)
                {
                    var allStations = await _stationService.GetAllStationAsync();
                    response = new GetAllStaionResponse(1, allStations.ToList());
                }
                else
                {
                    var totalStations = await _stationService.GetAllStationAsync();
                    var totalPages = (int)Math.Ceiling((double)totalStations.Count / pageSize);

                    var paginatedStations = totalStations
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                    response = new GetAllStaionResponse(totalPages, paginatedStations);
                }

                return Ok(response);
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
            if (station == null)
            {
                return NotFound("Staion not found");
            }
            return Ok(station);
        }

        public class GetAllStaionResponse
        {
            public int TotalPages { get; set; }
            public IEnumerable<Station> Stations { get; set; }
            public GetAllStaionResponse(int totalPages, IEnumerable<Station> stations)
            {
                TotalPages = totalPages;
                Stations = stations;
            }
        }
    }
}