using Project.BL.DTOs;
using Project.Core.Entities;

namespace Project.BL.Services.Abstractions
{
    public interface INewsService
    {
        Task<ICollection<News>> GetAllAsync();
        Task<News> CreateAsync(NewsDto newsDto);
        Task<News> GetByIdAsync(int id);
        Task<News> GetByIdForUpdateAsync(int id);
        Task<News> UpdateAsync(NewsUpdateDto  newsUpdateDto);
        Task<News> SoftDeleteAsync(int id);
    }
}
