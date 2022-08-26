using Entities.Concrete;
using System.Collections.Generic;

namespace HotelBooking.Areas.HotelAdmin.ViewModels
{
    public class ChartVM
    {
        public List<Room> Rooms { get; set; }
        public List<Comment> Comments { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
