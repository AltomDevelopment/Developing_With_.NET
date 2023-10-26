using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVC_Template.Models;
using MVC_Template.ViewModel;

namespace MVC_Template.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestingDatabaseModel _context;

        public SignUpController(ILogger<HomeController> logger, TestingDatabaseModel context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[Route("~/Users/AddUser")]
        public ActionResult AddUser(SignUpViewModel model)
        {
            using (TestingDatabaseModel db = new TestingDatabaseModel())
            {
                if(ModelState.IsValid)
                {
                    var obj = db.Users.Where(a => a.Email.Equals(model.EmailAddress)).FirstOrDefault();
                    if (obj == null)
                    {
                        User user = new User();
                        user.FirstName = model.FirstName;
                        user.LastName = model.LastName;
                        user.UserName = null;
                        user.NormalizedUserName = null;
                        user.Email = model.EmailAddress;
                        user.NormalizedEmail = null;
                        user.EmailConfirmed = null;
                        user.PhoneNumber = null;
                        user.PasswordHash = model.PassWord;
                        user.PhoneNumberConfirmed = false;
                        user.TwoFactorEnabled = false;
                        user.LockoutEnd = null;
                        user.LockoutEnabled = false;
                        user.IsAdmin = false;
                        user.AccessFailedCount = 0;
                        user.TimeCreated = DateTime.Now;
                        user.LastModified = DateTime.Now;

                        db.Users.Add(user);
                        db.SaveChanges();

                        return RedirectToAction(actionName: "Index", controllerName: "Login");
                    }

                    else if (obj != null)
                    {
                        model.SignupErrorMessage = "An account already exists with this email address";
                        return View("Signup", model);
                    }
                }
            }
            
        return View("Index");
        }
    }
}
