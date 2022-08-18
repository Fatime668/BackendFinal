using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Testimonial> Testimonials { get; set; }
        public IEnumerable<RoomType> RoomTypes { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<RoomPicture> RoomPictures { get; set; }
        public Room Room { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public Booking Booking { get; set; }
        public Comment Comment { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Gallery> Galleries { get; set; }

    }
}
