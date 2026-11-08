using Microsoft.EntityFrameworkCore;
using sport.Models.Catalog;
using sport.Models.Marketing;
using sport.Models.Orders;
using sport.Models.Users;

namespace sport.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }


        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}