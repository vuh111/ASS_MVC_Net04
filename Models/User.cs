using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASS_MVC.Models
{
    public class User
    {
         public Guid Id { get; set; }
        public string Username { get; set; }
        public Guid RoleId { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual Role Role { get; set; }
        public virtual Cart Cart { get; set; }
    }
}