using ASS_MVC.Iservice;
using ASS_MVC.Models;
using ASS_MVC.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASS_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        // GET: UserController
        public readonly IUser _User;

        public UserController()
        {
            _User = new UserService();
        }
        [Route("/Admin/User/Index")]
        public ActionResult Index()
        {
            return View(_User.Getall());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        [HttpGet]
        [Route("/Admin/User/Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create( User user)
        {
            try
            {
                _User.Add(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Content("ko add dc");
            }
            return Content("ok roid ay");
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
