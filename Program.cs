using Microsoft.EntityFrameworkCore;
using sport.Domain;
using sport.Infrastructure; 

namespace sport
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddControllersWithViews();


            builder.Services.Configure<AppConfig>(builder.Configuration.GetSection("Project"));


            builder.Services.AddSingleton(sp =>
                builder.Configuration.GetSection("Project").Get<AppConfig>() ?? new AppConfig());

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            await app.RunAsync();
        }
    }
}