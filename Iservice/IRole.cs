using ASS_MVC.Models;

namespace ASS_MVC.Iservice
{
    public interface IRole
    {
        public List<Role> Getall();
        public bool Add(Role role);
        public bool Delete(Role role);
        public bool Update(Role role);
    }
}
