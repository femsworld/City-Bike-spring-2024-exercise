using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cityBikeApp.Business.src.Services.Abstractions;
using cityBikeApp.Domain.src.Entities;
using Microsoft.AspNetCore.Mvc;

namespace cityBikeApp.WebApi.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestConString : ControllerBase
    {
        private IStationService _stationService;
        public TestConString(IStationService stationService)
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
    }
}