using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "please enter your firstname"), StringLength(maximumLength: 15)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "please enter your lastname"), StringLength(maximumLength: 15)]

        public string Lastname { get; set; }
        [Required(ErrorMessage = "please enter your username"), StringLength(maximumLength: 15)]

        public string Username { get; set; }
        [Required(ErrorMessage = "please enter your phone number"),DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "please enter your email"), DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required(ErrorMessage = "please enter your password"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "please enter your confirm password"), DataType(DataType.Password), Compare(nameof(Password))]

        public string ConfirmPassword { get; set; }
        [Required]
        public bool TermCondition { get; set; }
        
    }
}
