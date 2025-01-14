using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Core.Entities;


namespace Project.DAL.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions opt) : base(opt) { }
        public DbSet<Service> Services { get; set; }    
        public DbSet<Technician> Technicians { get; set; }    
    }
}
