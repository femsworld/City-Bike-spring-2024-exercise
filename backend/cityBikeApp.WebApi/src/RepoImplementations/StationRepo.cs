using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}