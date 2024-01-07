using cityBikeApp.Domain.src.Entities;

namespace cityBikeApp.Business.src.Services.Abstractions
{
    public interface IStationService
    {
        Task<List<Station>> GetAllStationAsync();
        Task<Station> GetOneStationAsync(int id);
    }
}