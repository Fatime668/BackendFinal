﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Category:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public virtual List<Gallery> Galleries { get; set; }
    }
}
