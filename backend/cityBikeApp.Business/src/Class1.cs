namespace cityBikeApp.Business;

public class Class1
{

}

// using System;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

// public class Station
// {
//     [Key]
//     public int Id { get; set; }

//     [MaxLength(100)]
//     public string StationName { get; set; }

//     [MaxLength(100)]
//     public string StationAddress { get; set; }

//     [MaxLength(100)]
//     public string CoordinateX { get; set; }

//     [MaxLength(100)]
//     public string CoordinateY { get; set; }
// }

// public class Journey
// {
//     [Key]
//     public int Id { get; set; }

//     public DateTime? DepartureDateTime { get; set; }

//     public DateTime? ReturnDateTime { get; set; }

//     public int DepartureStationId { get; set; }

//     [ForeignKey("DepartureStationId")]
//     public virtual Station DepartureStation { get; set; }

//     public int ReturnStationId { get; set; }

//     [ForeignKey("ReturnStationId")]
//     public virtual Station ReturnStation { get; set; }

//     public int? Distance { get; set; }

//     public int? Duration { get; set; }
// }

