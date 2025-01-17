using Listrace.Core.Entities;

namespace Listrace.DAL.Repositories.Abstractions
{
	public interface IGenericRepository<Tentity> where Tentity : BaseEntity, new()
	{
		Task<ICollection<Tentity>> GetAllAsync(params string[] includes);
		Task<Tentity> CreateAsync (Tentity entity);
		Task<Tentity> GetByIdAsync (int id);
		Task<Tentity> GetByIdForUpdateAsync (int id);
		Tentity Update (Tentity entity);
		Tentity SoftDelete (Tentity entity);

	}
}
