using Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.ViewModels
{
    public class BookingVM
    {
        [Required, DataType(DataType.DateTime)]
        public DateTime ArrivalDate { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime DepartureDate { get; set; }
        [Required]
        public byte Adults { get; set; }
        [Required]
        public byte Children { get; set; }
        public AppUser AppUser { get; set; }
        public int? RoomId { get; set; }
        public Room Room { get; set; }
        [Required]
        public string ArrivalDateTime { get; set; }
        [Required]
        public string DepartureDateTime { get; set; }
        [Required]
        public string DepartureTime { get; set; }
        [Required]

        public string ArrivalTime { get; set; }
    }
}
