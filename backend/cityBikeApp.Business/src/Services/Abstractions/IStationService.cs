using cityBikeApp.Domain.src.Entities;

namespace cityBikeApp.Business.src.Services.Abstractions
{
    public interface IStationService
    {
        Task<List<Station>> GetAllStationAsync();
        Task<Station> GetOneStationAsync(int id);
        Task<int> GetTotalJourneysStartingFromStationAsync(int stationId);
        Task<int> GetTotalJourneysEndingAtStationAsync(int stationId);
        Task<double> GetAverageDistanceOfJourneysStartingFromStationAsync(int stationId);
        Task<double> GetAverageDurationOfJourneysStartingFromStationAsync(int stationId);
    }
}