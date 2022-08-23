using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Booking : BaseEntity
    {
        [Required]
        public DateTime ArrivalDate { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public byte Adults { get; set; }
        [Required]
        public byte Children { get; set; }
        public int BookingStatusId { get; set; }
        public BookingStatus Status { get; set; }
        public string AppUserId { get; set; }
        public AppUser  AppUser { get; set; }
        [Required]
        public int? RoomId { get; set; }
        public Room Room { get; set; }
    }
}
