using Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class AppUser : IdentityUser
    {
        [Required, StringLength(maximumLength: 15)]
        public string Firstname { get; set; }
        [Required, StringLength(maximumLength: 15)]
        public string Lastname { get; set; }
        public bool IsBlock { get; set; }
        public bool IsAdmin { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
