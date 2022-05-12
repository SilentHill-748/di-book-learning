using Microsoft.AspNetCore.Mvc;

using NoDIExample.DomainLayer;
using NoDIExample.Models;

using System.Diagnostics;

namespace NoDIExample.Controllers
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
            bool isCustomerPreferred = this.User.IsInRole("PreferredCustomer");

            var service = new ProductService();

            var products = service.GetFeaturedProducts(isCustomerPreferred);

            this.ViewData["Products"] = products;

            return View();
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