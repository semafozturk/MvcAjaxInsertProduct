using Entities;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using System.Diagnostics;

namespace ProductApi.Controllers
{
    //[ApiController]
   // [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ProductContext db = new ProductContext();
        DBOperations dbOperations = new DBOperations();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            List<Product> products = dbOperations.GetProducts();
            return View(products);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            bool productCheck = dbOperations.AddProduct(product);
            Result result = new Result();
            if (productCheck == true)
            {
                result.status = 1;
                result.message = "Yeni ürün listeye eklendi.";
                ViewBag.yes= result.message;
            }
            else
            {
                result.status = 0;
                result.message = "Hata, ürün eklenemedi.";
                ViewBag.no = result.message;
            }
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}