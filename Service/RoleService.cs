using ASS_MVC.Iservice;
using ASS_MVC.Models;

namespace ASS_MVC.Service
{
    public class RoleService : IRole
    {
        ShopDbContext Context;
        public bool Add(Role role)
        {
            try
            {
                Context.Roles.Add(role);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Role role)
        {
            try
            {
                var removeRole = Context.Roles.ToList().FirstOrDefault(p => p.RoleId == role.RoleId);
                Context.Roles.Remove(removeRole);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public List<Role> Getall()
        {
            return Context.Roles.ToList();
        }

        public bool Update(Role role)
        {
            try
            {
                var updateRole = Context.Roles.ToList().FirstOrDefault(p => p.RoleId == role.RoleId);
                updateRole.Description = role.Description;
                updateRole.RoleName = role.RoleName;
                updateRole.Status = role.Status;
                updateRole.Users = role.Users;
                Context.Roles.Update(role);
                Context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
    }
}
