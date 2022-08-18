using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class RoomType:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public virtual List<Room> Rooms { get; set; }
    }
}
