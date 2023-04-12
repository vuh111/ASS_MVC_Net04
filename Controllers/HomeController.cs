using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASS_MVC.Models;
using Microsoft.EntityFrameworkCore;
using ASS_MVC.Iservice;
using ASS_MVC.Service;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Web;
using ASS_MVC.Service;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ASS_MVC.Controllers;
public class HomeController : Controller
    
{
    private readonly ILogger<HomeController> _logger;
    public IProduct productservice = new ProductService();
    
    public User current_user { get; set; }
    public HomeController(ILogger<HomeController> logger)
    {
        current_user= new User();
        _logger = logger;
    }


    public IActionResult Index(User? user)
    {
       
        if (user != null)
        {
            current_user = user;
            ViewBag.current_user = current_user;
        }
        return View();
    }
    public IActionResult Increa(Guid Id)
    {


        int number = int.Parse(ViewData["quantity"].ToString());
        number++;
        ViewData["quantity2"] = number;
        return RedirectToAction(nameof(Detail), Id);

    }

    /*public IActionResult Model<T>(T items) where T : class
    {
        var modelTypeName = typeof(T).Name;
        ViewBag.ModelTypeName = modelTypeName;

        return View();
        
    }*/
    public IActionResult Model(string item)
    {
        if (item == null)
        {
            return Content("dit me no null");
        }
        var itemtype = Type.GetType(item.ToString());
        return View("Model",item);
    }
    [HttpGet]
    public IActionResult Detail(Guid id) {
        ViewData["quantity-2"] = 0;
        var product = productservice.Getall().FirstOrDefault(x => x.Id == id);
       

		return View(product);
    }
    public IActionResult ShowProducts()
    {
        List<Product> listProducts = productservice.Getall();
       
        return View(listProducts);
    }
    public IActionResult ShowCart() {

        var Product = SessionService.GetProduct(HttpContext.Session, "data");
     
        return View(Product);
    }
    public IActionResult AddCart(Guid id) {
        var product= productservice.Getall().FirstOrDefault(x=>x.Id==id);
        var Products = SessionService.GetProduct(HttpContext.Session, "data");
        if(Products.Count==0) {
            Products.Add(product);
            SessionService.SetProduct(HttpContext.Session, "data", Products);
        }
        else
        {
            if (SessionService.CheckProduct(Products, id))
            {
                return Content("Bình thường chúng ta sẽ thêm số lượng nhưng vì " +
                       "lười nên không thêm mà chỉ đưa ra thông báo vô ích này");

				
            }
            else
            {
                Products.Add(product);
				SessionService.SetProduct(HttpContext.Session, "data", Products);
			}

        }
        

		return RedirectToAction("ShowCart");
    }
    public IActionResult DBmodel()
    {
        var dbcontext = new ShopDbContext();
        List<Type> modelTypes = dbcontext.Model.GetEntityTypes().Select(p => p.ClrType).ToList();


        return Redirect("~/Admin/Product");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
