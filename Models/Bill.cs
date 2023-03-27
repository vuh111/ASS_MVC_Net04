using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASS_MVC.Models
{
    public class Bill 
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserId { get; set; }
        public int Status { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual User User { get; set; }
    }
}