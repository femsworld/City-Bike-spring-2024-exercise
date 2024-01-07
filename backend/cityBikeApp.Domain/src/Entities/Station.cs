
namespace cityBikeApp.Domain.src.Entities
{
    public class Station : BaseEntity
    {
        public string StationName { get; set; } = default!;
        public string StationAddress { get; set; } = default!;
        public string CoordinateX { get; set; } = default!;
        public string CoordinateY { get; set; } = default!;
    }
}