using Listrace.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Listrace.DAL.Contexts
{
	public class AppDbContext:IdentityDbContext<AppUser>
	{
        public AppDbContext(DbContextOptions opt) : base(opt) { }
        
        public DbSet<Place > Places { get; set; }   
        public DbSet<Catagory> Catagories { get; set; }
    }
}
