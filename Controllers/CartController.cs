using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASS_MVC.Iservice;
using ASS_MVC.Service;
using ASS_MVC.Models;
using Newtonsoft.Json;

namespace ASS_MVC.Controllers
{
    public class CartController : Controller
    {
        ICart _CartService = new CartService();
        ICartDetail _CartDetailService = new CartDetailService();
        User curren_user { get; set; }
        CartViewIservice _CartView = new CartViewService();
        // GET: CartController1   
        public ActionResult Cart()
        {
           ViewBag.current_user = curren_user;   
            List<CartView> list= _CartView.Getall();
            var y =list.Count();
            return View(list);
        }

        // GET: CartController1/Details/5
        public IActionResult TakeUser(User user)
        {
            curren_user= user;
            return RedirectToAction("Index", "Home", curren_user);
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController1/Create
        [HttpPost]
        public ActionResult Add(string product, string quantity)
        {
            Product Product =JsonConvert.DeserializeObject<Product>(product);
            int Quantity = JsonConvert.DeserializeObject<int>(quantity);
            /*int quantity = int.Parse(form["quantity"]);
            _CartView.Add(product,quantity);*/
           _CartView.Add(Product, Quantity);
            return RedirectToAction(nameof(Cart));
        }

        // POST: CartController1/Create
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

        // GET: CartController1/Edit/5
        public IActionResult Increa(Guid Id)
        {
            CartDetail _cart = _CartDetailService.Getall().FirstOrDefault(x=>x.Id== Id);
            if (_cart != null)
            {
                _cart.Quantity++;
                _CartDetailService.Update(_cart);
            }
            return RedirectToAction(nameof(Cart));
        }
        public IActionResult Decrea(Guid Id)
        {
            CartDetail _cart = _CartDetailService.Getall().FirstOrDefault(x => x.Id == Id);
            if (_cart != null)
            {
                _cart.Quantity--;
                _CartDetailService.Update(_cart);
            }
            return RedirectToAction(nameof(Cart));
        }
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController1/Edit/5
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

        // GET: CartController1/Delete/5
        public ActionResult Delete(Guid Id)
        {
            var product_incart=_CartDetailService.Getall().FirstOrDefault(x=>x.Id== Id);
            if (product_incart != null) {
                _CartDetailService.Delete(product_incart);
            }
            
            return RedirectToAction("Cart");
        }

        // POST: CartController1/Delete/5
    
       
    }
}
