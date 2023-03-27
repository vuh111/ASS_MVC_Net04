using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASS_MVC.Models
{
    public class CartDetail
    {
        
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid IdSP { get; set; }
        public int Quantity { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}