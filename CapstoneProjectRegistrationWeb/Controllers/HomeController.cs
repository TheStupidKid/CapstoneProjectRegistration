using BussinessObject.Models;
using CapstoneProjectRegistrationWeb.Models;
using DataAccess.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CapstoneProjectRegistrationWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentService studentService;
        private readonly LectureService lectureService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, StudentService studentService, LectureService lectureService)
        {
            _logger = logger;
            this.studentService= studentService;
            this.lectureService= lectureService;
        }

        public IActionResult Index()
        {
            //get current user
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var role = claimsIdentity.FindFirst(ClaimTypes.Role);
            if (role != null && role.Value.Equals("Lecture")){
                return RedirectToAction("Index","Lecture");
            }
            return View();
        }
        [Authorize(Roles = "Lecture")]
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Identity()
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
            Lecture lecture = lectureService.Login(loginModel.Email, loginModel.Password);
            if(student == null && lecture == null)
            {
                ViewBag.ErrorMessage = "Incorrect email or password";
                return View("Views/Home/Login.cshtml");
            }
            if(lecture !=null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, lecture.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Lecture")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                controller = "Lecture";
            }
            else
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, student.Id.ToString()),
                    new Claim(ClaimTypes.Email, student.Email),
                    new Claim(ClaimTypes.Name, student.Name),
                     new Claim(ClaimTypes.Role, student.Role)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
            }
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index",controller);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}