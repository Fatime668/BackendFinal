using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Gallery:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Subtitle { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
