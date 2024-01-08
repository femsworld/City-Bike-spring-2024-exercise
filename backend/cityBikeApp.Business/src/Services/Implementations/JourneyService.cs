using cityBikeApp.Business.src.Services.Abstractions;
using cityBikeApp.Domain.src.Abstractions;
using cityBikeApp.Domain.src.Entities;

namespace cityBikeApp.Business.src.Services.Implementations
{
    public class JourneyService : IJourneyService
    {
        private readonly IJourneyRepo _journeyRepo;

        public JourneyService (IJourneyRepo journeyRepo)
        {
            _journeyRepo = journeyRepo;
        }
        public async Task<List<Journey>> GetAllJourneyAsync()
        {
            // throw new NotImplementedException();
            var journeys = await _journeyRepo.GetAllJourneyAsync();
            return journeys;
        }

        public async Task<Journey> GetOneJourneyAsync(int id)
        {
            // throw new NotImplementedException();
            var foundJourney = await _journeyRepo.GetOneJourneyAsync(id);
            return foundJourney;
        }
    }
}