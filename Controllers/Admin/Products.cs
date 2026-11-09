using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sport.Domain.Entities;

namespace sport.Controllers.Admin
{
    public partial class AdminController
    {

        public async Task<IActionResult> Products()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(products);
        }


        public async Task<IActionResult> ProductEdit(int id = 0)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();

            if (id == 0)
                return View(new Product());

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(Product entity, IFormFile? titleImage)
        {
            if (ModelState.IsValid)
            {
                if (titleImage != null)
                {
                    entity.Photo = titleImage.FileName;
                    await SaveImg(titleImage);
                }

                if (entity.Id == 0)
                    _context.Products.Add(entity);
                else
                    _context.Products.Update(entity);

                await _context.SaveChangesAsync();
                return RedirectToAction("Products");
            }

            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Products");
        }

        private async Task SaveImg(IFormFile file)
        {
            string path = Path.Combine(_hostEnvironment.WebRootPath, "img", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}