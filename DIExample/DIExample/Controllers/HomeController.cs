using DIExample.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            FeaturedProductsViewModel featuredProducts = new(new ProductViewModel[]
            {
                new ProductViewModel("Product 1", 200.5m),
                new ProductViewModel("Product 2", 2500m)
            });

            return View(featuredProducts);
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