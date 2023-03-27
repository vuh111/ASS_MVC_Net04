using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASS_MVC.Models
{
    public class Role
    {
         public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public virtual List<User> Users { get; set;}
    }
}