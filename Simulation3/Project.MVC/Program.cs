using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.BL.Profiles;
using Project.BL.Services.Abstractions;
using Project.BL.Services.Implementations;
using Project.Core.Entities;
using Project.DAL.Contexs;
using Project.DAL.Repositories.Abstractions;
using Project.DAL.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(NewsProfile).Assembly);
builder.Services.AddAutoMapper(typeof(AppUserProfile).Assembly);
builder.Services.AddIdentity<AppUser, IdentityRole>(opt => opt.Password.RequiredLength = 8).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>(); ;
builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSQL")));
builder.Services.AddScoped<INewsRepository , NewsRepository>();
builder.Services.AddScoped<INewsService , NewsService>();
var app = builder.Build();



app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();



app.Run();
