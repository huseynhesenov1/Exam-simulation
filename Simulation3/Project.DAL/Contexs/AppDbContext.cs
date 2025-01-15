using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Core.Entities;

namespace Project.DAL.Contexs
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions opt) : base(opt) { }
        public DbSet<News> Newss { get; set; }
        public DbSet<Catagory> Catagories { get; set; }

    }
}
