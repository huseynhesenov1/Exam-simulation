using Project.BL.DTOs;
using Project.Core.Entities;
using Project.DAL.Repositories.Abstractions;

namespace Project.BL.Services.Abstractions
{
    public interface ITechnicianService
    {
        Task<ICollection<Technician>> GetAllAsync();
        Task<Technician> CreateAsync(TechnicianDTO technicianDTO);
        Task<Technician> GetByIdForUpdateAsync(int id);
        Task<Technician> GetByIdAsync(int id);
        Task<Technician> SoftDeleteAsync(int id);
        Task<Technician> UpdateAsync(int id ,TechnicianDTO technicianDTO);
    }
}
