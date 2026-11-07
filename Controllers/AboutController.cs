using Microsoft.AspNetCore.Mvc;

namespace sport.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
