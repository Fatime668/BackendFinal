using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.ViewModels
{
    public class RoomVM
    {
        public List<Room> Rooms { get; set; }
        public Room Room { get; set; }
        public List<RoomPicture> RoomPictures { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
        public List<Booking> Bookings { get; set; }
        public Booking Booking { get; set; }
    }
}
