using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sport.Domain;
using sport.Infrastructure;
using Microsoft.AspNetCore.Hosting;

namespace sport.Controllers.Admin
{
    [Authorize(Roles = "admin,manager")] 
    public partial class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public AdminController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }


        public IActionResult Index()
        {
            ViewBag.Title = "Панель администратора";
            return View();
        }
    }
}