using Listrace.BL.Profiles;
using Listrace.BL.Services.Abstractions;
using Listrace.BL.Services.Implementations;
using Listrace.Core.Entities;
using Listrace.DAL.Contexts;
using Listrace.DAL.Repositories.Abstractions;
using Listrace.DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, IdentityRole>
    (opt=>opt.Password.RequiredLength = 8).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSQL")));
builder.Services.AddScoped<ICatagoryRepository , CatagoryRepository>();
builder.Services.AddScoped<IPlaceRepository , PlaceRepository>();
builder.Services.AddScoped<IPlaceService , PlaceService>();
builder.Services.AddAutoMapper(typeof(PlaceProfile));
builder.Services.AddAutoMapper(typeof(AppUserProfile));
var app = builder.Build();
app.UseStaticFiles();



app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();
app.Run();