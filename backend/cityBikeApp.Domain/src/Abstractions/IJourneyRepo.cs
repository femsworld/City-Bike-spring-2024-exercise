using cityBikeApp.Domain.src.Entities;

namespace cityBikeApp.Domain.src.Abstractions
{
    public interface IJourneyRepo
    {
         Task<List<Journey>> GetAllJourneyAsync();
        Task<Journey> GetOneJourney(int id);
    }
}