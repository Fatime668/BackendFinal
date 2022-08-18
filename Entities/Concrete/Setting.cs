using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Setting:BaseEntity
    {
        [Required]
        public string Key { get; set; }
        public string Value { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
