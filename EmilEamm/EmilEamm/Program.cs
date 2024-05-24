
using EmilEamm.DAL;
using EmilEamm.Models;
using EmilEamm.Services;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddTransient<LayoutService>();
        builder.Services.AddDbContext<ExamContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

        builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
        {
            opt.User.RequireUniqueEmail = true;
            opt.Password.RequiredLength = 3;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireDigit = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Lockout.AllowedForNewUsers = true;
            opt.Lockout.MaxFailedAccessAttempts = 2;
            opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
        })
        .AddEntityFrameworkStores<ExamContext>()
        .AddDefaultTokenProviders();

        var app = builder.Build();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllerRoute("areas", "{area:exists}/{controller=Member}/{action=Index}/{id?}");
        app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        app.Run();
    }
}