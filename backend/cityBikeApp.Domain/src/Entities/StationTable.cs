using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cityBikeApp.Domain.src.Entities
{
    public class StationTable : BaseEntity
    {
        public string StationName { get; set; } = default!;
        public string StationAddress { get; set; } = default!;
        public string CoordinateX { get; set; } = default!;
        public string CoordinateY { get; set; } = default!;

    }
}