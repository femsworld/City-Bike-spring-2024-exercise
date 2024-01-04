using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cityBikeApp.Business.src.Services.Abstractions;
using cityBikeApp.Domain.src.Abstractions;
using cityBikeApp.Domain.src.Entities;

namespace cityBikeApp.Business.src.Services.Implementations
{
    public class StationService : IStationService
    {
        private readonly IStationRepo _stationRepo;

        public StationService (IStationRepo stationRepo)
        {
            _stationRepo = stationRepo;
        }
        public async Task<List<Station>> GetAllStationAsync()
        {
            // throw new NotImplementedException();
            var stations = await _stationRepo.GetAllStationAsync();
            return stations;
        }


        public Task<Station> GetOneStationAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}