using LoggingKit.Web.UI.Models;
using LoggingKitBase;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoggingKit.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly ILogAdapter _logger;
        public HomeController(ILogAdapter logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.Log(LoggingKitBase.LogLevel.Information, "Browsed home page!");
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
