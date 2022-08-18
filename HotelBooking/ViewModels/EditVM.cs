using System.ComponentModel.DataAnnotations;

namespace HotelBooking.ViewModels
{
    public class EditVM
    {
        [Required, StringLength(maximumLength: 15)]
        public string firstname { get; set; }
        [Required, StringLength(maximumLength: 15)]
        public string lastname { get; set; }
        [Required, StringLength(maximumLength: 15)]
        public string username { get; set; }
        [DataType(DataType.Password)]
        public string currentpassword { get; set; }
        [Required, DataType(DataType.Password)]
        public string password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(password))]
        public string confirmpassword { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string phonenumber { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string email { get; set; }
    }
}
