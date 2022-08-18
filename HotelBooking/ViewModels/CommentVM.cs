using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.ViewModels
{
    public class CommentVM
    {
        public Comment Comment { get; set; }
        [StringLength(255), Required]
        public string Fullname { get; set; }
        [StringLength(255), Required]
        public string CommentContent { get; set; }

        [Range(1, 5), Required]
        public byte Star { get; set; }
        public Room Room { get; set; }
        public Booking Booking { get; set; }

    }
}
