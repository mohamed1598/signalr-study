using Microsoft.AspNetCore.Mvc;
using signalr.Models;
using System.Diagnostics;

namespace signalr.Controllers
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
            return View();
        }

        public IActionResult ViewHub()
        {
            return View();
        }
        public IActionResult StringTool()
        {
            return View();
        }
        public IActionResult ColorGrouping()
        {
            return View();
        }
        public IActionResult Vote()
        {
            return View();
        }
        public IActionResult Time()
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
