using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using DIExample.Models;
using DIExample.Domain.Abstractions;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            ArgumentNullException.ThrowIfNull(productService, nameof(productService));

            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService
                .GetFeaturedProducts()
                .Select(x => new ProductViewModel(x));

            var featuredProducts = new FeaturedProductsViewModel(products);

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