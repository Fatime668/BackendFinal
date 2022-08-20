using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Booking : BaseEntity
    {
        [Required,DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
        [Required]
        public byte Adults { get; set; }
        [Required]
        public byte Children { get; set; }
        public AppUser  AppUser { get; set; }
        public int? RoomId { get; set; }
        public Room Room { get; set; }
        public bool IsReserved { get; set; }
        [NotMapped]
        public string ArrivalDateTime => ArrivalDate.ToString("MM/dd/yyyy");
        [NotMapped]
        public string DepartureDateTime => DepartureDate.ToString("MM/dd/yyyy");
        [NotMapped]
        public string DepartureTime => DepartureDate.ToString("hh:mm tt");
        [NotMapped]
        public string ArrivalTime => ArrivalDate.ToString("hh:mm tt");

    }
}
