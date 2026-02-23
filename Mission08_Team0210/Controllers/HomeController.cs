using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mission08_Team0210.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
