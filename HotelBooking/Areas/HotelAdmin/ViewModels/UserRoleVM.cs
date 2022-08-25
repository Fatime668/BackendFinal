using System.Collections;
using System.Collections.Generic;

namespace HotelBooking.Areas.HotelAdmin.ViewModels
{
    public class UserRoleVM
    {
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
