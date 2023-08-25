using BussinessObject.Models;
using CapstoneProjectRegistrationWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProjectRegistrationWeb.Controllers
{
    public class LectureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
