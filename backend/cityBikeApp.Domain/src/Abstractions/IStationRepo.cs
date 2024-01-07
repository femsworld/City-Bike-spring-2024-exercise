using cityBikeApp.Domain.src.Entities;

namespace cityBikeApp.Domain.src.Abstractions
{
    public interface IStationRepo
    {
        Task<List<Station>> GetAllStationAsync();
        Task<Station> GetOneStationAsync(int id);
        Task<int> GetTotalJourneysStartingFromStationAsync(int stationId);
        Task<int> GetTotalJourneysEndingAtStationAsync(int stationId);
        Task<double> GetAverageDistanceOfJourneysStartingFromStationAsync(int stationId);
        Task<double> GetAverageDurationOfJourneysStartingFromStationAsync(int stationId);
    }
}