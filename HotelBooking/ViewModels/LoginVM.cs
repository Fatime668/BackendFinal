using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.ViewModels
{
    public class LoginVM
    {
        [Required,StringLength(maximumLength:15)]
        public string Username { get; set; }
        [Required, StringLength(maximumLength: 15)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
