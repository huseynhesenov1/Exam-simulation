using Listrace.Core.Entities;
using Listrace.DAL.Contexts;
using Listrace.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Listrace.DAL.Repositories.Implementations
{
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

		public async Task<ICollection<Tentity>> GetAllAsync(params string[] includes)
		{
			var query = Table.AsQueryable();
			if (includes.Length != 0)
			{
                foreach (var include in includes)
                {
					query = query.Include(include);
                }
            }

			return await query.ToListAsync();
		}

		public async Task<Tentity> GetByIdAsync(int id)
		{
			return await Table.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Tentity> GetByIdForUpdateAsync(int id)
		{
			return await Table.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);	
		}

		public Tentity SoftDelete(Tentity entity)
		{
			if (entity == null)
            {
				throw new Exception("bu id tpilmadi");
            }
            entity.IsDeleted = true;

			return entity;
		}

		public Tentity Update(Tentity entity)
		{
			Table.Update(entity);
			return entity;
		}
	}
}
