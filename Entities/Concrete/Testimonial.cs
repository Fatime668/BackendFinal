using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Testimonial:BaseEntity
    {
        [Required]
        public string Client { get; set; }
        [Required]
        public string Comment { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
    }
}
