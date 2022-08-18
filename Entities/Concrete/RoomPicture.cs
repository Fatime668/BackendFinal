using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RoomPicture:BaseEntity
    {
        public string ImagePath { get; set; }
        public bool? IsMain { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
