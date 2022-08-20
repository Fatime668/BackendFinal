using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Comment:BaseEntity
    {
        [StringLength(255), Required]
        public string Name { get; set; }
        [StringLength(255), Required]
        public string Email { get; set; }
       
        [StringLength(1000), Required]
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
        public  DateTime CreatedDate { get; set; }
        
        [Required, Range(1, 5)]
        public int Star { get; set; }
        public bool Status { get; set; }
        public AppUser AppUser { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        

    }
}
