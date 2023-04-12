using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASS_MVC.Iservice;
using ASS_MVC.Service;
using ASS_MVC.Models;

namespace ASS_MVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        public readonly IProduct _ProductService;

        public ProductController()
        {
            _ProductService = new ProductService();
        }
        // GET: ProductController
        [Route("/Admin/Product")]
        public ActionResult Index()
        {
            
            return View(_ProductService.Getall());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        [Route("/Admin/Product/vcl")]
        public IActionResult vcl()
        {
            return View();
        }
        // GET: ProductController/Create
        [HttpGet]
        [Route("/Admin/Product/Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product,IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0) // Không null không rỗng
            {
                // Thực hiện trỏ tới thư mục root để lát thực hiện việc copy
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "images", imageFile.FileName); // Bước 2
                // Kết quả: aaa/wwwroot/images/xxx.jpg, Path.Combine = tổng hợp đường dẫn
                var stream = new FileStream(path, FileMode.Create);
                // Vì chúng ta thực hiện việc copy => Tạo mới => Create
                imageFile.CopyTo(stream); // Copy ảnh chọn ở form vào wwwroot/images
                // Gán lại giá trị cho thuộc tính Description => Bước 3
                product.Description = imageFile.FileName; // Bước 4
            }
            try
            {
                _ProductService.Add(product);
            }
            catch
            {
                return Content("Error");
            }
            return RedirectToAction(nameof(Index),_ProductService.Getall());
        }

        // GET: ProductController/Edit/5
        [HttpGet]
        [Route("Admin/Product/Edit/{Id}")]
        public ActionResult Edit(Guid id)
        {
            var y = _ProductService.Getall().FirstOrDefault(p=>p.Id== id);
            return View(y);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
               _ProductService.Update(product);
            }
            catch
            {
                return View();
            }
            return View(nameof(Index),_ProductService.Getall());
        }

        // GET: ProductController/Delete/5
        [Route("/Admin/Product/Delete/{Id}")]
        public ActionResult Delete(Guid Id)
        {
            var Product = _ProductService.Getall().FirstOrDefault(x=>x.Id== Id);
            _ProductService.Delete(Product);
            return View(nameof(Index),_ProductService.Getall());
        }

        // POST: ProductController/Delete/5
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
