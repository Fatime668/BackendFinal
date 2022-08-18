using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Team : BaseEntity
    {
        [Required,StringLength(maximumLength:25)]
        public string Name { get; set; }
        [Required,StringLength(maximumLength:50)]
        public string Position { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}