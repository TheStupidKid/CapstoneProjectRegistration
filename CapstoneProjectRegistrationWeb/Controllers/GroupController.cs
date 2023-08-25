using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CapstoneProjectRegistrationWeb.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
