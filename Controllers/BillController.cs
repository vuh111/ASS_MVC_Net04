using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASS_MVC.Iservice;
using ASS_MVC.Service;
using ASS_MVC.Models;
using Newtonsoft.Json;

namespace ASS_MVC.Controllers
{
    public class BillController : Controller
    {
        IBill _BillService;
        IBillDetail _BillDetailService;
        ICartDetail cartDetailService;
        IProduct _ProductService;
        // GET: BillController
        public BillController()
        {
            _BillService = new BillService();
            _BillDetailService= new BillDetailService();
            cartDetailService = new CartDetailService();
            _ProductService= new ProductService();

        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: BillController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BillController/Create
        [HttpGet]
        public ActionResult CreateBill(string Product_incart)
        {
            List<CartView> cartViews =JsonConvert.DeserializeObject<List<CartView>>(Product_incart);
            Bill newbill= new Bill()
            {
                Id = Guid.NewGuid(),
                UserId = cartViews[0].Idcart,
                Status = 0,
                CreateDate = DateTime.Now,
            };
            _BillService.Add(newbill);
            foreach(var item in cartViews)
            {
                _BillDetailService.Add(new BillDetail()
                {
                    Id = Guid.NewGuid(),
                    IdSP = item.Idsp,
                    IdHD = newbill.Id,
                    Quantity = item.Quantity,
                    Price = item.Price,
                });
                CartDetail drop_in_cart = cartDetailService.Getall().FirstOrDefault(x => x.Id == item.Id);
                cartDetailService.Delete(drop_in_cart);
                Product Update_Product=_ProductService.Getall().FirstOrDefault(x=>x.Id== item.Idsp);
                Update_Product.AvailableQuantity -= item.Quantity;
                _ProductService.Update(Update_Product);
                
            }
            return RedirectToAction("Cart","Cart");
        }

        // POST: BillController/Create
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

        // GET: BillController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BillController/Edit/5
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

        // GET: BillController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BillController/Delete/5
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
