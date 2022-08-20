using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.ViewModels
{
    public class CommentVM
    {
        public Comment Comment { get; set; }
        public string Email { get; set; }
        public AppUser AppUser { get; set; }
        [StringLength(255), Required]
        public string Name { get; set; }
        [StringLength(255), Required]
        public string Message { get; set; }
        public string CreateDate { get; set; }

        [Range(1, 5), Required]
        public byte Star { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}
