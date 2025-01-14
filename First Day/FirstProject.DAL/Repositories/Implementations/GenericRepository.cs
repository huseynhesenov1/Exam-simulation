using FirstProject.Core.Entities;
using FirstProject.DAL.Contexts;
using FirstProject.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.DAL.Repositories.Implementations;

public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
{
    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }
    public DbSet<Tentity> Table => _context.Set<Tentity>();
    public async Task<Tentity> CreateAsync(Tentity entity)
    {
        await Table.AddAsync(entity);
        return entity;
    }

    public async Task<ICollection<Tentity>> GetAllAsync()
    {
      return  await Table.ToListAsync();
    }

    public async Task<Tentity> GetByIdAsync(int id)
    {
       return await Table.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Tentity> GetByIdForUpdateAsync(int id)
    {
        return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public void SoftDelete(Tentity entity)
    {
       entity.IsDeleted = true;
    }

    public void Update(Tentity entity)
    {
       Table.Update(entity);    
    }
}