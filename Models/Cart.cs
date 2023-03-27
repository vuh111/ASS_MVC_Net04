using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASS_MVC.Models
{
    public class Cart
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CartDetail> CartDetails {get; set;}
        public virtual User User { get; set; } 
    }
}