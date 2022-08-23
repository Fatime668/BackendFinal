using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class BookingStatus:BaseEntity
    {
        public string Status { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
