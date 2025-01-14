using Project.Core.Entities;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstractions
{
    public interface IGenericRepository<Tentity> where Tentity : BaseEntity, new()
    {
        Task<ICollection<Tentity>> GetAllAsync();   
        Task<Tentity> CreateAsync(Tentity entity);
        Tentity Update(Tentity entity);
        Tentity SoftDelete(Tentity entity);
        Task<Tentity> GetByIdAsync(int id);
        Task<Tentity> GetByIdForUpdateAsync(int id);
    }
}
