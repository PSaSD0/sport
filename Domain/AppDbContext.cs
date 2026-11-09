using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sport.Domain.Entities;


namespace sport.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string adminName = "admin";
            string adminRoleId = "514A9353-607E-4888-8703-6D06A8AE754C";
            string userAdminId = "81B70EF1-B708-4073-B090-1E9AEE21C752";


            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = adminName,
                NormalizedName = adminName.ToUpper()
            });


            string managerRoleId = "7BAB363F-6C0C-41C3-A39B-029F333E2035";
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = managerRoleId,
                Name = "manager",
                NormalizedName = "MANAGER"
            });


            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = userAdminId,
                UserName = adminName,
                NormalizedUserName = adminName.ToUpper(),
                Email = "admin@shop.com",
                NormalizedEmail = "ADMIN@SHOP.COM",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                PhoneNumberConfirmed = true
            });


            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = userAdminId
            });
        }
    }
}