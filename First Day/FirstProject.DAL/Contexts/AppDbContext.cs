using FirstProject.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.DAL.Contexts;

public class AppDbContext:IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions  opt):base(opt)
    {
        
    }
    public DbSet<Cart> Carts { get; set; }
}
