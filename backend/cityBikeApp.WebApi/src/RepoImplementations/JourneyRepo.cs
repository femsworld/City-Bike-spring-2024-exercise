using cityBikeApp.Domain.src.Abstractions;
using cityBikeApp.Domain.src.Entities;
using cityBikeApp.WebApi.src.Database;
using Microsoft.EntityFrameworkCore;

namespace cityBikeApp.WebApi.src.RepoImplementations
{
    public class JourneyRepo : IJourneyRepo
    {
        private DbSet<Journey> _journeys;
        private readonly DatabaseContext _context;

        public JourneyRepo(DatabaseContext context)
        {
            _journeys = _context.Journey;
        }
        public async Task<List<Journey>> GetAllJourneyAsync()
        {
            // throw new NotImplementedException();
            return await _journeys.ToListAsync();
        }

        public async Task<Journey> GetOneJourney(int id)
        {
            // throw new NotImplementedException();
            return await _context.Journey.FindAsync(id);
        }
    }
}