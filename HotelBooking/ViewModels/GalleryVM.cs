using Entities.Concrete;
using System.Collections.Generic;

namespace HotelBooking.ViewModels
{
    public class GalleryVM
    {
        public List<Gallery> Galleries { get; set; }
        public List<Category> Categories { get; set; }
        public Gallery Gallery { get; set; }
        public int? CategoryId { get; set; }
    }
}
