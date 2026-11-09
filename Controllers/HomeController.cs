using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sport.Domain;
using sport.Domain.Entities;
using sport.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace sport.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Загружаем последние 5 одобренных отзывов
            var reviews = await _context.Reviews
                .Include(r => r.User) // Подгружаем пользователя, чтобы показать его имя
                .Where(r => r.IsApproved == true) // Только одобренные (модерация)
                .OrderByDescending(r => r.DateCreated)
                .Take(5)
                .ToListAsync();

            ViewBag.Reviews = reviews;

            // Создаем пустую модель для формы
            ViewBag.NewReview = new ReviewViewModel();

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddReview(ReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                // 1. Ищем пользователя
                var user = await _userManager.GetUserAsync(User);

                // 2. Если пользователь не найден — не даем сохранить отзыв
                if (user == null)
                {
                    ModelState.AddModelError("", "Не удалось найти пользователя. Войдите заново.");
                    return View("Index", model); // Возвращаемся на главную с ошибкой
                }

                // 3. Если найден — создаем отзыв
                var review = new Review
                {
                    UserId = user.Id,
                    Text = model.Text,
                    Rating = model.Rating,
                    IsApproved = true,
                    DateCreated = DateTime.UtcNow
                };

                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}