using Microsoft.AspNetCore.Mvc;

namespace CapstoneProjectRegistrationWeb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
