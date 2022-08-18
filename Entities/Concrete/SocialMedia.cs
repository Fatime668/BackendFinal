using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class SocialMedia:BaseEntity
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }

    }
}
