using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASS_MVC.Iservice;
using ASS_MVC.Service;
using ASS_MVC.Models;

namespace ASS_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CartController : Controller
    {
        public ICart _CartService;
        public CartController()
        {
            _CartService = new CartService();
        }
        // GET: CartController
        [Route("/Admin/Cart")]
        public ActionResult CartIndex()
        {
            List<Cart> list = _CartService.Getall();
            return View(list);
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
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

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
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
