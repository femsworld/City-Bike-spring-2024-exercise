using cityBikeApp.Domain.src.Entities;

namespace cityBikeApp.Business.src.Services.Abstractions
{
    public interface IJourneyService
    {
        Task<List<Journey>> GetAllJourneyAsync();
        Task<Journey> GetOneJourneyAsync(int id);
    }
}