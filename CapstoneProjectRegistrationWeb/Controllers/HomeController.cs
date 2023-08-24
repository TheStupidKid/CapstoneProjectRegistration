using CapstoneProjectRegistrationWeb.Models;
using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            var student = studentService.GetStudentById(2);
            StudentViewModel studentView = new StudentViewModel();
            studentView.Id = student.Id;
            studentView.Name = student.Name;
            return View(studentView);
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