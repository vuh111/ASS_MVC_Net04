using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASS_MVC.Iservice;
using ASS_MVC.Service;
using ASS_MVC.Models;

namespace ASS_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CartDetailController : Controller
    {
        public  ICartDetail _cartDetail;
        public CartDetailController()
        {
            _cartDetail = new CartDetailService();
        }
        // GET: CartDetailController
        [Route("/Admin/CartDetail")]
        public ActionResult CartDetailIndex()
        {
            List<CartDetail> list = _cartDetail.Getall();
            return View(list);
        }

        // GET: CartDetailController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartDetailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartDetailController/Create
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

        // GET: CartDetailController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartDetailController/Edit/5
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

        // GET: CartDetailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartDetailController/Delete/5
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
