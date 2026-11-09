using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sport.Domain.Entities;

namespace sport.Controllers.Admin
{
    public partial class AdminController
    {

        public async Task<IActionResult> Categories()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        public async Task<IActionResult> CategoryEdit(int id = 0)
        {
            if (id == 0)
                return View(new Category());

            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryEdit(Category entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.Id == 0)
                    _context.Categories.Add(entity);
                else
                    _context.Categories.Update(entity);

                await _context.SaveChangesAsync();
                return RedirectToAction("Categories");
            }
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryDelete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Categories");
        }
    }
}