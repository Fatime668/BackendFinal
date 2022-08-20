using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Room:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public byte NoOfBed { get; set; }
        [Required]
        public byte NoOfBath { get; set; }
        public string Location { get; set; }
        [Required]
        public double Size { get; set; }
        public bool Status { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsPopular { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public List<RoomPicture> RoomPictures { get; set; }
        public List<RoomAmentiy> RoomAmentiys { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Booking> Bookings { get; set; }
        [Required]
        public string Description { get; set; }
        [NotMapped]
        public IFormFile MainImage { get; set; }
        [NotMapped]
        public List<IFormFile> AnotherImages { get; set; }
        [NotMapped]
        public List<int> ImageIds { get; set; }
        [NotMapped]
        public List<int> AmenityIds { get; set; }
    }
}
