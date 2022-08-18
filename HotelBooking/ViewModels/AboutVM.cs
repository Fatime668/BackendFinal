using Entities.Concrete;
using System.Collections;
using System.Collections.Generic;

namespace HotelBooking.ViewModels
{
    public class AboutVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Approach> Approaches { get; set; }
    }
}
