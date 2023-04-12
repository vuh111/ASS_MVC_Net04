using ASS_MVC.Iservice;
using ASS_MVC.Models;
using ASS_MVC.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASS_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class BillController : Controller
    {
        private readonly IBill _BillService;
        private readonly IBillDetail _BillDetailService;
        public BillController()
        {
            _BillService = new BillService();
            _BillDetailService= new BillDetailService();
        }
        // GET: BillController
        [Route("/Admin/Bill")]
        public ActionResult Bill()
        {
            var list_bill = _BillService.Getall();
            return View(list_bill);
        }

        // GET: BillController/Details/5
        [HttpGet]
        [Route("/Admin/Bill/Details")]
        public ActionResult Details(Guid id)
        {
            List<BillDetail> list_pd_in_bill=_BillDetailService.Getall().FindAll(x=>x.IdHD==id);
            return View(list_pd_in_bill);
        }

        // GET: BillController/Create
        public ActionResult Create()
        {
            return View();
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
