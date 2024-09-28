using Microsoft.AspNetCore.Authentication.Cookies; // Ensure this using directive is included
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using wslni.BLL.services.implementation;
using wslni.BLL.services.interfaces;
using wslni.DAL.DB;
using wslni.DAL.Entities;
using wslni.DAL.Repo.implementation;
using wslni.DAL.Repo.interfaces;

namespace wslni.PLL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("name=DefaultConnection"));

            // Add Identity services
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Configure authentication with cookie
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login"; // Set your login path
                    options.LogoutPath = "/Account/LogOut"; // Set your logout path
                    options.AccessDeniedPath = "/Account/AccessDenied"; // Set your access denied path
                    options.SlidingExpiration = true; // Optional: enable sliding expiration
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Set expiration time
                });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IRideService, RideService>();
            builder.Services.AddScoped<IRideRepo, RideRepo>();
            builder.Services.AddScoped<IVehicleRepo, VehicleRepo>();
            builder.Services.AddScoped<IVehicleService, VehicleService>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Ensure this is called before UseAuthorization
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
