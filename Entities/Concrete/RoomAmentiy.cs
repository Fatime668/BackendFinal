using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RoomAmentiy:BaseEntity
    {
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
