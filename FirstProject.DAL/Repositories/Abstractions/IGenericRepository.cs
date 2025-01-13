using FirstProject.Core.Entities;

namespace FirstProject.DAL.Repositories.Abstractions;

public interface IGenericRepository<Tentity> where Tentity : BaseEntity , new()
{
    Task<ICollection<Tentity>> GetAllAsync();
    Task<Tentity>  CreateAsync(Tentity entity);
    void SoftDelete (Tentity entity);
    void Update(Tentity entity);
    Task<Tentity> GetByIdAsync(int id);
    Task<Tentity> GetByIdForUpdateAsync(int id);
}
