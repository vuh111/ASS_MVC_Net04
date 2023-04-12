using ASS_MVC.Iservice;
using ASS_MVC.Models;

namespace ASS_MVC.Service
{
    public class UserService : IUser
    {
        ShopDbContext Context;
        public UserService()
        {
            Context = new ShopDbContext();
        }
        public bool Add(User user)
        {
            try
            {
                user.Id=Guid.NewGuid();
                Context.Users.Add(user);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Delete(User user)
        {
            try
            {
                var removeUser = Context.Users.ToList().FirstOrDefault(p => p.Id == user.Id);
                Context.Users.Remove(removeUser);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public List<User> Getall()
        {
            return Context.Users.ToList();
        }

        public bool Update(User user)
        {
            try
            {
                var updateUser = Context.Users.ToList().FirstOrDefault(p => p.Id == user.Id);
                updateUser.Bills = user.Bills;
                updateUser.Cart = user.Cart;
                updateUser.Password = user.Password;
                updateUser.Role = user.Role;
                updateUser.RoleId = user.RoleId;
                updateUser.Username = user.Username;
                updateUser.Status = user.Status;
                Context.Users.Update(updateUser);
                Context.SaveChanges();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
