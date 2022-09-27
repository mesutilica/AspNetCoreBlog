using AspNetCoreBlog.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AspNetCoreBlog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // DatabaseContext i servis olarak ekliyoruz
            builder.Services.AddDbContext<DatabaseContext>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(u =>
            {
                u.LoginPath = "/Admin/Login"; // kullan�c� giri� yapmam��sa bu adrese y�nlendir
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Admin giri� i�in oturum a�may� aktif et
            app.UseAuthorization();

            // Admin area i�in route
            app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");

            // Normal site i�in route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}