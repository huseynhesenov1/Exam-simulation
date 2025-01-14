using FirstProject.Core.Entities;

namespace FirstProject.BL.Services.Abstractions
{
    public interface ICartService
    {
        Task<ICollection<Cart>> GetAllAsync();
        Task<Cart> CreateAsync(Cart cart);
    }
}
