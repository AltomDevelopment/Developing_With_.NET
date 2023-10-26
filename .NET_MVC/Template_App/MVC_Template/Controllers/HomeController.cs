using Microsoft.AspNetCore.Mvc;
using MVC_Template.Models;
using System.Diagnostics;

namespace MVC_Template.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestingDatabaseModel _context;

        public HomeController(ILogger<HomeController> logger, TestingDatabaseModel context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            var products = _context.Products.ToList();
            return View(products);
        }

        //public IActionResult Login()
        //{
        //    return View();
        //}

        public IActionResult Register()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? //HttpContext.TraceIdentifier });
        //}
    }
}