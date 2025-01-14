using FirstProject.BL.Services.Abstractions;
using FirstProject.Core.Entities;
using FirstProject.DAL.Contexts;
using FirstProject.DAL.Repositories.Abstractions;

namespace FirstProject.BL.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepo;
        private readonly AppDbContext _context;

        public CartService(ICartRepository cartRepo, AppDbContext context)
        {
            _cartRepo = cartRepo;
            _context = context;
        }

        public async Task<Cart> CreateAsync(Cart cart)
        {
            Cart createdCart = await _cartRepo.CreateAsync(cart);
            createdCart.CreateAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return createdCart;
        }

        public async Task<ICollection<Cart>> GetAllAsync()
        {
            return await _cartRepo.GetAllAsync();
        }
    }
}
