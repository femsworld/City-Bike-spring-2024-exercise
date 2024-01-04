using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cityBikeApp.Domain.src.Entities;

namespace cityBikeApp.Domain.src.Abstractions
{
    public interface IStationRepo
    {
        Task<List<Station>> GetAllStationAsync();
        Task<Station> GetOneStationAsync(int id);
    }
}