using cityBikeApp.Business.src.Services.Abstractions;
using cityBikeApp.Domain.src.Entities;
using Microsoft.AspNetCore.Mvc;

namespace cityBikeApp.Controller.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JourneysController : ControllerBase
    {
        private readonly IJourneyService _journeyService;

        public JourneysController(IJourneyService journeyService)
        {
            _journeyService = journeyService;
            // _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllJourneyResponse>> GetAllJourneys([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                if (page < 0 || pageSize <= 0)
                {
                    return BadRequest("page and pageSize must be positive integers.");
                }

                GetAllJourneyResponse response;

                if (page == 0)
                {
                    var allJourneys = await _journeyService.GetAllJourneyAsync();
                    response = new GetAllJourneyResponse(1, allJourneys.ToList());
                }
                else
                {
                    var totalJourneys = await _journeyService.GetAllJourneyAsync();
                    var totalPages = (int)Math.Ceiling((double)totalJourneys.Count / pageSize);

                    var paginatedJourneys = totalJourneys
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                    response = new GetAllJourneyResponse(totalPages, paginatedJourneys);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetJourneyById(int id)
        {
            var journey = await _journeyService.GetOneJourneyAsync(id);
            if (journey == null)
            {
                return NotFound("Journey information is not availbale");
            }
            return Ok(journey);
        }

        public class GetAllJourneyResponse
        {
            public int TotalPages { get; set; }
            public IEnumerable<Journey> Journeys { get; set; }
            public GetAllJourneyResponse(int totalPages, IEnumerable<Journey> journeys)
            {
                TotalPages = totalPages;
                Journeys = journeys;
            }
        }
    }
}