using ASS_MVC.Models;

namespace ASS_MVC.Iservice
{
    public interface IUser
    {
        public List<User> Getall();
        public bool Add(User user);
        public bool Update(User user);
        public bool Delete(User user);

    }
}
