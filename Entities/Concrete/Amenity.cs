using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Amenity:BaseEntity
    {
        [Required,StringLength(maximumLength:50)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<RoomAmentiy> RoomAmentiys { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
