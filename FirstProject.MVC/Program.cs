using FirstProject.BL.Profiles;
using FirstProject.BL.Services.Abstractions;
using FirstProject.BL.Services.Implementations;
using FirstProject.Core.Entities;
using FirstProject.DAL.Contexts;
using FirstProject.DAL.Repositories.Abstractions;
using FirstProject.DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSQL")));
builder.Services.AddIdentity<AppUser, IdentityRole>(
    opt =>
    opt.Password.RequiredLength = 8).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddAutoMapper(typeof(AppUserProfile).Assembly);
var app = builder.Build();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
   name: "areas",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
 );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
