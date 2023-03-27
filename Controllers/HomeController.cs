using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASS_MVC.Models;
using Microsoft.EntityFrameworkCore;
using ASS_MVC.Iservice;
using ASS_MVC.Service;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace ASS_MVC.Controllers;

public class HomeController : Controller
    
{
    private readonly ILogger<HomeController> _logger;
    public IProduct product = new ProductService();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Model<T>(T item) where T : class
    {
        var db = new ShopDbContext();
       
        
        return View("Model",item);
    }
    public IActionResult Detail(Guid id) {
        var pd= product.Getall().FirstOrDefault(x => x.Id==id);
        return View(pd);
    }
    public IActionResult ShowProducts()
    {
        List<Product> listProducts = product.Getall();
        return View(listProducts);
    }
    public IActionResult DBmodel()
    {
        var dbcontext = new ShopDbContext();
        List<Type> modelTypes = dbcontext.Model.GetEntityTypes().Select(p => p.ClrType).ToList();
        List<String> modelTypesName = modelTypes.Select(c => c.Name).ToList();

        return View(modelTypesName); ;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
