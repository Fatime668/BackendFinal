using Entities.Concrete;

namespace HotelBooking.Areas.HotelAdmin.ViewModels
{
    public class ChartVM
    {
        public Room Room { get; set; }
        public Comment Comment { get; set; }
        public AppUser AppUser { get; set; }
        public Booking Booking { get; set; }
    }
}
