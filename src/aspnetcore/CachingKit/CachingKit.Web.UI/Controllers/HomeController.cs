using CachingKit.Web.UI.Models;
using CachingKitBase;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CachingKit.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICacheStrategy _cacheStrategy = null!;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICacheStrategy cacheStrategy)
        {
            _logger = logger;
            _cacheStrategy = cacheStrategy;

            var countries = this.GetCountries();

            _cacheStrategy.Store<IEnumerable<string>>("countries", countries);
        }

        public IActionResult Index()
        {
            var countries = _cacheStrategy.Retrieve<IEnumerable<string>>("countries");

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

        private IEnumerable<string> GetCountries()
        {
            return new List<string> ()
            {
                "US",
                "Russia",
                "UK",
                "France",
                "Germany",
                "Japan",
                "Israel",
                "India",
                "China"
            };
        }
    }
}
