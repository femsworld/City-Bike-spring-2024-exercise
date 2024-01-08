using cityBikeApp.Domain.src.Abstractions;
using cityBikeApp.Domain.src.Entities;
using cityBikeApp.WebApi.src.Database;
using Microsoft.EntityFrameworkCore;

namespace cityBikeApp.WebApi.src.RepoImplementations
{
    public class StationRepo : IStationRepo
    {
        private DbSet<Station> _stations;
        private readonly DatabaseContext _context;

        public StationRepo(DatabaseContext context)
        {
            _stations = context.Station;
            _context = context;
        }
        public async Task<List<Station>> GetAllStationAsync()
        {
            // throw new NotImplementedException();
            return await _stations.ToListAsync();
        }

        public async Task<Station> GetOneStationAsync(int id)
        {
            // throw new NotImplementedException();
            return await _stations.FindAsync(id);
        }

        public async Task<int> GetTotalJourneysStartingFromStationAsync(int stationId)
        {
            // throw new NotImplementedException();
            return await _context.Journey.CountAsync(j => j.DepartureStationId == stationId);
        }

        public async Task<int> GetTotalJourneysEndingAtStationAsync(int stationId)
        {
            // throw new NotImplementedException();
            return await _context.Journey.CountAsync(j => j.ReturnStationId == stationId);
        }

        public async Task<double> GetAverageDistanceOfJourneysStartingFromStationAsync(int stationId)
        {
            // throw new NotImplementedException();
            // return await _context.Journey.Where(j => j.DepartureStationId == stationId).AverageAsync(j => j.Distance);
            var averageDistance = await _context.Journey
                .Where(j => j.DepartureStationId == stationId && j.Distance != null)
                .AverageAsync(j => (double?)j.Distance ?? 0); // Handle null values by providing a default value (0 in this case)

            return averageDistance;
        }

        public async Task<double> GetAverageDurationOfJourneysStartingFromStationAsync(int stationId)
        {
            // throw new NotImplementedException();
            // return await _context.Journey.Where(j => j.DepartureStationId == stationId).AverageAsync(j =>j.Duration);
            return await _context.Journey
        .Where(j => j.DepartureStationId == stationId)
        .AverageAsync(j => (double?)j.Duration) ?? 0;
        }
    }
}