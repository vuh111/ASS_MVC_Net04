using Microsoft.AspNetCore.Mvc;
using ASS_MVC.Service;
using ASS_MVC.Iservice;
using System.Runtime.CompilerServices;
using ASS_MVC.Models;


namespace ASS_MVC.Controllers
{
    public class LoginController : Controller
    {
        public User current_user { get; set; }
        public  IUser _UserService;
        public IProduct _ProductService;
        public IRole _RoleService;
        
        
        public LoginController()
        {
            _UserService= new UserService();
            _ProductService= new ProductService();
            _RoleService= new RoleService();
           ;
        }
        
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult TakeUser(IFormCollection form ) {
            string username = form["username"];
            string password = form["password"];
            current_user = _UserService.Getall().FirstOrDefault(x=>x.Username==username && x.Password==password);
            List<Role> roles= _RoleService.Getall().ToList();
            

            if (current_user == null)
            {
                return Redirect("~/Home/Index");
            }
            else
            {
                var permission = _RoleService.Getall().FirstOrDefault(x => x.RoleId == current_user.RoleId);
                if (permission.Status==1)
                {
                    return Redirect("~/Admin/Product");
                }
                else
                {
                  /*  SessionService.setuser(HttpContext.Session, "current_user", current_user);*/
                    return RedirectToAction("TakeUser", "Cart", current_user);
                }
            }
            
        }
        
    }
}
