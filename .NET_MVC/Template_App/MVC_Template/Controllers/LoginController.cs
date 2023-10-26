using Microsoft.AspNetCore.Mvc;
using MVC_Template.Models;
using MVC_Template.ViewModel;

namespace MVC_Template.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestingDatabaseModel _context;

        public LoginController(ILogger<HomeController> logger, TestingDatabaseModel context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(LoginViewModel model)
        {
            using (TestingDatabaseModel db = new TestingDatabaseModel())
            {
                //Checking the database to see if the user already exist
                var userDetails = db.Users.Where(a => a.Email.Equals(model.EmailAddress) &&
                a.PasswordHash.Equals(model.PassWord)).FirstOrDefault();
                
                if (userDetails == null)
                {
                    model.LoginErrorMessage = "Wrong email or password";
                    return View("Index", model);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }//return View("Index");
        }
    }
}
