using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cityBikeApp.Domain.src.Entities
{
    public class Journey: BaseEntity
    {
        public DateTime Departure_Date_Time { get; set; }
        public DateTime ReturnDateTime { get; set; }

        [ForeignKey("DepartureStation")]
        public int DepartureStationId { get; set; }
        public Station? DepartureStation { get; set; }

        [ForeignKey("ReturnStation")]
        public int ReturnStationId { get; set; }
        public Station? ReturnStation { get; set; }
        public int Distance { get; set; }
        public int Duration { get; set; }
    }
}