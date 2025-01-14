using Project.Core.Entities;

namespace Project.BL.Services.Abstractions
{
    public interface IServiceService
    {
        Task<ICollection<Service>> GetAllAsync();
    }
}
