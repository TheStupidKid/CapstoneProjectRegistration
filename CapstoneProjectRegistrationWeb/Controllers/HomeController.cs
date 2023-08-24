using BussinessObject.Models;
using CapstoneProjectRegistrationWeb.Models;
using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CapstoneProjectRegistrationWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentService studentService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, StudentService studentService)
        {
            _logger = logger;
            this.studentService= studentService;
        }

        public IActionResult Index()
        {
            //get current user
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var role = claimsIdentity.FindFirst(ClaimTypes.Role);
            if (role != null && role.Value.Equals("Student")){
                return RedirectToAction("Success");
            }
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginModel, string returnUrl)
        {
            ClaimsIdentity identity = null;
            string controller = "Home";
            Student student = studentService.Login(loginModel.Email, loginModel.Password);
            if(student == null)
            {
                ViewBag.ErrorMessage = "Incorrect email or password";
                return View("Views/Home/Login.cshtml");
            }
            return RedirectToAction("Success");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}