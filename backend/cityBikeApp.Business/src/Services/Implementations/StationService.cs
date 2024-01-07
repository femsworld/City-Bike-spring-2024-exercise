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

        public async Task<double> GetAverageDistanceOfJourneysStartingFromStationAsync(int stationId)
        {
            // throw new NotImplementedException();
            return await _stationRepo.GetAverageDistanceOfJourneysStartingFromStationAsync(stationId);
        }

        public async Task<double> GetAverageDurationOfJourneysStartingFromStationAsync(int stationId)
        {
            // throw new NotImplementedException();
            return await _stationRepo.GetAverageDurationOfJourneysStartingFromStationAsync(stationId);
        }

        public async Task<Station> GetOneStationAsync(int id)
        {
            // throw new NotImplementedException();
            var foundStation = await _stationRepo.GetOneStationAsync(id);
            return foundStation;
        }

        public async Task<int> GetTotalJourneysEndingAtStationAsync(int stationId)
        {
            // throw new NotImplementedException();
            return await _stationRepo.GetTotalJourneysEndingAtStationAsync(stationId);
        }

        public async Task<int> GetTotalJourneysStartingFromStationAsync(int stationId)
        {
            // throw new NotImplementedException();
            return await _stationRepo.GetTotalJourneysStartingFromStationAsync(stationId);
        }
    }
}